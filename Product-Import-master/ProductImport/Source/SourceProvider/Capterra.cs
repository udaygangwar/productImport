using Newtonsoft.Json;
using ProductImport.Database.IRepository;
using ProductImport.Model;
using ProductImport.Source.ISourceProvider;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace ProductImport.Source.SourceProvider
{
    public class Capterra : IProduct<CapterraModel>
    {
        private readonly ICapterraRepository _iCapterraRepository;

        public Capterra(ICapterraRepository iCapterraRepository)
        {
            _iCapterraRepository = iCapterraRepository;
        }

        public List<CapterraModel> ReadFile(string path)
        {
            //Read File to string
            string yamlString = File.ReadAllText(path);
            //Text Write for serialize yaml object
            TextWriter jsonString = new StringWriter();

            var deserializer = new Deserializer();
            var yamlObject = deserializer.Deserialize(new StringReader(yamlString));

            var serializer = new JsonSerializer();
            //serialize yaml to string
            serializer.Serialize(jsonString, yamlObject);
            //deserialize yaml to json object
            var productData = JsonConvert.DeserializeObject<List<CapterraModel>>(jsonString.ToString());

            if (productData == null)
                return null;
            else
                return productData;
        }

        public bool ImportData(List<CapterraModel> model)
        {
            var result = _iCapterraRepository.AddProduct(model);

            return result;
        }
    }
}
