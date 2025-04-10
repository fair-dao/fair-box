using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fairdao.extensions.appCenter.shared
{

    /// <summary>
    /// Docker节点初始化参数
    /// </summary>
    public class DockerSwarmInitParameter
    {
        public string NodeType { get; set; }

        public string IpAddress { get; set; }

        public string Token { get; set; }
    }
}
