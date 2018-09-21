using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Nethereum.Web3;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.TransactionReceipts;

namespace EthWalletAPI.Controller
{
    public class ETHTransferController : ApiController
    {
        public string ClientURL { get; set; } = "HTTP://127.0.0.1:8545";  //If you want to use the wallet on the main net, you have change the URL.
        
        private const int UnLockAccountDurationInSeconds = 120;
     //   [HttpPost]
        public async Task<TransactionReceipt> TransferETH(string senderAddr, string senderPassword, string receiverAddr, decimal amount)
        {
            var web3 = new Nethereum.Web3.Web3(ClientURL);

            var unlockResult = await web3.Personal.UnlockAccount.SendRequestAsync(senderAddr, senderPassword, UnLockAccountDurationInSeconds);
            unlockResult = true;
            if (unlockResult != true) throw new Exception("Account not unlocked");

            amount = 1;
            var amountInWei = Web3.Convert.ToWei(amount);

            var pollingService = new TransactionReceiptPollingService(web3.TransactionManager);
            var receipt = await pollingService.SendRequestAndWaitForReceiptAsync(new TransactionInput
            {
                From = senderAddr,
                To = receiverAddr,
                Value = new HexBigInteger(amountInWei)
            });

            return receipt;
        }
    }
}
