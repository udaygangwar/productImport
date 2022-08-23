using ProductImport.Database.IRepository;
using ProductImport.Model;
using System.Collections.Generic;

namespace ProductImportTestCases.Stub
{
    class FakeSoftwareAdviceRepository : ISoftwareAdviceRepository
    {
        public bool AddProduct(List<SoftwareAdviceModel> product)
        {
            if (product == null)
                return false;
            else
                return true;
        }
    }
}
