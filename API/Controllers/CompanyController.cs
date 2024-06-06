using Application.Companies.Create;
using Application.Companies.Query.GetAllCompanies;
using Application.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompanyController : BaseApiController
    {
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetActivities([FromQuery] PagingParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { PageParams = param }));
        }

        [AllowAnonymous]
        [HttpPost] // company/id
        public async Task<ActionResult> CreateActivity(CreateCompanyCommand company)
        {
            return HandleResult(await Mediator.Send(new Create.Command { CreateCompanyCommand = company }));
        }
    }
}