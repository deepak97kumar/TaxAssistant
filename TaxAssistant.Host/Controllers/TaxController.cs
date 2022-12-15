using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaxAssistant.Calculator.Interfaces;
using TaxAssistant.Repository.Models;

namespace TaxAssistant.Host.Controllers
{
    [Route("api/controller/Tax")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxCalculator _taxCalculator;

        public TaxController(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string municipalityName, DateTime onDate)
        {
            var tax = await _taxCalculator.GetTax(municipalityName, onDate);

            return tax == null ? TaxScheduleNotFound(municipalityName, onDate)
                : Ok(tax.Value);
        }

        private IActionResult TaxScheduleNotFound(string municipalityName, DateTime onDate)
        {
            return NotFound($"Tax schedule for [{municipalityName}] is not found on [{onDate}]");
        }

        [HttpPost]
        public async Task<IActionResult> AddTax([FromBody] Tax value)
        {
            try
            {
                await _taxCalculator.AddNewTax(value);
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

    }
}


