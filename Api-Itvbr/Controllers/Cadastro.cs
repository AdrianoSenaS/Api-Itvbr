﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Itvbr.Controllers
{
    [Route("api/[controller]")]
    public class Cadastro : Controller
    { 

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }
    }
}

