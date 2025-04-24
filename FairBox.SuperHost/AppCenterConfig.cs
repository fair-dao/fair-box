using ApexCharts;
using FairBox.SuperHost.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FairBox.SuperHost.shared.Records;

namespace FairBox.SuperHost
{

    /// <summary>
    /// App中心配置
    /// </summary>
    public class AppCenterConfig
    {
       
        /// <summary>
        /// 主机列表
        /// </summary>
        public List<AppHost> Hosts { get; set; } = new List<AppHost>();    
    
    }

    public class AppHost
    {
        public string Name { get; set; }
        /// <summary>
        /// API地址
        /// </summary>
        public string ApiAddress { get; set; } = "";

        /// <summary>
        /// 主机基本信息
        /// </summary>
        public Records.HostInfo.Base? BaseInfo { get; set; }
        /// <summary>
        /// 授权Token
        /// </summary>
        public string Token { get; set; }


       
        /// <summary>
        /// 主机资源 
        /// </summary>
        public List<Records.HostInfo.RealtimeInfo>? Resources { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public bool Flush { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ApexChart<HostInfo.RealtimeInfo> Chart { get; set; }

    }

}
