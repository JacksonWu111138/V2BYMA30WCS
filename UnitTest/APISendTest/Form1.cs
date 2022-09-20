using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Mirle;
using Mirle.WebAPI.V2BYMA30.Function;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using Mirle.Def;
using APISendTest.WebAPI;

namespace APISendTest
{
    public partial class Form1 : Form
    {
        private UnityContainer _unityContainer = new UnityContainer();
        private Host _webApiHost;
        private WebApiConfig send_webApiConfig = new WebApiConfig
        {
            IP = "127.0.0.1:9000/Test"
        };
        private EmptyShelfQuery emptyShelfQuery;
        private string listening_ip = "*:9000";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _unityContainer.RegisterInstance(new TestController());
            _webApiHost = new Host(new Startup(_unityContainer), listening_ip);

            emptyShelfQuery = new EmptyShelfQuery(send_webApiConfig);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmptyShelfQuery_TEST();
        }

        public void EmptyShelfQuery_TEST()
        {
            EmptyShelfQuery_WCS request = new EmptyShelfQuery_WCS
            {
                jobId = textBox1.Text,
                transactionId = textBox2.Text,
                carrierId = textBox3.Text
            };
            EmptyShelfQuery_WMS response = new EmptyShelfQuery_WMS();

            emptyShelfQuery.funReport(request, ref response);

            return;
        }
    }
}
