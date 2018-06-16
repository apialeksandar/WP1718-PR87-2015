using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DispecerController : ApiController
    {
        public Dispecer Get()
        {
            return UlogovaniKorisnici.Dispecer;
        }
    }
}
