FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52995
EXPOSE 44365

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY VisionWebService2.1/VisionWebService2.1.csproj VisionWebService2.1/
RUN dotnet restore VisionWebService2.1/VisionWebService2.1.csproj
COPY . .
WORKDIR /src/VisionWebService2.1
RUN dotnet build VisionWebService2.1.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish VisionWebService2.1.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VisionWebService2.1.dll"]
