using BarragemMongoDb.Domain.Entities;

namespace BarragemMongoDb.Domain.Repositories;

public interface IBarragemRepository
{
    Task CreateAsync(List<Barragem> barragens, CancellationToken cancellationToken = default);
    Task<(long, List<Barragem>)> GetAllAsync(int pageIndex = 0, int pageSize = 10, CancellationToken cancellationToken = default);
    Task<List<Barragem>> GetANMBarragensAsync(CancellationToken cancellationToken = default);
}
