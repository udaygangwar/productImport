using ProductImport.Database.Context;
using ProductImport.Database.IRepository;
using ProductImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductImport.Database.Repository
{
    public class CapterraRepository : ICapterraRepository
    {
        //private readonly MySqlContext _mySqlContext;

        //public CapterraRepository(MySqlContext mySqlContext)
        //{
        //    _mySqlContext = mySqlContext;
        //}

        public bool AddProduct(List<CapterraModel> product)
        {
            if (product == null)
                return false;
            else
            {
                foreach (var item in product)
                {
                    Console.WriteLine("Importing:");
                    Console.WriteLine($"Name: {item.Name}");
                    Console.WriteLine($"Tags: {item.Tags}");
                    Console.WriteLine($"Twitter: {item.Twitter}");
                    Console.WriteLine();
                }
                return true;
            }
        }
    }
}
