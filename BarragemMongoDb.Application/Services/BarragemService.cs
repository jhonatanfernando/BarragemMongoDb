using BarragemMongoDb.Application.Map;
using BarragemMongoDb.Domain.Dtos;
using BarragemMongoDb.Domain.Pagination;
using BarragemMongoDb.Domain.Repositories;
using BarragemMongoDb.Domain.Services;
using CsvHelper;
using CsvHelper.Configuration;
using Mapster;
using System.Globalization;
using System.Text;

namespace BarragemMongoDb.Application.Services;

public class BarragemService(IBarragemRepository barragemRepository) : IBarragemService
{
    public async Task ImportDataAsync(Stream fileStream, CancellationToken cancellationToken = default)
    {
        var barragenEntities = ReadBarragens(fileStream);

       await barragemRepository.CreateAsync(barragenEntities, cancellationToken);
    }

    public async Task<PaginationBarragemResult> GetAllAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default)
    {
        var pageIndex = paginationRequest.PageIndex;
        var pageSize = paginationRequest.PageSize;

        var (totalCount, data) = await barragemRepository.GetAllAsync(pageIndex, pageSize, cancellationToken);

        return new PaginationBarragemResult(
           new PaginatedResult<BarragemDto>(
               pageIndex,
               pageSize,
               totalCount,
               data.Adapt<List<BarragemDto>>()));
    }

    public async Task<List<BarragemDto>> GetANMBarragensAsync(CancellationToken cancellationToken = default)
    {
        var results = await barragemRepository.GetANMBarragensAsync(cancellationToken);

        return results.Adapt<List<BarragemDto>>();
    }

    private List<Domain.Entities.Barragem> ReadBarragens(Stream csvStream)
    {
        // Assuming the CSV is encoded in UTF-8
        using var reader = new StreamReader(csvStream, Encoding.GetEncoding("ISO-8859-1"));
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = true,
            MissingFieldFound = null,
            BadDataFound = null
        };

        using var csv = new CsvReader(reader, config);

        // Skip the first two lines manually
        csv.Read();
        csv.Read();
        csv.Read();

        csv.ReadHeader();

        csv.Context.RegisterClassMap<BarragemMap>();

        return csv.GetRecords<Domain.Entities.Barragem>().ToList();
    }
}
