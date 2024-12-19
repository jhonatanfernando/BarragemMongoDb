using BarragemMongoDb.Application.Barragem.Commands;
using BarragemMongoDb.Application.Barragem.Queries;
using BarragemMongoDb.Domain.Dtos;
using BarragemMongoDb.Domain.Pagination;
using Carter;
using MediatR;

namespace BarragemMongoDb.Api.Endpoints;

public class BarragemEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/barragem/import", async (IFormFile file, ISender sender) =>
        {
            // Check if the request contains a file
            if (file == null || file.Length == 0)
            {
                return Results.BadRequest("No file provided.");
            }

            // Use the BarragemCsvReader to read and parse the file
            using var stream = file.OpenReadStream();

            await sender.Send(new ImportDataCommand(stream));

            return Results.NoContent();
        })
        .WithTags("barragem-controller")
        .Accepts<IFormFile>("multipart/form-data")
        .Produces(StatusCodes.Status204NoContent)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .DisableAntiforgery();

        app.MapGet("/barragem", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var barragens = await sender.Send(new GetAllQuery(request));

            return Results.Ok(barragens);
        })
        .WithTags("barragem-controller")
        .Produces<BarragemDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapGet("/barragem/anm", async (ISender sender) =>
        {
            var barragens = await sender.Send(new GetANMQuery());

            return Results.Ok(barragens);
        })
        .WithTags("barragem-controller")
        .Produces<BarragemDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
