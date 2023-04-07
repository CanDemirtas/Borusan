
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult> GetAllCategories()
        {
            return Ok("selamün aleyküm");
        }

    }
}
