using BarragemMongoDb.Domain.Dtos;

namespace BarragemMongoDb.Domain.Pagination;

public record PaginationBarragemResult(PaginatedResult<BarragemDto> Barragens);
