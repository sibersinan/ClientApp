using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // İstemci soketi oluştur
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Türkiye'deki bilgisayarın dış IP adresi ve port numarası
                IPAddress ipAddress = IPAddress.Parse(textBox1.Text);//"78.177.127.209"
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12345);

                // Sunucuya bağlan
                clientSocket.Connect(remoteEP);

                // Veri gönder
                string message = "Merhaba, bu bir test mesajıdır.";
                byte[] data = Encoding.ASCII.GetBytes(message);
                clientSocket.Send(data);

                // Soketi kapat
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

                MessageBox.Show("Mesaj başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
