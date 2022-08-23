using ProductImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductImport.Database.IRepository
{
    public interface ISoftwareAdviceRepository
    {
        public bool AddProduct(List<SoftwareAdviceModel> product);
    }
}
