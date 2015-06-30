using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Memcached.ClientLibrary;
using System.Collections;

namespace UsingMemcached.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MemcachedClient mc = new MemcachedClient();
            mc.EnableCompression = false;

            mc.Set(txtkey.Text, txtValue.Text);

            SockIOPool.GetInstance().Shutdown();
        }

        protected void btnStats_Click(object sender, EventArgs e)
        {
            // Get the Statistics of memcahed server
            MemcachedClient mc = new MemcachedClient();
            IDictionary stats = mc.Stats();
            foreach (string key1 in stats.Keys)
            {
                lblStats.Text += key1;
                Hashtable values = (Hashtable)stats[key1];
                foreach (string key2 in values.Keys)
                {
                    lblStats.Text += key2 + ":" + values[key2] + "\r\n";
                }
                lblStats.Text += "\r\n";
            }
        }
    }
}
