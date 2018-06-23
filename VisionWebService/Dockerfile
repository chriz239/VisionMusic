FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY VisionWebService/VisionWebService.csproj VisionWebService/
RUN dotnet restore VisionWebService/VisionWebService.csproj
COPY . .
WORKDIR /src/VisionWebService
RUN dotnet build VisionWebService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish VisionWebService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VisionWebService.dll"]
