using BarragemMongoDb.Domain.Pagination;
using BarragemMongoDb.Domain.Services;
using MediatR;

namespace BarragemMongoDb.Application.Barragem.Queries;

public class GetAllQuery(PaginationRequest request) : IRequest<PaginationBarragemResult>
{
    public PaginationRequest Request { get; } = request;

    public class GetAllQueryHandler(IBarragemService barragemService) : IRequestHandler<GetAllQuery, PaginationBarragemResult>
    {
        public async Task<PaginationBarragemResult> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await barragemService.GetAllAsync(request.Request, cancellationToken);
        }
    }
}
