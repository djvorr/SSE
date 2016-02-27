using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuWay;

namespace CryptographicUnitTests
{
    [TestClass]
    public class CryptographicTests
    {
        [TestMethod]
        public void EncryptDecrypt()
        {
            En_De_cryption crypter = new En_De_cryption();
            Assert.AreEqual(crypter.DecryptString(crypter.EncryptString("hello world", "Kentucky"), "Kentucky"), "hello world", "Encrytption/Decryption Not Working.");
        }
    }
}
