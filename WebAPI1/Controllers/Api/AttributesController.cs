using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Models;

namespace WebAPI1.Controllers.Api
{
    /*
        Attributes are cleaner way approach if you have multiple get method names
        More info: https://stackoverflow.com/questions/9499794/single-controller-with-multiple-get-methods-in-asp-net-web-api
    */
    [RoutePrefix("api/custom")]
    public class AttributesController : ApiController
    {
        /*
            This route empty is required if you set your route to custom 
            Setting route to custom should be on controller block using RoutePrefix
            This will disregard the IHttpActionResult method name and will prioritize Route and Accept verbs
        */
        [Route("")]

        public IHttpActionResult Get()
        {
            return Ok(new Person() { ID = 1, Name = "Attribute name called for Get." });
        }

        //Adding a word foo will call: http://localhost:58681/api/custom/foo
        [Route("foo")]
        [HttpDelete]
        public IHttpActionResult Caller()
        {
            return Ok(new Person(1, "Object deleted called"));
        }

        [HttpDelete]
        public IHttpActionResult CallerDel()
        {
            return Ok(new Person(1, "Object CallerDel deleted called"));
        }

    }
}
