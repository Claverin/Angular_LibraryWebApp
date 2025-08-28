FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY LibraryWebApp/LibraryWebApp.csproj LibraryWebApp/
RUN dotnet restore LibraryWebApp/LibraryWebApp.csproj

COPY LibraryWebApp/. LibraryWebApp/
WORKDIR /src/LibraryWebApp
RUN dotnet publish LibraryWebApp.csproj -c Release -o /out /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080 \
    ASPNETCORE_ENVIRONMENT=Production

COPY --from=build /out ./

EXPOSE 8080
ENTRYPOINT ["dotnet", "LibraryWebApp.dll"]