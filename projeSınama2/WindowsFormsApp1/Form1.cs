using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ArrayList soketler;
        int port, karsiport;
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tbDosya.Text = openFileDialog1.FileName; //Dosya seçiminde kullanmak üzere openfiledialog kullanıyoruz 
            //Ve dosya konumu ile adını Textboxumuza aktarıyoruz.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Socket socket = new Socket
             (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Bağlantı için kullanacağımız socketi oluşturuyoruz
            try //Bağlanamama durumuna karşı try catch kullanıyoruz.
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse(tbHedef.Text), karsiport));
                Stream dosya = File.OpenRead(tbDosya.Text); //Gönderilecek dosyayı programa tanıtıyoruz
                byte[] dosyabyte = new byte[dosya.Length]; //Dosyayı ağ üzerinden gönderebilmek için byte'a dönüştürüyoruz.
                dosya.Read(dosyabyte, 0, (int)dosya.Length); //Stream'e dosyayı byte olarak tekrar tanıtıyoruz.
                socket.Send(dosyabyte); //ve socket yardımı ile dosyayı gönderiyoruz.
                socket.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlanırken Bir Hata Oluştu.");
            }
        }
        public void dinleyiciTh()
        {
            TcpListener tcpdinleyici = new TcpListener(port); //TCP Dinleyicisi tanımlayıp portunu  belirliyoruz.
            tcpdinleyici.Start(); //TCP Dineylcisini başlatıyoruz.
            while (true) //Sürekli dosya alabilmek için açık bir while döngüsü bırakıyoruz
            {
                Socket socket = tcpdinleyici.AcceptSocket(); //Alıcı socket için TCP dinleyicisini socketimizle eşliyoruz. Yani client'ten aldığımız socket verisini eşliyoruz.
                if (socket.Connected) //Eğer bağlantı başarılı ise;
                {
                    Control.CheckForIllegalCrossThreadCalls = false; //Erişim hatası çıkmaması için bu kodu kullanıyoruz.
                    lbDurum.Items.Add(
                    socket.RemoteEndPoint.ToString() + " bağlandı."); //Client IP'sini Listboxa ekliyoruz.
                    lock (this)
                    {
                        soketler.Add(socket); //Soket listemize client
                    }
                    ThreadStart VeriYazma = new ThreadStart(VeriYaz); //Alınan veriyi bilgisayara yazmak için iş parçacığı oluşturuyoruz
                    Thread VeriYazmabaslat = new Thread(VeriYazma);
                    VeriYazmabaslat.Start();
                }
            }
        }
        public void VeriYaz() //Bilgisayara veri yazmak için kullanacağımız method
        {
            Socket socket = (Socket)soketler[soketler.Count - 1];
            NetworkStream networkStream = new NetworkStream(socket);  //Ağımızı programa tanıtıyoruz ve clientten gelen socket verisine eşliyoruz
            int okuma = 0;
            int byteBoyutu = 1024;
            byte[] veriByte = new byte[byteBoyutu]; //Dosyayı atayacağımız byte'ı belirliyoruz
            lock (this)
            {
                MemoryStream ms = new MemoryStream();
                while ((byteBoyutu = networkStream.Read(veriByte, 0, veriByte.Length)) > 0)
                {
                    ms.Write(veriByte, 0, byteBoyutu);
                }
                string sonuc = "";
                while (true)
                {
                    sonuc = Encoding.UTF8.GetString(ms.ToArray());
                    if (sonuc.StartsWith("MESAJ"))
                    {
                        string[] veri = sonuc.Split(',');
                        string algoritma = veri[1];
                        string anahtar = veri[2];
                        string icerik;
                        if (algoritma == "AES")
                        {
                            icerik = AES.Decrypt(veri[3], anahtar);
                        }
                        else
                        {
                            icerik = AES.SHA256(veri[3]);
                        }
                        lbDurum.Items.Add(algoritma + " ile mesaj alındı");
                        alinanMesaj.Text = icerik;
                        break;
                    }
                    else
                    {
                        File.WriteAllText(lblKayit.Text, sonuc);
                    }
                    if (okuma == 0) break; //Okuma durumu bitti ise döngüdne çıkıyoruz
                }
                if (sonuc.StartsWith("MESAJ") == false)
                {
                    lbDurum.Items.Add("Dosya Alındı."); //Listboxa dosyanın alındığını yazıyoruz;
                }
                networkStream.Close();
                socket = null; //Tekrar dosya alabilmek için socketi null yapıyoruz.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                port = int.Parse(cbPort.Items[0].ToString()); //Portumuzu belirliyoruz
                karsiport = int.Parse(cbPort.Items[1].ToString()); //Portumuzu belirliyoruz
                TcpListener tcpdinleyici = new TcpListener(port); //TCP Dinleyicisi tanımlayıp portunu  belirliyoruz.
                tcpdinleyici.Start(); //TCP Dineylcisini başlatıyoruz.
                tcpdinleyici.Stop();
                cbPort.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                port = int.Parse(cbPort.Items[1].ToString()); //Portumuzu belirliyoruz
                karsiport = int.Parse(cbPort.Items[0].ToString()); //Portumuzu belirliyoruz
                cbPort.SelectedIndex = 1;
            }
            IPHostEntry ip = Dns.GetHostByName(Dns.GetHostName());//Bilgisayarın ip adresini alıyoruz
            if (ip.AddressList[0].ToString().Contains("192") == false)
            {
                tbHedef.Text = ip.AddressList[1].ToString();
                label4.Text = " IP: " + ip.AddressList[1].ToString(); //Ve ekrana yazıyoruz
            }
            else
            {
                tbHedef.Text = ip.AddressList[0].ToString();
                label4.Text = " IP: " + ip.AddressList[0].ToString(); //Ve ekrana yazıyoruz
            }
            soketler = new ArrayList();
            Thread dinlieyiciThread = new Thread(new ThreadStart(dinleyiciTh)); //Dinleme işlemini TCP dinleyicisi ile bağlıyoruz.
            dinlieyiciThread.Start();//Form başladığında sürekli clienti dinlemesi için dinleme işlemi başlatıyoruz
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            lblKayit.Text = saveFileDialog1.FileName; //Dosya seçiminde kullanmak üzere savefiledialog kullanıyoruz 
                                                      //Ve dosya konumu ile adını Textboxumuza aktarıyoruz.
        }
        string rastgeleAnahtar()
        {
            Random rnd = new Random();
            string str = "";
            for (int i = 0; i < 8; i++)
            {
                if (rnd.Next(0, 2) == 0)
                {
                    str += (rnd.Next(0, 10).ToString());
                }
                else
                {
                    str += (char)(rnd.Next(65, 91));
                }
            }
            return str;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Socket socket = new Socket
             (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Bağlantı için kullanacağımız socketi oluşturuyoruz
            try //Bağlanamama durumuna karşı try catch kullanıyoruz.
            {
                string icerik = "MESAJ,", anahtar = rastgeleAnahtar();
                icerik += rbAes.Checked ? "AES" : "SHA";
                icerik += "," + anahtar + ",";
                if (rbAes.Checked)
                {
                    icerik += AES.Encrypt(gonderilecekMesaj.Text, anahtar);
                }
                else
                {
                    icerik += AES.SHA256(gonderilecekMesaj.Text);
                }
                socket.Connect(new IPEndPoint(IPAddress.Parse(tbHedef.Text), karsiport));
                byte[] metinbyte = Encoding.UTF8.GetBytes(icerik);
                socket.Send(metinbyte); //ve socket yardımı ile dosyayı gönderiyoruz.
                socket.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlanırken Bir Hata Oluştu.");
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
