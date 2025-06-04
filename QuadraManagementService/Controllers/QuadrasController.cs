using Microsoft.AspNetCore.Mvc;
using QuadraManagementService.ApplicationServices;
using QuadraManagementService.ApplicationServices.Contracts;
using QuadraManagementService.Crosscutting.DTO;

namespace QuadraManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuadrasController : ControllerBase
    {
        private readonly IQuadrasApplicationServices _service;

        public QuadrasController(IQuadrasApplicationServices service)
        {
            _service = service;
        }

        [HttpGet("GetAllQuadras")]
        public async Task<ActionResult<List<QuadraDTO>>> GetAllQuadras()
        {
            try
            {
                var Pessoas = await _service.GetAllQuadras();

                return Ok(Pessoas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("CreateQuadra")]
        public async Task<ActionResult> CreateQuadra(QuadraDTO CreatePessoa)
        {
            try
            {
                await _service.CreateQuadra(CreatePessoa);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
