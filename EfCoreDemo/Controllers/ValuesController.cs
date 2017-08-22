using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDemo.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EfCoreDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DemoContext _demoContext;

        public ValuesController(DemoContext context)
        {
            _demoContext = context ?? throw new ArgumentNullException(nameof(context));
            ((DbContext)context).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }



        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _demoContext.Accounts.ToList();
            _demoContext.Accounts.ToList();
            _demoContext.Accounts.ToList();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            _demoContext.Accounts.ToList();
            _demoContext.Accounts.ToList();
            _demoContext.Accounts.ToList();
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
