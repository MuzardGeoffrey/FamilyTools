var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("FamilyTools")
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("easycompta");

var apiService = builder
    .AddProject<Projects.FamilyTools_EasyCompta>(name: "EasyComptaAPI")
    .WithReference(sql)
    .WaitFor(sql)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.AddNpmApp("webfrontend", "../FamilyTools.Web")
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
