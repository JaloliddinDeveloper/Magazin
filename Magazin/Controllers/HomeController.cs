﻿using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Magazin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : RESTFulController
    {
       public ActionResult<string> Get()=>
            Ok("Hello,Mario.");
    }
}