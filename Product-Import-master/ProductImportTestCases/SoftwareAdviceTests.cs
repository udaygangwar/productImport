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
    public class SoftwareAdviceTests
    {
        private SoftwareAdvice _softwareAdviceSource;

        [SetUp]
        public void Setup()
        {
            _softwareAdviceSource = new SoftwareAdvice(new FakeSoftwareAdviceRepository());
        }

        [TestCase("../../.././../feed-products/softwareadvice1.json")]
        public void FileNotFound_ReturnError(string path)
        {
            Assert.Throws<FileNotFoundException>(() => _softwareAdviceSource.ReadFile(path));
        }

        [TestCase("")]
        public void EmptyPath_ReturnError(string path)
        {
            Assert.Throws<ArgumentException>(() => _softwareAdviceSource.ReadFile(path));
        }

        [TestCase("../../.././../feed-products/softwareadvice.json")]
        public void DataIsNotEmpty_ReturnData(string path)
        {
            var result = _softwareAdviceSource.ReadFile(path);
            Assert.That(result, Is.Not.Empty);
        }

        [TestCase(null)]
        public void NullModel_ReturnFalse(List<SoftwareAdviceModel> model)
        {
            var result = _softwareAdviceSource.ImportData(model);
            Assert.IsFalse(result);
        }

        [Test]
        public void Model_ReturnTrue()
        {
            var model = MockLists.MockSoftwareAdviceData();
            var result = _softwareAdviceSource.ImportData(model);
            Assert.IsTrue(result);
        }
    }
}