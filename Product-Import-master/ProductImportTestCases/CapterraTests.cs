using NUnit.Framework;
using ProductImport.Model;
using ProductImport.Source.SourceProvider;
using ProductImportTestCases.MockData;
using ProductImportTestCases.Stub;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProductImportTestCases
{
    public class CapterraTests
    {
        private Capterra _capterraSource;

        [SetUp]
        public void Setup()
        {
            _capterraSource = new Capterra(new FakeCapterraRepository());
        }

        [TestCase("../../.././../feed-products/capterra1.yaml")]
        public void FileNotFound_ReturnError(string path)
        {
          Assert.Throws<FileNotFoundException>(() => _capterraSource.ReadFile(path));
        }

        [TestCase("")]
        public void EmptyPath_ReturnError(string path)
        {
            Assert.Throws<ArgumentException>(() => _capterraSource.ReadFile(path));
        }

        [TestCase("../../.././../feed-products/capterra.yaml")]
        public void DataIsNotEmpty_ReturnData(string path)
        {
            var result = _capterraSource.ReadFile(path);
            Assert.That(result, Is.Not.Empty);
        }

        [TestCase(null)]
        public void NullModel_ReturnFalse(List<CapterraModel> model)
        {
            var result = _capterraSource.ImportData(model);
            Assert.IsFalse(result);
        }

        [Test]
        public void Model_ReturnTrue()
        {
            var model = MockLists.MockCapterraData();
            var result = _capterraSource.ImportData(model);
            Assert.IsTrue(result);
        }
    }
}