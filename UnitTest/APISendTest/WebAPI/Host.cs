using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using System.Web.Http;

namespace APISendTest.WebAPI
{
    public class Host
    {
        private string _baseAddress = "http://127.0.0.1:9000/";
        private IDisposable _webService;

        public Host(Startup startup, string sIP)
        {
            //    sIP = "127.0.0.1:9000";
            //    //sIP = "127.0.0.1";
            _baseAddress = $"http://{sIP}/";
            _webService = WebApp.Start(url: _baseAddress, startup: startup.Configuration);
        }

        ~Host()
        {
            _webService.Dispose();
        }
    }
}
