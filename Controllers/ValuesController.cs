using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using webapi1.ViewModel;
//using webapi1.Models;

namespace webapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOptionsSnapshot<AppSettings> options;
        private readonly ILogger logger;
        public ValuesController(IOptionsSnapshot<AppSettings> options, ILogger<ValuesController> logger)
        {
            this.logger = logger;
            this.options = options;
        }

        [HttpGet("")]
        public ActionResult<AppSettings> GetAppSetting()
        {
            // logger.LogDebug(10000, $"SiteName = {options.Value.SiteName}, SiteId = {options.Value.SiteId}");
            logger.LogDebug(10000, "SiteName = {SiteName}, SiteId = {SiteId}",
                                    options.Value.SiteName,
                                    options.Value.SiteId);
            return options.Value;
        }

    }
}