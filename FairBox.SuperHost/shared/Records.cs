using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using static FairBox.SuperHost.shared.Records.HostInfo;

namespace FairBox.SuperHost.shared
{
    public class Records
    {
      
        public record HostList(string DomainRoot,List<HostLine> Hosts);

        /// <summary>
        /// 进程信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        public record ProcessInfo(int ID,string Name,decimal Memory);


        /// <summary>
        /// 系统信息
        /// </summary>
        /// <param name="MachineName"></param>
        /// <param name="ProcessorCount"></param>
        /// <param name="CurrentDirectory"></param>
        /// <param name="CertCount"></param>
        /// <param name="WebSocketState"></param>
        /// <param name="StaticFilesCount"></param>
        /// <param name="CacheExtNames"></param>
        /// <param name="ProcessName"></param>
        /// <param name="Memory"></param>
        public record SysInfo(string MachineName,int ProcessorCount,OperatingSystem OSVersion, string CurrentDirectory,int CertCount,string WebSocketState,int StaticFilesCount,string CacheExtNames,string ProcessName,string Memory);
        
        /// <summary>
        /// 名称值
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        public record NameValue(string Name,string Value);


        /// <summary>
        /// 文件或目录
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Name"></param>
        /// <param name="Path"></param>
        /// <param name="IsDir"></param>
        /// <param name="Length">文件长度</param>
        /// <param name="EditTime">修改时间</param>
        public record DirOrFile(string Type,string Name,string Path,decimal Length,Int64 EditTime);

        public record DockerNode(string Id,string HostName,string Address,string Message,string Status,string Version,DateTime Created,DateTime Updated, DockerNode.NodeManagerStatus ManagerStatus,DockerNode.NodeSpec Spec)
        {
            public record NodeSpec(string Role,string Availability, IDictionary<string, string> Labels);
            public record NodeManagerStatus(string Addr, bool Leader, string Reachability);

        };


        /// <summary>
        /// Docker 镜像
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Size"></param>
        /// <param name="Created"></param>
        public record DockerImage(string Id,string Name,long Size,DateTime Created);

        public record DockerService(string Id,DateTime Created, DockerService.ServiceSpec Spec,DockerService.DockerServiceState ServiceState)
        {
            public record DockerServiceState( ulong RunningTasks,ulong DesiredTasks,ulong CompletedTask);

            public record ServiceSpec(string Name,string Labels,string Service,string UpdateConfig,string RollbackConfig,string Networks,string Endpoint,
                ServiceSpec.ContainerSpec Container,ServiceSpec.PlacementSpec Placement)
            {
                public record ContainerSpec(string Image,string id);
                public record PlacementSpec(int Max);
        }
        }

        /// <summary>
        /// Docker 容器
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Image"></param>
        /// <param name="Ports"></param>
        /// <param name="Status"></param>
        public record DockerContainer(string Id,string Name, string Image, string Ports, string Status,long Size,DateTime Created,string Command);

        /// <summary>
        /// 模板数据
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Image"></param>
        /// <param name="Ports"></param>
        /// <param name="Command"></param>
        /// <param name="Maps"></param>
        /// <param name="Envs"></param>
        /// <param name="UseRoot"></param>
        /// <param name="Remark"></param>
        public record DockerContainerTemplate(string Id, string Name, string Image, string Type, string Ports,string Command,string Maps,string Envs,bool AlwaysRun, bool UseRoot,string Remark);

        /// <summary>
        /// 创建容器页面请求数据
        /// </summary>
        /// <param name="Images"></param>
        /// <param name="Templates"></param>
        public record DockerCreateContainerData(string[] Images,  List<DockerContainerTemplate> Templates);


        /// <summary>
        ///  Yaml 模板类
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        /// <param name="Remark">说明</param>
        /// <param name="Link">模板所在路径</param>
        public record DockerServiceTemplate(string Name, string Type,string Remark,string Link);

        public record DockerSecret(string Id,string Name,string Labels,DateTime Created);
        public record DockerRegistry(string ServerAddress, string Account, string Password, string Email,string Token);

        /// <summary>
        /// 站点映射信息
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Domain"></param>
        /// <param name="Maps">映射目标（上游）</param>
        /// <param name="Cluster"></param>
        /// <param name="Enabled"></param>
        /// <param name="Visit"></param>
        /// <param name="RootPath"></param>
        /// <param name="Traffic"></param>
        public record SiteMap(string Name,string Type,string Domain,string Maps,bool Enabled,Int64 Visit,string RootPath,UInt128 Traffic);
        
        /// <summary>
        /// 站点证书
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Domain"></param>
        /// <param name="Subject"></param>
        /// <param name="Days"></param>
        public record SiteCert(string Name,string Domain,string Subject,decimal Days,string CertFilePath);


        /// <summary>
        /// 系统初始化调用返回结果 
        /// </summary>
        /// <param name="Account">管理员账号</param>
        /// <param name="Password">管理员密码</param>
        /// <param name="APIToken">API登录Token</param>
        public record InitResult(string HostName,string OSName,string Account,string Password,string APIToken);

        /// <summary>
        /// 主机信息
        /// </summary>
        /// <param name="HostName"></param>
        /// <param name="OSName"></param>
        /// <param name="MemoryTotal"></param>
        /// <param name="CPUTotal"></param>
        /// <param name="SysDiskTotal"></param>
        /// <param name="AppDiskTotal"></param>
        /// <param name="NICName"></param>
        /// <param name="NetMax"></param>
        public record HostInfo(HostInfo.Base BaseInfo, RealtimeInfo Realtime)
        {

            /// <summary>
            /// 主机基本信息
            /// </summary>
            /// <param name="HostName"></param>
            /// <param name="OSName"></param>
            /// <param name="CPUTotal"></param>
            /// <param name="MemoryTotal"></param>
            /// <param name="SysDiskTotal"></param>
            /// <param name="AppDiskTotal"></param>
            /// <param name="NICName">网卡名</param>
            /// <param name="NetMax">网卡最大流量</param>
            /// <param name="Inited">是否已初始化</param>
            public record Base(string HostName, string OSName, int Cores, decimal MemoryTotal, long SysDiskTotal, long AppDiskTotal, string NICName, Int64 NetMax,bool Inited);

            /// <summary>
            /// 主机实时信息
            /// </summary>
            /// <param name="MemoryUsage"></param>
            /// <param name="CPUUsage"></param>
            /// <param name="SysDiskUsage"></param>
            /// <param name="AppDiskUsage"></param>
            /// <param name="NetReceived"></param>
            /// <param name="NetSend"></param>
            /// <param name="Timestamp"></param>
            public record RealtimeInfo(decimal MemoryUsage,decimal CPUUsage,long SysDiskUsage, long AppDiskUsage, Int64 NetReceived, Int64 NetSend, Int64 Timestamp);

           
        }

        /// <summary>
        /// 请求升级返回结果 
        /// </summary>
        /// <param name="ClientDownloadLink"></param>
        /// <param name="ServerVer"></param>
        /// <param name="ClientVer"></param>
        public record UpgradeResult(string ClientDownloadLink,string ServerVer,string ClientVer);


        /// <summary>
        /// 插件信息
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        /// <param name="DirName"></param>
        /// <param name="EntryPoint"></param>
        /// <param name="CurVersion"></param>
        /// <param name="State">当前插件状态</param>
        /// <param name="Autostart">是否自动启动</param>
        public record PlugInfo(string Name,string Type,string DirName,string EntryPoint, string CurVersion,string State,bool Autostart, List<string> Versions);
        public record LogInfo(string Id,DateTime LogTime,string LogName, string EntryType,string Message);
    }
}
