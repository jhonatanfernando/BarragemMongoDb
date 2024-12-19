using BarragemMongoDb.Domain.Pagination;
using BarragemMongoDb.Web.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace BarragemMongoDb.Web.Controller;

[Route("api/[controller]")]
[ApiController]
public class BarragemController(BarragemApiClient barragemApiClient) : ControllerBase
{

    [HttpGet("")]
    public async Task<object> Index()
    {
        var queryString = Request.Query;

        int skip = (queryString.TryGetValue("$skip", out StringValues Skip)) ? Convert.ToInt32(Skip[0]) : 0;
        int top = (queryString.TryGetValue("$top", out StringValues Take)) ? Convert.ToInt32(Take[0]) : 1000;

        var data = await barragemApiClient.GetAllAsync(new PaginationRequest(skip, top));
        var barragens = data.Barragens.Data;

        var count = data.Barragens.Count;
        return new { Items = barragens, Count = count };
    }
}
