using fairdao.extensions.shared.entity;
using fairdao.extensions.shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FluentUI.AspNetCore.Components;
using fairdao.extensions.shared.Pages;
using ApexCharts;
using Microsoft.AspNetCore.Components;
using Icons = Microsoft.FluentUI.AspNetCore.Components.Icons;


namespace FairBox.SuperHost
{
    /// <summary>
    /// 延伸器
    /// </summary>
    public class Extender : fairdao.extensions.shared.ServiceExtender
    {


        public override string Name { get => "软件中心"; set => base.Name = value; }

        public AppCenterConfig config;

        public AppCenterConfig AppConfig
        {
            get => config;
        }

        public override List<string> SearchTypes { get => new List<string> { "Docker", "进程" }; set => base.SearchTypes = value; }


        private List<VCommpent> vCommpents;

        public override List<VCommpent> VCommpents
        {
            get
            {
                if (vCommpents == null)
                {
                    vCommpents = new List<VCommpent> {
                    new VCommpent
                    {
                        Id = "home",
                        SubCommpents = new List<VCommpent>
                        {
                            new VCommpent
                            {
                                Icon =  new Icons.Regular.Size20.Info(),
                                Text = "Docker",
                                SortId = 150,
                                ComType = ComponentType.CommpentMode,
                                Link = "FairBox.SuperHost.Pages.DockerManager,FairBox.SuperHost"
                            }
                        }
                    },
                    new VCommpent
                    {
                        Id = "appcenter",
                        SubCommpents=new List<VCommpent>()
                        {
                            new VCommpent
                            {
                                Icon =  new Icons.Regular.Size20.GlobeDesktop(),
                                Text = "主机管理",
                                SortId = 150,
                                ComType = ComponentType.CommpentMode,
                                Link = "FairBox.SuperHost.Pages.AppCenter,FairBox.SuperHost"
                            }
                        }
                    },
                    new VCommpent
                    {
                        Id="syssetup",
                        SubCommpents=new List<VCommpent>
                        {
                            new VCommpent {
                                Icon = new Icons.Regular.Size20.AppsAddIn(),
                                SelectedIcon=new Icons.Filled.Size20.AppsAddIn(),
                                Text = "主机设置",
                                SortId = 21111,
                                ComType = ComponentType.CommpentMode,
                                Link = "FairBox.SuperHost.Pages.AppCenterSetup,FairBox.SuperHost"

                            }
                        }
                    }
                };


                }

                return vCommpents;
            }
        }

        public override void Config(IServiceCollection services)
        {
            services.AddSingleton<FairBox.SuperHost.Extender>(this);
            base.Config(services);

        }


        public override async void Use(IServiceProvider provider)
        {
            base.Use(provider);         
            var sysHelper = provider.GetService<SysHelper>();
            config = await sysHelper.GetCache<AppCenterConfig>("appcenterConfig");
            if (config == null)
            {
                config = new AppCenterConfig();
            }

      
        }
    }
}
