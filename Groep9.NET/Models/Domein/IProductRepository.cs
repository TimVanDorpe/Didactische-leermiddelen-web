using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groep9.NET.Models.Domein {
    public interface IProductRepository
    {

        

        IQueryable<Product> VindAlleProducten();

        void Add(Product product);
        void Delete(Product product);
        Product FindByProductNummer(int productnummer);
    }
}
