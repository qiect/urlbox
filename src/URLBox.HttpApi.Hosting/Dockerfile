FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "URLBox.HttpApi.Hosting.dll","--service.urls","--server.urls","http://*:5000;https://*:5001"]