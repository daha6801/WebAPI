FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /WebApplication1

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /WebApplication1
COPY --from=build /WebApplication1/out ./

ENTRYPOINT ["dotnet", "myapp.dll"]
