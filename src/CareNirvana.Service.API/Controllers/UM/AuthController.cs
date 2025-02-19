using CareNirvana.Service.Application.UseCases;
using CareNirvana.Service.Domain.Model;
using Microsoft.AspNetCore.Mvc;


namespace CareNirvana.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly GetAuthTemplatesQuery _getAuthTemplatesQuery;
        private readonly SaveAuthDetailCommand _saveAuthDetailCommand;

        public AuthController(GetAuthTemplatesQuery getAuthTemplatesQuery, SaveAuthDetailCommand saveAuthDetailCommand)
        {
            _getAuthTemplatesQuery = getAuthTemplatesQuery;
            _saveAuthDetailCommand = saveAuthDetailCommand;
        }

        [HttpGet("fetch")]
        public async Task<ActionResult<List<AuthTemplate>>> GetAuthTemplates()
        {
            var result = await _getAuthTemplatesQuery.ExecuteAsync();
            return Ok(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveAuthDetail([FromBody] string jsonData)
        {
            await _saveAuthDetailCommand.ExecuteAsync(jsonData);
            return Ok("Data saved successfully");
        }
    }
}

