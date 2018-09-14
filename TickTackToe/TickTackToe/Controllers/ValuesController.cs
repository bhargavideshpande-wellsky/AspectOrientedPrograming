using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TickTackToe.Model;
using TickTackToe.Database;
using TickTackToe.DatabaseLayer;

namespace TickTackToe.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        // POST api/values
        [HttpPost]
        [Log]
        public string Post([FromBody]UserDetails user)
        {
            IRepository obj = new SqlRepository();
            string response= obj.AddData(user);
            if (response == "")
            {
                throw new Exception("User Already Exists!");
            }
            else
            {
                return response;
            }
           
        }

        
    }
}
