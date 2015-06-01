using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testovoe;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorTest()
        {
            OpenFile openfile = new OpenFile();
            Assert.IsNotNull(openfile);
            Assert.AreEqual("", openfile.Fpath);
        }
    }
}
