using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuWay;

namespace NuWayUnitTestProject
{
    /// <summary>
    /// Summary description for Cryptography
    /// </summary>
    [TestClass]
    public class Cryptography
    {
        [TestMethod]
        public void EncryptDecrypt()
        {
            En_De_cryption crypter = new En_De_cryption();
            Assert.AreEqual(crypter.DecryptString(crypter.EncryptString("hello world", "Kentucky"), "Kentucky"), "hello world", "Encrytption/Decryption Not Working.");
        }
    }
}
