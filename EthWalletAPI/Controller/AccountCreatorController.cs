using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nethereum.Accounts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace EthWalletAPI.Controller
{
    public class AccountCreatorController : ApiController
    {
        [HttpGet]
        public string CreateETHAccount(string password)
        {
            ETHaccountCreator ETHgenKeys = new ETHaccountCreator();
            var ETHaccount = ETHgenKeys.CreateAccount(password);
            return ETHaccount;
        }
    }
}
