using BarragemMongoDb.Domain.Dtos;
using BarragemMongoDb.Domain.Pagination;

namespace BarragemMongoDb.Domain.Services;

public interface IBarragemService
{
    Task<PaginationBarragemResult> GetAllAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
    Task<List<BarragemDto>> GetANMBarragensAsync(CancellationToken cancellationToken = default);
    Task ImportDataAsync(Stream fileStream, CancellationToken cancellationToken = default);
}
