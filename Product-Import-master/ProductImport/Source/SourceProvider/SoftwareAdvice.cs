using ProductImport.Database.IRepository;
using ProductImport.Model;
using ProductImport.Source.ISourceProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProductImport.Source.SourceProvider
{
    public class SoftwareAdvice : IProduct<SoftwareAdviceModel>
    {
        private readonly ISoftwareAdviceRepository _iSoftwareAdviceRepository;

        public SoftwareAdvice(ISoftwareAdviceRepository iSoftwareAdviceRepository)
        {
            _iSoftwareAdviceRepository = iSoftwareAdviceRepository;
        }

        public bool ImportData(List<SoftwareAdviceModel> model)
        {
            var result = _iSoftwareAdviceRepository.AddProduct(model);

            return result;
        }

        public List<SoftwareAdviceModel> ReadFile(string path)
        {
            string jsonString = File.ReadAllText(path);
            var productData = JsonSerializer.Deserialize<SoftwareAdviceModelList>(jsonString);

            if (productData == null)
                return null;
            else
                return productData.Products;
        }
    }
}
