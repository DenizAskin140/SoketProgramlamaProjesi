using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    /// <summary>
    /// UnitTests için kısa açıklama
    /// </summary>
    [TestClass]
    public class UnitTests
    {
        public UnitTests()
        {
            //
            // TODO: Buraya oluşturucu mantığı ekleyin.
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Geçerli test çalışması hakkında bilgi ve bu testin işlevini
        ///sağlayan test bağlamını alır ya da ayarlar.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Ek test öznitelikleri
        //
        // Testlerinizi yazarken şu ek öznitelikleri kullanabilirsiniz:
        //
        // Sınıftaki ilk testi çalıştırmadan önce kodu çalıştırmak için ClassInitialize kullanın
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Sınıftaki tüm testler çalıştırıldıktan sonra kodu çalıştırmak için ClassCleanup kullanın
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Her bir testi çalıştırmadan önce kodu çalıştırmak için TestInitialize kullanın 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Her bir testi çalıştırdıktan sonra kodu çalıştırmak için TestCleanup kullanın
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            string metin = "Test Metni";
            string sifreli = AES.Encrypt(metin, "12345678");
            string cozulmus = AES.Decrypt(sifreli, "12345678");
            if (metin == cozulmus)
            {
                Debug.WriteLine("Passed");
            }
            else
            {
                Debug.WriteLine("Failed");
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            string metin = "Test Metni";
            string sifreli = AES.SHA256(metin);
            Debug.WriteLine(sifreli);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string metin = "";
            for (int i = 0; i < 100000; i++)
            {
                metin += "A";
            }
            string sifreli = AES.SHA256(metin);
            Debug.WriteLine(sifreli);
        }
        //Boş metin ile test
        [TestMethod]
        public void TestMethod4()
        {
            string metin = "";
            string sifreli = AES.Encrypt(metin, "12345678");
            Debug.WriteLine(sifreli);
        }
        //Boş anahtar ile test
        [TestMethod]
        public void TestMethod5()
        {
            string metin = "ABCDEFGHIJKLMN";
            string sifreli = AES.Encrypt(metin, "");
            Debug.WriteLine(sifreli);
        }
        //Semboller ile şifreleme
        [TestMethod]
        public void TestMethod6()
        {
            string metin = "_?=()(%^'+!'^½${½[#$½>£#";
            string sifreli = AES.Encrypt(metin, "123456789");
            Debug.WriteLine(sifreli);
        }
        //Byte Şifrelem
        [TestMethod]
        public void TestMethod7()
        {
            string metin = "ABCDEFGHIJKLMN";
            byte[] byteTest = Encoding.UTF8.GetBytes(metin);
            byte[] sifreliByte = AES.Encrypt(byteTest, "12345678");
            string sifreli = Encoding.UTF8.GetString(sifreliByte);
            Debug.WriteLine(sifreli);
        }
        //Byte şifreleme - Boş anahtar ile
        [TestMethod]
        public void TestMethod8()
        {
            string metin = "ABCDEFGHIJKLMN";
            byte[] byteTest = Encoding.UTF8.GetBytes(metin);
            byte[] sifreliByte = AES.Encrypt(byteTest, "");
            string sifreli = Encoding.UTF8.GetString(sifreliByte);
            Debug.WriteLine(sifreli);
        }
        //Boş byte dizisi şifreleme
        [TestMethod]
        public void TestMethod9()
        {
            AES.Encrypt(new byte[1], "12345678");
        }
    }
}
