using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdneomTST.Models.Data;
using System.Data.Entity;
using AdneomTST.Models.ViewModels;
using System.Threading.Tasks;

namespace AdneomTST.Models.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        public CoffeeRepository()
        {
            
        }

        /// <summary>
        /// Get All Coffe
        /// </summary>
        /// <returns></returns>
        public IQueryable<CoffeeModel> GetAll()
        {
            // we use block "using" for disposing context automatically
            using (AdneomDBEntities1 context = new AdneomDBEntities1())
            {
                var Cafes = from b in context.Coffee
                                select new CoffeeModel()
                                {
                                    IdType = b.IdType,
                                    Sucre = b.Sucre,
                                    UseMug = b.UseMug
                                };

                return Cafes;

            }
        }

        /// <summary>
        /// Get Last Coffee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CoffeeModel GetLast()
        {
            using (AdneomDBEntities1 context = new AdneomDBEntities1())
            {
                var Cafe = context.Coffee.Include(b => b.TypeCoffee).Select(b =>
                            new CoffeeModel()
                            {
                                IdType = b.IdType,
                                Sucre = b.Sucre,
                                UseMug = b.UseMug,
                                TypeCaffee = b.TypeCoffee.TypeDescription
                            }).ToList().Last();

                return Cafe;

            }
        }

        /// <summary>
        /// Add Caffee
        /// </summary>
        /// <param name="coffee"></param>
        public void Add(CoffeeModel coffee)
        {
            try 
	        {	        
                using (AdneomDBEntities1 context = new AdneomDBEntities1())
                  {
                      Coffee cafe = new Coffee()
                        {
                            IdType = coffee.IdType,
                            Sucre = coffee.Sucre,
                            UseMug = coffee.UseMug
                        };
                        context.Coffee.Add(cafe);
                        context.SaveChanges();
                  }
	        }
	        catch (Exception)
	        {
		        throw;
	        }

        }

        /// <summary>
        /// Get All Type Coffee
        /// </summary>
        /// <returns></returns>
        public IList<TypeCoffeeModel> GetAllType()
        {
            using (AdneomDBEntities1 context = new AdneomDBEntities1())
            {
                var typeCafes = from b in context.TypeCoffee
                            select new TypeCoffeeModel()
                            {
                                Id = b.Id,
                                TypeDescription = b.TypeDescription
                            };

                return typeCafes.ToList();
            }
        }

        public void Dispose()
        {

        }
    }
}