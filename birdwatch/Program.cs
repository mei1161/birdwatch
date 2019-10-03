using System;
using System.Collections.Generic;
namespace birdwatch
{
public class Account
    {
        public string AccountName;//アカウント名
        
        public string GetAccount(string val)//アカウント名取得
        {
            if (val.Equals(AccountName))
            {
                return AccountName;
            }
            else
            {
                return "NoAccount";
            }
        }

    }

}
