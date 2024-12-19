using BarragemMongoDb.Domain;
using BarragemMongoDb.Domain.Dtos;
using BarragemMongoDb.Domain.Entities;
using BarragemMongoDb.Domain.Repositories;
using MongoDB.Driver;

namespace BarragemMongoDb.Data.Repositories
{  
    public class BarragemRepository : IBarragemRepository
    {
        private readonly IMongoCollection<Barragem> _collection;

        public BarragemRepository(IMongoClient mongoClient)
        {
            _collection = mongoClient.GetDatabase(Constants.MongoDB).GetCollection<Barragem>(Constants.BarragemCollection);
        }

        public async Task CreateAsync(List<Barragem> barragens, CancellationToken cancellationToken = default)
        {
            if (barragens.Count != 0)
            {
                await _collection.DeleteManyAsync(FilterDefinition<Barragem>.Empty, cancellationToken);

                await _collection.InsertManyAsync(barragens, new InsertManyOptions { IsOrdered = false }, cancellationToken);
            }
        }

        public async Task<(long, List<Barragem>)> GetAllAsync(int pageIndex = 0, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var totalCount = await _collection.Find(Builders<Barragem>.Filter.Empty).CountDocumentsAsync(cancellationToken);

            var barragens = await _collection
               .Find(Builders<Barragem>.Filter.Empty)
               .Skip(pageIndex)
               .Limit(pageSize)
               .ToListAsync(cancellationToken: cancellationToken);

            return (totalCount, barragens);
        }

        public async Task<List<Barragem>> GetANMBarragensAsync(CancellationToken cancellationToken = default)
        {
            var filter = Builders<Barragem>.Filter.Or(
                        Builders<Barragem>.Filter.Eq(b => b.OrgaoFiscalizador, "Agência Nacional de Mineração - ANM"),
                        Builders<Barragem>.Filter.Eq(b => b.OrgaoFiscalizador, "ANM"));

            return await _collection.Find(filter).ToListAsync(cancellationToken);
        }
    }
}
