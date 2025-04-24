using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairBox.SuperHost
{
    public class AppCenterBase : fairdao.extensions.shared.Pages.Page
    {
        [Parameter]
        public string HostName { get; set; }

        [Inject]
        public FairBox.SuperHost.Extender CurExtender { get; set; }


        public async void CallAPI(AppHost host, string url, string data = "", Action okAction = null)
        {
            if (host == null) host = CurAppHost;
            string callUrl = url.StartsWith("http") ? url : $"{host?.ApiAddress}{url}";
           await WraperFromResult<string>(callUrl, data, HttpMethod.Post, token: host.Token, okAction: (data) =>
            {
                okAction?.Invoke();
            });

        }

        public void CallAPI(string url,string data="",Action okAction=null)
        {
            CallAPI(CurAppHost, url, data, okAction);
        }


        public void CallAPI(string url, HttpContent content, Action okAction = null)
        {
            string callUrl = url.StartsWith("http") ? url : $"{CurAppHost.ApiAddress}{url}";
            WraperFromResult<string>(callUrl, content, HttpMethod.Post, token: CurAppHost.Token, okAction: (data) =>
            {
                okAction?.Invoke();
            });

        }


        private AppHost host;
        public AppHost CurAppHost
        {
            get
            {
                if (host == null)
                {
                    host = CurExtender.AppConfig.Hosts.Where(m => m.Name == HostName).FirstOrDefault();
                  
                }
                return host;
            }
        }

    
       
    }
}
