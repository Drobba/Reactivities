using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //"controller" är en placeholder som byts ut mot något annat när det används. Får vi in api/activities byts den och vi når controller i activity
    public class BaseApiController : ControllerBase
    {
        
    }
}