FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourse.Shared/*.csproj Shared/FreeCourse.Shared/
COPY Services/DummyPayment/FreeCourse.Services.DummyPayment/*.csproj Services/DummyPayment/FreeCourse.Services.DummyPayment/
RUN dotnet restore Services/DummyPayment/FreeCourse.Services.DummyPayment/*.csproj
COPY . .
RUN dotnet publish Services/DummyPayment/FreeCourse.Services.DummyPayment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourse.Services.DummyPayment.dll" ]