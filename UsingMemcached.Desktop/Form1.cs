using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Memcached.ClientLibrary;

namespace UsingMemcached.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void btnGetValue_Click(object sender, EventArgs e)
        {
            string[] serverlist = { txtServer.Text };

            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);

            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;

            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;
            pool.Failover = true;

            pool.Nagle = false;
            pool.Initialize();

            MemcachedClient mc = new MemcachedClient();
            mc.EnableCompression = false;

            string value = (string)mc.Get(txtKey.Text);
            MessageBox.Show(value);
        }
    }
}
