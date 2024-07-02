using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using OpenTelemetry.Exporter;

namespace Demo
{
    internal static class OpentelemetryExporterDemo
    {
        internal static void Run()
        {
            Console.WriteLine("otlp running");
            var serviceName = "<signoz_service_name>";
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(serviceName)
                .SetResourceBuilder(
                ResourceBuilder.CreateDefault().AddService(serviceName))
                .AddOtlpExporter(opt =>
                                 {
                                     opt.Endpoint = new Uri("<signoz_endpoint>");
                                     opt.Protocol = OtlpExportProtocol.Grpc;
                                     opt.Headers = "signoz-access-token=<signoz_ingestion_key>";
                                 })
                .AddConsoleExporter()
                .Build();
            for(int i = 0; i<10; i++)
            {
                var MyActivitySource = new ActivitySource(serviceName);
                using var activity = MyActivitySource.StartActivity("SayHello");
                activity?.SetTag("bar", "Hello World");
            }
        }
    }
}
