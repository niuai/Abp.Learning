#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Jiabin.Web/Jiabin.Web.csproj", "src/Jiabin.Web/"]
COPY ["src/Jiabin.HttpApi/Jiabin.HttpApi.csproj", "src/Jiabin.HttpApi/"]
COPY ["src/Jiabin.Application.Contracts/Jiabin.Application.Contracts.csproj", "src/Jiabin.Application.Contracts/"]
COPY ["src/Jiabin.Domain.Shared/Jiabin.Domain.Shared.csproj", "src/Jiabin.Domain.Shared/"]
COPY ["src/Jiabin.EntityFrameworkCore.DbMigrations/Jiabin.EntityFrameworkCore.DbMigrations.csproj", "src/Jiabin.EntityFrameworkCore.DbMigrations/"]
COPY ["src/Jiabin.EntityFrameworkCore/Jiabin.EntityFrameworkCore.csproj", "src/Jiabin.EntityFrameworkCore/"]
COPY ["src/Jiabin.Domain/Jiabin.Domain.csproj", "src/Jiabin.Domain/"]
COPY ["src/Jiabin.Application/Jiabin.Application.csproj", "src/Jiabin.Application/"]
RUN dotnet restore "src/Jiabin.Web/Jiabin.Web.csproj"
COPY . .
WORKDIR "/src/src/Jiabin.Web"
RUN dotnet build "Jiabin.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jiabin.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jiabin.Web.dll"]