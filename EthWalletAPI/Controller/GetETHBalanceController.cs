using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Numerics;
using System.Threading.Tasks;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Wallet.Model;
using Nethereum.Wallet.Services;
using Nethereum.Web3;

namespace EthWalletAPI.Controller
{
    public class GetETHBalanceController : ApiController
    {
         //private readonly IEthWalletService _ethServices;
          public string ClientURL { get; set; } = "HTTP://127.0.0.1:8545";
          [HttpGet]
          public async Task<decimal> GetAccountBalance(string AccountAddress)
          {
              //var AccountAddress = "0x14088bA8b906F41759cb9a2e40FDebE4b48B7e31";
              var web3 = new Nethereum.Web3.Web3(ClientURL);
              var balance = await web3.Eth.GetBalance.SendRequestAsync(AccountAddress);
              var etherAmount = Web3.Convert.FromWei(balance.Value);
              return etherAmount;
          }
    }
}
