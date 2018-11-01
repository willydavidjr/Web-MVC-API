using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI1.Controllers.Api
{
    public class ValuesController : ApiController
    {

        //We add Response type to add support on HelpPage documentation for Web API.
        [ResponseType(typeof(Person))]
        public IHttpActionResult Get()
        {
            return Ok(new Person() { ID = 1, Name = "Willy" });
        }
    }

    public class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
