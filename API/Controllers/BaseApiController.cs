using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /*
        ApiController attribute:
            - has a lot of logic under the hood for us, and one is PARAMETER VALIDATION
            - [HttpGet("{id}")] <--- if we pass string as a parameter here, it will throw
              a BadRequest error
    */
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}