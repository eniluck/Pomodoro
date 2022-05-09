#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pomodoro.Api/Pomodoro.Api.csproj", "Pomodoro.Api/"]
COPY ["Pomodoro.BL/Pomodoro.BL.csproj", "Pomodoro.BL/"]
COPY ["Pomodoro.Core/Pomodoro.Core.csproj", "Pomodoro.Core/"]
COPY ["Pomodoro.DAL.Postgres/Pomodoro.DAL.Postgres.csproj", "Pomodoro.DAL.Postgres/"]
RUN dotnet restore "Pomodoro.Api/Pomodoro.Api.csproj"
COPY . .
WORKDIR "/src/Pomodoro.Api"
RUN dotnet build "Pomodoro.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pomodoro.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pomodoro.Api.dll"]
