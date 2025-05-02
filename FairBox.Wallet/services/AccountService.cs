using fairdao.extensions.shared;
using fairdao.extensions.shared.entity;
using fairdao.extensions.shared.services;
using FairBox.Wallet.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairBox.Wallet.services
{
    /// <summary>
    /// 账号服务
    /// </summary>
    public class AccountService : IAccountService
    {

        private SysHelper _Helper;
        public AccountService(SysHelper helper)
        {
            _Helper = helper;
          
        }

        private static BlockchainAccount? _account;
      

        public  async Task<BlockchainAccount> GetAccountAsync()
        {
            //读取当前账号
            if (_account == null)
            {
                List<KeyValuePair<string, string>> accounts = await _Helper.GetCache<List<KeyValuePair<string,string>>>("fair-accounts");
                if (accounts?.Count() > 0)
                {
                    _account = await _Helper.GetCache<BlockchainAccount>($"fair-accounts-{accounts[0].Key}");
                }
            }
            return _account;
        }



        public string LoginUrl => "/wallet/login";

        bool IAccountService.LoginRequired => false;

        public async Task ChangeAccountAsync(BlockchainAccount account)
        {
            string acc = account?.Account;
            if (!string.IsNullOrEmpty(acc))
            {
                List<KeyValuePair<string, string>> accounts = await _Helper.GetCache<List<KeyValuePair<string, string>>>("fair-accounts");
                if (accounts == null)
                {
                    accounts = new List<KeyValuePair<string, string>>();
                }
                acc = Encrypt.SHA1Encrypt(acc);
                acc = acc.Substring(5, 6);
                KeyValuePair<string, string>? a = accounts.FirstOrDefault(m => m.Key == acc);
                if (a!=null)
                {
                    accounts.Remove(a.Value);
                }
                accounts.Insert(0, new KeyValuePair<string, string>(acc,account?.NickName??""));

                await _Helper.ReloadConfig();
                await _Helper.SetCache($"fair-accounts-{acc}", account);
                await _Helper.SetCache($"fair-accounts", accounts);
            }
        }

        public  async Task Logout()
        {
            _account = null;
            await _Helper.SetCache("mainAccount", null);
        }

        /// <summary>
        /// 获取账户图片
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetProfilePhoto(BlockchainAccount? account)
        {
            return "";
        }
    }
}
