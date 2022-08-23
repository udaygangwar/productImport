using ProductImport.Database.IRepository;
using ProductImport.Model;
using System.Collections.Generic;

namespace ProductImportTestCases.Stub
{
    class FakeCapterraRepository : ICapterraRepository
    {
        public bool AddProduct(List<CapterraModel> product)
        {
            if (product == null)
                return false;
            else
                return true;
        }
    }
}
