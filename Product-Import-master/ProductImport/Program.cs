using Microsoft.Extensions.DependencyInjection;
using ProductImport.Database.IRepository;
using ProductImport.Database.Repository;
using ProductImport.Source.ISourceProvider;
using ProductImport.Source.SourceProvider;
using System;
using System.IO;
using System.Linq;

namespace ProductImport
{
    class Program
    {
        public static void Main(string[] args)
        {
            //setup our DI
            //register our db context as well here 
            //all this code will be in startup.cs in an actual app
            var serviceProvider = new ServiceCollection()
                .AddTransient<Capterra>()
                .AddTransient<SoftwareAdvice>()
                .AddTransient<ISoftwareAdviceRepository, SoftwareAdviceRepository>()
                .AddTransient<ICapterraRepository, CapterraRepository>()
                .BuildServiceProvider();
            Console.WriteLine("Please specify source and path the arguments seprated by a space");
            var arguments=Console.ReadLine();
            string[] abc = arguments.Split(' ');
            if (abc.Length < 2)
            {
                Console.WriteLine("Please specify all the arguments");
                return;
            }

            var source = abc[0];
            var path = Path.Combine("../../.././../feed-products/",abc[1]);

            //var source = "capterra";
            //var path = "../../.././../feed-products/capterra.yaml";

            //var source = "softwareadvice";
            //var path = "../../.././../feed-products/softwareadvice.json";

            if (source.ToLower().Equals("capterra"))
            {
                var serviceType = serviceProvider.GetService<Capterra>();
                var list = serviceType.ReadFile(path);
                serviceType.ImportData(list);
            }
            else if (source.ToLower().Equals("softwareadvice"))
            {
                var serviceType = serviceProvider.GetService<SoftwareAdvice>();
                var list = serviceType.ReadFile(path);
                serviceType.ImportData(list);
            }
            else
            {
                Console.WriteLine("Not a valid source");
                return;
            }
            Console.Read();
        }
    }
}
