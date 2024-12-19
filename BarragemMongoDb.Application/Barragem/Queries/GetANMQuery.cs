using BarragemMongoDb.Domain.Dtos;
using BarragemMongoDb.Domain.Services;
using MediatR;

namespace BarragemMongoDb.Application.Barragem.Queries;

public class GetANMQuery: IRequest<List<BarragemDto>>
{
    public class GetANMQueryHandler(IBarragemService barragemService) : IRequestHandler<GetANMQuery, List<BarragemDto>>
    {
        public async Task<List<BarragemDto>> Handle(GetANMQuery request, CancellationToken cancellationToken)
        {
            return await barragemService.GetANMBarragensAsync(cancellationToken);
        }
    }
}
