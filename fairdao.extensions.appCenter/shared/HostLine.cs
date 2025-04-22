using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fairdao.extensions.appCenter.shared
{
    /// <summary>
    /// 主机记录
    /// </summary>
    public class HostLine
    {

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; } = "127.0.0.1";

        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }


        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public Int64 Version { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public Int32 Port { get; set; }


        /// <summary>
        /// 是否是动态的IP
        /// </summary>
        public bool IsDynamic { get; set; } = false;

        public override string ToString()
        {
            return $"{IP} {Domain} {Alias} {Version} {Port}";
        }
      

    }
}
