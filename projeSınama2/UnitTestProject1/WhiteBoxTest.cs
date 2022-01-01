using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    /// <summary>
    /// WhiteBoxTest için kısa açıklama
    /// </summary>
    [TestClass]
    public class WhiteBoxTest
    {
        public WhiteBoxTest()
        {
            //
            // TODO: Buraya oluşturucu mantığı ekleyin.
            //
        }

        private TestContext testContextInstance;
        IPHostEntry ip = Dns.GetHostByName(Dns.GetHostName());
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        //#1 Bağlanma Testi

        [TestMethod]
        public void TestMethod1()
        {
            Socket socket = new Socket
             (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Bağlantı için kullanacağımız socketi oluşturuyoruz
            try //Bağlanamama durumuna karşı try catch kullanıyoruz.
            {
                string icerik = AES.Encrypt("TEST MESAJI", "12345678");
                string ipAdresi = ip.AddressList[0].ToString();
                if (ipAdresi.Contains("192") == false)
                {
                    ipAdresi = ip.AddressList[1].ToString();
                }
                socket.Connect(new IPEndPoint(IPAddress.Parse(ipAdresi), 5000));
                byte[] metinbyte = Encoding.UTF8.GetBytes(icerik);
                socket.Send(metinbyte);
                socket.Close();
            }
            catch (Exception)
            {

            }
        }
        //Çok sayıda mesaj şifreleme ve çözme (AES)
        [TestMethod]
        public void TestMethod2()
        {
            string metin = "TEST", sifreli;
            for (int i = 0; i < 1000; i++)
            {
                sifreli = AES.Encrypt(metin, "12345678");
                metin = AES.Decrypt(sifreli, "12345678");
            }
        }
        //Çok sayıda mesaj şifreleme (SHA256)
        [TestMethod]
        public void TestMethod3()
        {
            string metin = "TEST", sifreli;
            for (int i = 0; i < 1000; i++)
            {
                sifreli = AES.SHA256(metin);
            }
        }
        //Byte dizilerini üst üste şifreleme ve çözme
        [TestMethod]
        public void TestMethod4()
        {
            string sifreli = "TEST";
            byte[] byteTest = Encoding.UTF8.GetBytes(sifreli);
            for (int i = 0; i < 1000; i++)
            {
                byteTest = AES.Encrypt(byteTest, "12345678");
            }
        }
        //SHA256 ile üst üste şifreleme
        [TestMethod]
        public void TestMethod5()
        {
            string sifreli = "TEST";
            for (int i = 0; i < 1000; i++)
            {
                sifreli = AES.SHA256(sifreli);
            }
        }
    }
}
