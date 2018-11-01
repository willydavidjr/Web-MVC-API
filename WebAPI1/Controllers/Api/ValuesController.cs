using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI1.Models;

namespace WebAPI1.Controllers.Api
{
    public class ValuesController : ApiController
    {
        private static readonly List<Person> Persons;

        /*
            Set static to initialize readonly variable for one run once only. 
            Static will initialize first before an instance is created regardless of how many instance.
        */
        static ValuesController()
        {
            Persons = new List<Person>();
            var random = new Random();
            for (var x = 0; x < 10; x++)
            {
                var item = new Person { ID = random.Next(1, 100) };
                item.Name = string.Format("Generated text {0}", item.ID);
                item.Age = item.ID;
                Persons.Add(item);
            }
        }

        //We add Response type to add support on HelpPage documentation for Web API.
        [ResponseType(typeof(Person))]
        public IHttpActionResult Get()
        {
            return Ok(Persons);
        }

        /*
            Custom method IHttpActionResult without any Verbs on method or attribute will not be called via Postman/Fiddler 
        */
        public IHttpActionResult DaWei()
        {
            return Ok(new Person(1, "DaWei object is called"));
        }

        //This will not be called since there should be a custom route via Controller scope
        [Route("mangla")]
        [HttpGet]
        public IHttpActionResult MangLa()
        {
            return Ok(new Person(1, "DaWei object is called"));
        }
    }

   
}
