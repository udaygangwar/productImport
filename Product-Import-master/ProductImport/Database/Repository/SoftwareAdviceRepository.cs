using ProductImport.Database.Context;
using ProductImport.Database.IRepository;
using ProductImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductImport.Database.Repository
{
    public class SoftwareAdviceRepository : ISoftwareAdviceRepository
    {
        //private readonly MySqlContext _mySqlContext;

        //public SoftwareAdviceRepository(MySqlContext mySqlContext)
        //{
        //    _mySqlContext = mySqlContext;
        //}

        public bool AddProduct(List<SoftwareAdviceModel> product)
        {
            
            if (product == null)
                return false;
            else
            {
                foreach (var item in product)
                {
                    Console.WriteLine("Importing:");
                    Console.WriteLine($"Name: {item.Title}");
                    Console.WriteLine($"Categories: {String.Join(",", item.Categories)}");
                    Console.WriteLine($"Twitter: {item.Twitter}");
                    Console.WriteLine();
                }
                return true;
            }
        }
    }
}
