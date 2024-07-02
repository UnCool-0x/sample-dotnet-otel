# Donet Sample Signoz

Tested with .NET8

## Install dependencies

```
dotnet add package OpenTelemetry
dotnet add package OpenTelemetry.Exporter.OpenTelemetryProtocol
dotnet add package OpenTelemetry.Exporter.Console
dotnet add package OpenTelemetry.Extensions.Hosting
```

## Replace variables

Replace `signoz_service_name` with name of your application, `signoz_endpoint` with endpoint of Signoz and `signoz_ingestion_key` with Injestion key.

## Run command

```
dotnet run
```
