using FamilyTools.MigrationService;
using FamilyTools.Data.Context;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddSqlServerDbContext<EasyComptaContext>("easycompta");

var host = builder.Build();
host.Run();
