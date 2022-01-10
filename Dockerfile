#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Notification-Service.Web/Notification-Service.Web.csproj", "Notification-Service.Web/"]
RUN dotnet restore "Notification-Service.Web/Notification-Service.Web.csproj"
COPY . .
WORKDIR "/src/Notification-Service.Web"
RUN dotnet build "Notification-Service.Web.csproj" -c Release -o /app/build

FROM build AS dev
WORKDIR "/src/Notification-Service.Web"
ENTRYPOINT ["dotnet", "watch", "run", "--urls=http://+:5000"]

FROM build AS publish
RUN dotnet publish "Notification-Service.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notification-Service.Web.dll"]
