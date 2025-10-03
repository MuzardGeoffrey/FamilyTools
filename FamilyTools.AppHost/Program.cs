var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("FamilyTools", port: 14329)
    .WithEndpoint(name: "sqlEndpoint", targetPort: 14330)
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("easycompta");

var migration = builder.AddProject<Projects.FamilyTools_MigrationService>("migrations")
    .WithReference(sql)
        .WaitFor(sql);

var easyComptaAPI = builder
    .AddProject<Projects.FamilyTools_EasyCompta>(name: "EasyComptaAPI")
    .WithReference(migration)
    .WaitFor(migration)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.AddNpmApp("webfrontend", "../FamilyTools.Web")
    .WithReference(easyComptaAPI)
    .WaitFor(easyComptaAPI)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
