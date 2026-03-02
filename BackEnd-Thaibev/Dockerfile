# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["BackEnd-Thaibev.csproj", "./"]
RUN dotnet restore "./BackEnd-Thaibev.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "BackEnd-Thaibev.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BackEnd-Thaibev.dll"]