using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForma : Form
    {
        ServerKlasa server;
        public ServerForma()
        {
            InitializeComponent();
        }

        private void ServerForma_Load(object sender, EventArgs e)
        {
            Thread nitVreme = new Thread(PostaviVreme);
            nitVreme.IsBackground = true;
            nitVreme.Start();
        }

        public void PostaviVreme()
        {
            while (true)
            {
                Invoke(new Action(() =>
                {
                    label1.Text = DateTime.Now.ToLongTimeString();
                }
                ));
                Thread.Sleep(1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                server = new ServerKlasa();
                server.PoveziSe();
                button1.Enabled = false;
                button2.Enabled = true;
                Thread thread = new Thread(server.Osluskuj);
                thread.IsBackground = true;
                thread.Start();
                server.Clanovi.ListChanged += Clanovi_ListChanged;
                server.Bibliotekari.ListChanged += Bibliotekari_ListChanged;
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;
                button2.Enabled = false;
                server.Stop();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bibliotekari_ListChanged(object sender, ListChangedEventArgs e)
        {
            dataGridView2.Invoke(new Action(() => dataGridView2.DataSource = server.Bibliotekari.ToList()));
        }

        private void Clanovi_ListChanged(object sender, ListChangedEventArgs e)
        {
            dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = server.Clanovi.ToList()));
        }

    }
}
