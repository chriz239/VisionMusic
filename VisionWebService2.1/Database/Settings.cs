﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisionMusicLibrary.Models;
using VisionWebService.Database;

namespace VisionMusicLibrary
{
    public static class Settings
    {
        
        public static T GetSettingValue<T>(string name)
        {
            Setting setting = null;
            using (VisionServerContext db = new VisionServerContext())
            {
                setting = db.Settings.Single(s => s.Key == name);
            }
            return (T)Convert.ChangeType(setting.Value, typeof(T));
        }
        
    }
}
