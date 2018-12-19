using Id3;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VisionMusicLibrary.Models;
using VisionWebService.Database;

namespace VisionWebService
{
    public class RepoScanner : IHostedService
    {
        private CancellationToken _cancellationToken;
        private Timer _timer;
        private Repository _currentRepo;
        private Uri _currentRepoUri;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;

            // TODO: change to quarz
            _timer = new Timer(DoWork, null, TimeSpan.Zero, Timeout.InfiniteTimeSpan);

            return Task.CompletedTask;
        }

        public void DoWork(object state)
        {
            List<Repository> repos;
            using (VisionServerContext db = new VisionServerContext())
            {
                repos = db.Repositories.ToList();
            }

            foreach(Repository repo in repos)
            {
                _currentRepo = repo;
                _currentRepoUri = new Uri(repo.Path);
                ScanRepo(new DirectoryInfo(repo.Path));
            }
        }

        private void ScanRepo(DirectoryInfo dir)
        {
            // Check if path exists and we can access the directory
            if (!dir.Exists)
                return;

            // walk through the files
            foreach (FileInfo file in dir.EnumerateFiles())
            {
                using (var mp3 = new Mp3File(file))
                {
                    Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2x);
                    
                    Track track = new Track()
                    {
                        Title = tag.Title,
                        Album = new Album(tag.Album),
                        Artist = new Artist(tag.Artists),
                        Repository = _currentRepo,
                        RelativePath = _currentRepoUri.MakeRelativeUri(new Uri(file.FullName)).ToString()
                    };
                }


                //using (VisionServerContext db = new VisionServerContext())
                //{
                //    db.Tracks.AddAsync(track);
                //}
            }

            // walk through the directories


        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
