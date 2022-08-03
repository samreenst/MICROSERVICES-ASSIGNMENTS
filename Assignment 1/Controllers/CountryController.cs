using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/country")]
    public class CountryController : ApiController
    {
        static List<Country> countrylist = new List<Country>()
        {
            new Country{Id=1, CountryName="India",Capital="Delhi"},
            new Country{Id=2, CountryName="Australia",Capital="Sydney"},
            new Country{Id=3, CountryName="France",Capital="Paris"},
            new Country{Id=4, CountryName="America",Capital="Washington DC"},
        };
        [HttpGet]
        [Route("countrydetails")]

        public IEnumerable<Country> Get()
        {
            return countrylist;
        }

        [HttpGet]
        [Route("countrylist")]

        public HttpResponseMessage GetCountryList()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countrylist);
            return response;
        }

        [HttpGet]
        [Route("p")]
        public HttpResponseMessage GetP(int pid)
        {
            var country = countrylist.Find(x => x.Id == pid);

            if (country == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, pid);
            }
            return Request.CreateResponse(HttpStatusCode.OK, country);
        }


        //Post

        public Country Post([FromBody] Country p)
        {
            countrylist.Add(p);
            return p;
        }

        //put
        public IEnumerable<Country> Put(int id, [FromBody] Country country)
        {
            countrylist[id - 1] = country;
            return countrylist;
        }

        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetID(int pid)
        {
            var country = countrylist.Find(x => x.Id == pid);

            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpGet]
        [Route("CountryName")]
        public IHttpActionResult GetName(int pid)
        {
            string country = countrylist.Where(x => x.Id == pid).SingleOrDefault()?.CountryName;

            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
            //return new MyResult(country, Request);


        }
    }
}