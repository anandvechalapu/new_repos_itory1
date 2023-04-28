using newcom.DTO;
using newcom.Service;
using Microsoft.AspNetCore.Mvc;

namespace newcom.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GratuityCalculationController : ControllerBase
    {
        private readonly IGratuityCalculationService _gratuityCalculationService;

        public GratuityCalculationController(IGratuityCalculationService gratuityCalculationService)
        {
            _gratuityCalculationService = gratuityCalculationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGratuityCalculation([FromQuery] GratuityCalculationRequestDTO gratuityCalculationRequest)
        {
            var gratuityCalculationResponse = await _gratuityCalculationService.CalculateGratuityAsync(gratuityCalculationRequest);
            return Ok(gratuityCalculationResponse);
        }
    }
}