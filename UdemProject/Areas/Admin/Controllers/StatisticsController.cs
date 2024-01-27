using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UdemProject.Areas.Admin.Controllers
{
    [Route("api/Statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<StatisticItem>> GetStatistics()
        {
            var statistics = new List<StatisticItem>
            {
                new StatisticItem { Product = "18+ Book", Views = 12 },
                new StatisticItem { Product = "Classics Book", Views = 19 },
                new StatisticItem { Product = "Comic Book", Views = 3 },
                new StatisticItem { Product = "Detective Book", Views = 5 },
                new StatisticItem { Product = "Fantasy Book", Views = 2 },
                new StatisticItem { Product = "Historical Book", Views = 3 }
            };

            return Ok(new { data = statistics });
        }
    }

    public class StatisticItem
    {
        public string Product { get; set; }
        public int Views { get; set; }
    }
}