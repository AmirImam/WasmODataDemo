using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WasmODataDemo.Entities;

namespace WasmODataDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<Product>> Get()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetFromJsonAsync<Product[]>("https://localhost:7208/MOCK_DATA.json");
            return result;
        }
    }
}
