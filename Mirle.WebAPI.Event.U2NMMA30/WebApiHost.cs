using System;
using Microsoft.Owin.Hosting;
using Mirle.WebAPI.V2BYMA30.ReportInfo;
using Mirle.Def.U2NMMA30;
using Mirle.Structure;
using Mirle.WebAPI.V2BYMA30;


namespace Mirle.WebAPI.Event
{
    public class WebApiHost
    {
        private string _baseAddress = "http://127.0.0.1:9000/";
        private IDisposable _webService;
        private clsHost api = new clsHost();

        public WebApiHost(Startup startup, string sIP)
        {
            sIP = "127.0.0.1:9000";
            //sIP = "127.0.0.1";
            _baseAddress = $"http://{sIP}/";
            _webService = WebApp.Start(url: _baseAddress, startup: startup.Configuration);
        }

        ~WebApiHost()
        {
            _webService.Dispose();
        }
        public bool GetBufferRolliyng(string jobId, string location, string strEM)
        {
            ConveyorInfo conveyor = new ConveyorInfo();
            conveyor = ConveyorDef.GetBuffer(location);

            BufferRollInfo info = new BufferRollInfo {jobId = jobId, bufferId = conveyor.BufferName };

            if(!api.GetBufferRoll().FunReport(info,conveyor.API.IP))
                throw new Exception(strEM);

            return true;
        }
    }
}