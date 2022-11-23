using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using org.mariuszgromada.math.mxparser;

namespace Wep_lommeregner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lommregner : ControllerBase
    {
        [HttpPost(Name = "Calculate2")]
        public string Post(string regnestykke)
        {
            Expression exp = new Expression(regnestykke);
            var value = exp.calculate();
            return value.ToString();
        }
    }
}
