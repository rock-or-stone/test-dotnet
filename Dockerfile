FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet restore
# Build and publish a release
RUN dotnet build
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /App
ADD entrypoint.sh entrypoint.sh
COPY --from=build-env /App/out .
ENTRYPOINT sh entrypoint.sh