var builder = DistributedApplication.CreateBuilder(args);

var mongo = builder.AddMongoDB("barragem")
                   .WithMongoExpress()
                   .WithDataVolume();

var mongodb = mongo.AddDatabase("barragemdb");

var api = builder.AddProject<Projects.BarragemMongoDb_Api>("barragemmongodb-api")
           .WithReference(mongodb)
           .WaitFor(mongodb);

builder.AddProject<Projects.BarragemMongoDb_Web>("barragemmongodb-web")
    .WithReference(api)
    .WaitFor(api);

builder.Build().Run();
