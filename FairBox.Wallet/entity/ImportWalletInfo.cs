using fairdao.extensions.shared.localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FairBox.Wallet.entity
{

    /// <summary>
    /// 导入钱包的表单信息
    /// </summary>
    public class ImportWalletInfo
    {

        private FairdaoLocaler _localer;
        public ImportWalletInfo(FairdaoLocaler localer)
        {
            this._localer = localer;
        }
        public string PreHelpWord { get; set; }


        public string HelpWord { get; set; }

        public string PriKey { get; set; }

        public string Password { get; set; }


        public void Check()
        {
            if (!string.IsNullOrEmpty(HelpWord))
            {
                if (!Regex.IsMatch(HelpWord, @"^[\S]{12,40}$"))
                {
                    throw new FormatException("12~40个字符,支持多国语言文字,请牢记");
                }
            }
            else
            {
                if (!Regex.IsMatch(PriKey, @"^[\S]{32,64}$"))
                {
                    throw new FormatException("私钥由32~64个字符组成");
                }
            }
            if (!Regex.IsMatch(Password, @"^[\S]{8,64}$"))
            {
                throw new FormatException(_localer["交易签名不少于8个字符.请牢记,丢失了就只能重新导入"]);
            }

        }
    }

}