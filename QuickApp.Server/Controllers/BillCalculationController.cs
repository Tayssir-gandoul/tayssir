using Microsoft.AspNetCore.Mvc;
using QuickApp.Core.Models.Shop;
using QuickApp.Core.Services.Shop.Interfaces;
using System.Threading.Tasks;

namespace QuickApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillCalculationController : ControllerBase
    {
        private readonly IBillCalculationService _billCalculationService;

        public BillCalculationController(IBillCalculationService billCalculationService)
        {
            _billCalculationService = billCalculationService;
        }

        [HttpPost("calculate")]
        public ActionResult<BillCalculationResult> CalculateBill([FromBody] BillCalculationModel model, int count)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid model.");
            }

            var result = _billCalculationService.BillCalculation(model, count);
            if (result == null)
            {
                return BadRequest("No active counters found or calculation error occurred.");
            }
            return Ok(result);
        }
    }
}
