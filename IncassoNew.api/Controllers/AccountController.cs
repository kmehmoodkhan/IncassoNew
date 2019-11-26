using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security.OAuth;

namespace IncassoNew.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

    }
}