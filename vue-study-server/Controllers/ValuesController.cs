using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace vue_study_server.Controllers
{
    public class ValuesController : ApiController
    {
        public class Item
        {
            public int Id { get; set; }

            public string Value { get; set; }
        }

        protected static List<Item> _VDB = new List<Item>() 
        {
            new Item(){ Id = 1 , Value = "Value1"},
            new Item(){ Id = 2 , Value = "Value2"},
            new Item(){ Id = 3 , Value = "Value3"}
        };

        // GET api/values
        public IEnumerable<Item> Get()
        {
            return _VDB;
        }

        // GET api/values/5
        public Item Get(int id)
        {
            return _VDB.SingleOrDefault(x => x.Id == id);
        }

        // POST api/values
        public void Post([FromBody]Item input)
        {
            input.Id = (_VDB.Max(x => x.Id) + 1);
            _VDB.Add(input);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Item input)
        {
            var item = _VDB.Single(x => x.Id == id);
            item.Value = input.Value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _VDB.Remove(_VDB.Single(x => x.Id == id));
        }
    }
}
