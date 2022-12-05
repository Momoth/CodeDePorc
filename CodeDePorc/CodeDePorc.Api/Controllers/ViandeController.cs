using CodeDePorc.Api.Business;
using Microsoft.AspNetCore.Mvc;

namespace CodeDePorc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViandeController : ControllerBase
    {
        private readonly ILogger<ViandeController> _logger;

        public ViandeController(ILogger<ViandeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Viande> PurgeViandes()
        {
            var manager = new ViandeManager();
            var result = manager.PurgeViandeHalam();
            return result.ToArray();
     
        }
    }


}