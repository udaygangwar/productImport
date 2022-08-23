using ProductImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductImport.Source.ISourceProvider
{
    public interface IProduct<T>
    {
        public List<T> ReadFile(string path);
        public bool ImportData(List<T> model);
    }
}
