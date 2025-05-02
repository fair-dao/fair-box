using FairBox.Wallet.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairBox.Wallet.entity
{

    /// <summary>
    /// 账号数据
    /// </summary>
    public class AccountData
    {

        public List<TronCoin>? TronAccounts { get; set; } = new ();
    }
}
