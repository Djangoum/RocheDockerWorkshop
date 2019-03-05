FROM microsoft/dotnet:2.2-sdk-alpine AS build
WORKDIR /app

COPY . .
RUN dotnet restore

# copy everything else and build app
WORKDIR /app
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:latest AS runtime
WORKDIR /app

COPY --from=build /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "docker-examples.dll"]