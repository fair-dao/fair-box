using fairdao.extensions.shared;
using fairdao.extensions.shared.entity;
using fairdao.extensions.shared.services;
using FairBox.Wallet.services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FluentUI.AspNetCore.Components;
using Icons = Microsoft.FluentUI.AspNetCore.Components.Icons;

namespace FairBox.Wallet
{
    public class Extender : fairdao.extensions.shared.ServiceExtender
    {

        public override List<VCommpent> VCommpents => new List<VCommpent>
            {   new VCommpent
                {
                    Id = "wallet",
                    Parent=VCommpent.Page,
                    Icon=new Icons.Regular.Size20.Wallet(),
                    SelectedIcon=new Icons.Regular.Size20.Wallet(),
                    Text="钱包",
                    ComType= ComponentType.CommpentMode,
                    Link="FairBox.Wallet.Pages.Wallet,FairBox.Wallet"
                },
                new VCommpent
                {
                    Id = "etherwallet",
                    Parent="home",
                    Icon= new Icons.Regular.Size20.Wallet(),
                    Text="以太坊钱包",
                    ComType= ComponentType.IconMode,
                    Link="/wallet/ether"
                },
                new VCommpent
                {
                    Id = "tronwallet",
                    Parent="home",
                    Icon=Icon.FromImageUrl( "/_content/FairBox.Wallet/images.chains/tron.svg"),
                    Text="波场钱包",
                    ComType= ComponentType.IconMode,
                    Link="/wallet/tron"
                }

            };
        public override void Config(IServiceCollection services)
        {


            base.Config(services);
            //添加账号服务
            services.AddSingleton<IAccountService, services.AccountService>();
            services.AddTransient<WalletService>();

        }

        public override void Use(IServiceProvider provider)
        {
            base.Use(provider);

        }
    }
}
