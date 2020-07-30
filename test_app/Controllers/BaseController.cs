using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_app.Controllers
{    
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        public BaseController()
        { 
        }    
    }
}
