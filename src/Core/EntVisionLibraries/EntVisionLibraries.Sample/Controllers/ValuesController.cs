using EntVisionLibraries.Sample.Models;
using EntVisionLibraries.Sample.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;

namespace EntVisionLibraries.Sample.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IMapsRepository _mapsRepository;
        public ValuesController(IMapsRepository mapsRepository)
        {
            _mapsRepository = mapsRepository;
        }
        // GET api/values
        public IEnumerable<Maps> Get()
        {
            var sample = new Maps
            {
                Id = Guid.NewGuid(),
                Title = "newww",
                Content = "Content",
                Latitude = "-33.727111",
                Longitude = "-33.727111"
            };

            using (var transaction = new TransactionScope())
            {
                _mapsRepository.Create(sample);
                _mapsRepository.Save();

                transaction.Complete();
            }

            var result = _mapsRepository.GetAll();
            return result.ToList();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
