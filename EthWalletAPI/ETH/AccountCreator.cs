using Nethereum.KeyStore;
using System.IO;
using Newtonsoft.Json;

 namespace Nethereum.Accounts
{
    public class ETHaccountCreator
    {
        public void ShouldCreateKeyPair()
        {
            var ecKey = EthECKey.GenerateKey();
            //Get the public address (derivied from the public key)
            var address = ecKey.GetPublicAddress();
            var privateKey = ecKey.GetPrivateKey();
        }

        public string CreateAccount(string password)
        {
            //Generate a private key pair using SecureRandom
            var ecKey = EthECKey.GenerateKey();
            //Get the public address (derivied from the public key)
            var address = ecKey.GetPublicAddress();
            var privateKey = ecKey.GetPrivateKey();

            //Create a store service, to encrypt and save the file using the web3 standard
            var service = new KeyStoreService();
            //var encryptedKey = service.EncryptAndGenerateDefaultKeyStoreAsJson(password, ecKey.GetPrivateKeyAsBytes(), address);        
            string result = "{" + "\"Private Key\""+ ":" +"\""+ privateKey +"\""+ "," + "\"Address\""+":" + "\""+address +"\""+ "," + "\"password\""+":" + "\"" + password + "\""+"}";
            /********If you want to save the wallet address and private key as a keystore file, 
             * you can use the below code
             * 
             * Produced by Josiah
             * 
             * ***********/
             /******* var fileName = service.GenerateUTCFileName(address) + ".key";
              * var fileName = address + ".key";
              * using (var newfile = File.CreateText(Path.Combine(path, fileName)))
              *  {
              *       newfile.Write(encryptedKey);
              *       newfile.Flush();
              *  }
              *  **********/
            return result;
        }
    }
}