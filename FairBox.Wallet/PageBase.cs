using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;
using System.Net.Http;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Drawing;
using fairdao.extensions.shared;
using FairBox.Wallet.entity;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace FairBox.Wallet
{
    /// <summary>
    /// 页面基类
    /// </summary>
    public class PageBase : fairdao.extensions.shared.ComBase
    {

      
        public override string CurPlugId => "wallet";

    
     
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
        }

        


        

    }

}
