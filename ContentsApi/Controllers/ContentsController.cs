//using ContentsApi.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;

//namespace ContentsApi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    [Authorize]
//    public class ContentsController : ControllerBase
//    {
//        private readonly ILogger<ContentsController> _logger;

//        public ContentsController(ILogger<ContentsController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            try
//            {
//                string fileName = "Data/library.json";
//                string jsonString = System.IO.File.ReadAllText(fileName);

//                return Ok(JsonSerializer.Deserialize<Contents>(jsonString));
//            }
//            catch (Exception ex)
//            {
//                return Problem(ex.Message, string.Empty, 500, "Internal server error", "https://httpstatuses.com/500");
//            }
//        }
//    }
//}