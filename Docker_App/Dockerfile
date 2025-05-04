#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Docker_App/Docker_App.csproj", "Docker_App/"]
RUN dotnet restore "Docker_App/Docker_App.csproj"
COPY . .
WORKDIR "/src/Docker_App"
RUN dotnet build "Docker_App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker_App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker_App.dll"]


#//docker build -t simplecoreapp
#
#//docker volume create --driver local --opt type=none --opt device=F:\docker_volumes\my_volume --opt o=bind my_volumeCore   
#
#// docker run -d  --name AppCore1404 -p 8040:80 -v my_volumeCore:/app -v my_volumeCore:/src   eb08bf1c540c