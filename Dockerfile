# SDK aşaması
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Proje dosyalarını kopyalama ve derleme
COPY . ./
RUN dotnet restore DenemeAPI.csproj
RUN dotnet publish DenemeAPI.csproj -c Release -o out

# Uygulamayı çalıştırmak için runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "deneme-api.dll"]

