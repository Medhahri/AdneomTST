using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdneomTST.Models.Data;
using AdneomTST.Models.ViewModels;
using System.Threading.Tasks;


namespace AdneomTST.Models.Repositories
{
    public interface ICoffeeRepository: IDisposable
    {
        IQueryable<CoffeeModel> GetAll();
        CoffeeModel GetLast();
        void Add(CoffeeModel cafe);
        IList<TypeCoffeeModel> GetAllType();
    }
}