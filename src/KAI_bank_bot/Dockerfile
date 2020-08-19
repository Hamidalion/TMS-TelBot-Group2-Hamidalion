#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["KAI_bank_bot.csproj", "KAI_bank_bot/"]
RUN dotnet restore "KAI_bank_bot/KAI_bank_bot.csproj"
WORKDIR "/src/KAI_bank_bot"
COPY . .
RUN dotnet build "KAI_bank_bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KAI_bank_bot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet KAI_bank_bot.dll
