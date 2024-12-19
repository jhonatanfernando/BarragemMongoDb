using BarragemMongoDb.Domain.Services;
using MediatR;

namespace BarragemMongoDb.Application.Barragem.Commands;

public class ImportDataCommand(Stream fileStream) : IRequest<Unit>
{
    private readonly Stream fileStream = fileStream;

    public class ImportDataCommandHandler(IBarragemService barragemService) : IRequestHandler<ImportDataCommand, Unit>
    {
        private readonly IBarragemService barragemService = barragemService;

        public async Task<Unit> Handle(ImportDataCommand request, CancellationToken cancellationToken)
        {
            await barragemService.ImportDataAsync(request.fileStream, cancellationToken);

            return Unit.Value;
        }
    }
}
