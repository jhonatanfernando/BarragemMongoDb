using BarragemMongoDb.Domain.Dtos;
using BarragemMongoDb.Domain.Pagination;

namespace BarragemMongoDb.Web.ApiClient;

public class BarragemApiClient(HttpClient httpClient)
{
    public async Task<PaginationBarragemResult> GetAllAsync(PaginationRequest request)
    {
        var data = await httpClient.GetFromJsonAsync<PaginationBarragemResult>($"/barragem?PageIndex={request.PageIndex}&PageSize={request.PageSize}");

        return data;
    }

    public async Task<List<BarragemDto>> GetANMBarragensAsync()
    {
        var data = await httpClient.GetFromJsonAsync<List<BarragemDto>>($"/barragem/anm");

        return data;
    }
}
