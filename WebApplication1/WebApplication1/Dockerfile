FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
WORKDIR /WebApplication1

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . /src
WORKDIR /src
RUN ls
RUN dotnet build "WebApplication1.csproj" -c Release -o /WebApplication1/build

FROM build AS publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /WebApplication1/publish

FROM base AS final
WORKDIR /WebApplication1
COPY --from=publish /WebApplication1/publish .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]

# RUN dotnet dev-certs https --trust
RUN dotnet ef database update
