using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace apiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://127.0.0.1:9000/"))
            {

            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            appBuilder.UseWebApi(config);
        }
    }
}
