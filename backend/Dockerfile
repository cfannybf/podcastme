FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
ENV ASPNETCORE_URLS http://+:6001

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/out

WORKDIR /app/out