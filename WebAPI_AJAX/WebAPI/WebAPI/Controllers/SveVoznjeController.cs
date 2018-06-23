using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SveVoznjeController : ApiController
    {
        public List<Voznja> Get()
        {
            return Voznje.SveVoznje;
        }
    }
}
