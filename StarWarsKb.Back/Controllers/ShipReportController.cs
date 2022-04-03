using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StarWarsKb.Back.Model;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipReportController : ControllerBase
    {
        private readonly IReportGenerator _reportGenerator;

        public ShipReportController(IReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }
        
        [HttpGet]
        public IList<ReportEntity> Get()
        {
            return _reportGenerator.GetReport();
        }
    }
}