using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AdneomTST.Models.Data;
using AdneomTST.Models.ViewModels;
using AdneomTST.Models.Repositories;
using System.Threading.Tasks;

namespace AdneomTST.Controllers
{
    public class CafeController : ApiController, IDisposable
    {
        private ICoffeeRepository coffeeRepository;

        public CafeController()
            : this(new CoffeeRepository())
         {}

        public CafeController(ICoffeeRepository coffeeRepository)
        {
            // we can use many container for implement IoC: Unity For example
            this.coffeeRepository = coffeeRepository;
        }

        [HttpPost]
        public IHttpActionResult PostCoffee(CoffeeModel cafe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            coffeeRepository.Add(cafe);

            return Ok(true);
        }


        [HttpGet]
        [Route("api/LastCafe/")]
        [ResponseType(typeof(CoffeeModel))]
        public IHttpActionResult GetLastCoffee()
        {
            var cafe = coffeeRepository.GetLast();
            if (cafe == null)
            {
                return NotFound();
            }

            return Ok(cafe);
        }

        [HttpGet]
        [Route("api/TypeCafe/")]
        public IList<TypeCoffeeModel> GetTypeCoffee()
        {
            return coffeeRepository.GetAllType();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                coffeeRepository.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}