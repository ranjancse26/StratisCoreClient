using System;
using System.Collections.Generic;
using RestSharp;
using StratisApiClient.Client;
using StratisApiClient.Model;

namespace StratisApiClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISmartContractWalletApi
    {
        /// <summary>
        /// Builds a transaction to call a smart contract method and then broadcasts the transaction to the network.  If the call is successful, any changes to the smart contract balance or persistent data are propagated  across the network. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param>
        /// <returns></returns>
        void Call (BuildCallContractTransactionRequest request);
        /// <summary>
        /// Builds a transaction to create a smart contract and then broadcasts the transaction to the network.  If the deployment is successful, methods on the smart contract can be subsequently called. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param>
        /// <returns></returns>
        void Create (BuildCreateContractTransactionRequest request);
        /// <summary>
        /// Gets a smart contract account address.  This is a single address to use for all smart contract interactions.  Smart contracts send funds to and store data at this address. For example, an ERC-20 token  would store tokens allocated to a user at this address, although the actual data  could, in fact, be anything. The address stores a history of smart contract create/call transactions.     It also holds a UTXO list/balance based on UTXOs sent to it from smart contracts or user wallets.  Once a smart contract has written data to this address, you need to use the address to  provide gas and fees for smart contract calls involving that stored data (for that smart contract deployment).  In the case of specific ERC-20 tokens allocated to you, using this address would be  a requirement if you were to, for example, send some of the tokens to an exchange.    It is therefore recommended that in order to keep an intact history and avoid complications,  you use the single smart contract address provided by this function for all interactions with smart contracts.  In addition, a smart contract address can be used to identify a contract deployer.  Some methods, such as a withdrawal method on an escrow smart contract, should only be executed  by the deployer, and in this case, it is the smart contract account address that identifies the deployer.     Note that this account differs from \&quot;account 0\&quot;, which is the \&quot;default  holder of multiple addresses\&quot;. Other address holding accounts can be created,  but they should not be confused with the smart contract account, which is represented  by a single address. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve a smart contract account address for.</param>
        /// <returns></returns>
        void GetAccountAddresses (string walletName);
        /// <summary>
        /// Gets the balance at a specific wallet address in STRAT (or the sidechain coin).  This method gets the UTXOs at the address that the wallet can spend.  The function can be used to query the balance at a smart contract account address  supplied by /api/SmartContractWallet/account-addresses. 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        void GetAddressBalance (string address);
        /// <summary>
        /// Gets the history of a specific wallet address.  This includes the smart contract create and call transactions  This method can be used to query the balance at a smart contract account address  supplied by /api/SmartContractWallet/account-addresses. Indeed,  it is advisable to use /api/SmartContractWallet/account-addresses  to generate an address for all smart contract interactions.  If this has been done, and that address is supplied to this method,  a list of all smart contract interactions for a wallet will be returned. 
        /// </summary>
        /// <param name="walletName"></param>
        /// <param name="address"></param>
        /// <param name="skip">An optional value allowing (with Take) pagination of the wallet&#39;s history. If given,  the member specifies the numbers of records in the wallet&#39;s history to skip before  beginning record retrieval; otherwise the wallet history records are retrieved starting from 0.</param>
        /// <param name="take">An optional value allowing (with Skip) pagination of the wallet&#39;s history. If given,  the member specifies the number of records in the wallet&#39;s history to retrieve in this call; otherwise all  wallet history records are retrieved.</param>
        /// <returns></returns>
        void GetHistory (string walletName, string address, int? skip, int? take);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="walletName">The name of the wallet to recover the history for.</param>
        /// <param name="accountName">Optional. The name of the account to recover the history for. If no account name is specified,  the entire history of the wallet is recovered.</param>
        /// <param name="address">Optional. If set, will filter the transaction history for all transactions made to or from the given address.</param>
        /// <param name="skip">An optional value allowing (with Take) pagination of the wallet&#39;s history. If given,  the member specifies the numbers of records in the wallet&#39;s history to skip before  beginning record retrieval; otherwise the wallet history records are retrieved starting from 0.</param>
        /// <param name="take">An optional value allowing (with Skip) pagination of the wallet&#39;s history. If given,  the member specifies the number of records in the wallet&#39;s history to retrieve in this call; otherwise all  wallet history records are retrieved.</param>
        /// <param name="prevOutputTxTime">Optional, Previous OutputTxTime, used for pagination</param>
        /// <param name="prevOutputIndex">Optional, Previous PrevOutputIndex, used for pagination</param>
        /// <param name="searchQuery">An optional string that can be used to match different data in the transaction records.  It is possible to match on the following: the transaction ID, the address at which funds where received,  and the address to which funds where sent.</param>
        /// <returns></returns>
        void GetTransactionHistory (string walletName, string accountName, string address, int? skip, int? take, int? prevOutputTxTime, int? prevOutputIndex, string searchQuery);
        /// <summary>
        /// Broadcasts a transaction, which either creates a smart contract or calls a method on a smart contract.  If the contract deployment or method call are successful gas and fees are consumed. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to send the transaction.</param>
        /// <returns></returns>
        void SendTransaction (SendTransactionRequest request);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SmartContractWalletApi : ISmartContractWalletApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartContractWalletApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public SmartContractWalletApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartContractWalletApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SmartContractWalletApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// Builds a transaction to call a smart contract method and then broadcasts the transaction to the network.  If the call is successful, any changes to the smart contract balance or persistent data are propagated  across the network. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param> 
        /// <returns></returns>            
        public void Call (BuildCallContractTransactionRequest request)
        {
            
    
            var path = "/api/SmartContractWallet/call";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Call: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Call: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Builds a transaction to create a smart contract and then broadcasts the transaction to the network.  If the deployment is successful, methods on the smart contract can be subsequently called. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param> 
        /// <returns></returns>            
        public void Create (BuildCreateContractTransactionRequest request)
        {
            
    
            var path = "/api/SmartContractWallet/create";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Create: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Create: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets a smart contract account address.  This is a single address to use for all smart contract interactions.  Smart contracts send funds to and store data at this address. For example, an ERC-20 token  would store tokens allocated to a user at this address, although the actual data  could, in fact, be anything. The address stores a history of smart contract create/call transactions.     It also holds a UTXO list/balance based on UTXOs sent to it from smart contracts or user wallets.  Once a smart contract has written data to this address, you need to use the address to  provide gas and fees for smart contract calls involving that stored data (for that smart contract deployment).  In the case of specific ERC-20 tokens allocated to you, using this address would be  a requirement if you were to, for example, send some of the tokens to an exchange.    It is therefore recommended that in order to keep an intact history and avoid complications,  you use the single smart contract address provided by this function for all interactions with smart contracts.  In addition, a smart contract address can be used to identify a contract deployer.  Some methods, such as a withdrawal method on an escrow smart contract, should only be executed  by the deployer, and in this case, it is the smart contract account address that identifies the deployer.     Note that this account differs from \&quot;account 0\&quot;, which is the \&quot;default  holder of multiple addresses\&quot;. Other address holding accounts can be created,  but they should not be confused with the smart contract account, which is represented  by a single address. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve a smart contract account address for.</param> 
        /// <returns></returns>            
        public void GetAccountAddresses (string walletName)
        {
            
    
            var path = "/api/SmartContractWallet/account-addresses";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("walletName", ApiClient.ParameterToString(walletName)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAccountAddresses: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAccountAddresses: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the balance at a specific wallet address in STRAT (or the sidechain coin).  This method gets the UTXOs at the address that the wallet can spend.  The function can be used to query the balance at a smart contract account address  supplied by /api/SmartContractWallet/account-addresses. 
        /// </summary>
        /// <param name="address"></param> 
        /// <returns></returns>            
        public void GetAddressBalance (string address)
        {
            
    
            var path = "/api/SmartContractWallet/address-balance";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (address != null) queryParams.Add("address", ApiClient.ParameterToString(address)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressBalance: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressBalance: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the history of a specific wallet address.  This includes the smart contract create and call transactions  This method can be used to query the balance at a smart contract account address  supplied by /api/SmartContractWallet/account-addresses. Indeed,  it is advisable to use /api/SmartContractWallet/account-addresses  to generate an address for all smart contract interactions.  If this has been done, and that address is supplied to this method,  a list of all smart contract interactions for a wallet will be returned. 
        /// </summary>
        /// <param name="walletName"></param> 
        /// <param name="address"></param> 
        /// <param name="skip">An optional value allowing (with Take) pagination of the wallet&#39;s history. If given,  the member specifies the numbers of records in the wallet&#39;s history to skip before  beginning record retrieval; otherwise the wallet history records are retrieved starting from 0.</param> 
        /// <param name="take">An optional value allowing (with Skip) pagination of the wallet&#39;s history. If given,  the member specifies the number of records in the wallet&#39;s history to retrieve in this call; otherwise all  wallet history records are retrieved.</param> 
        /// <returns></returns>            
        public void GetHistory (string walletName, string address, int? skip, int? take)
        {
            
    
            var path = "/api/SmartContractWallet/history";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (address != null) queryParams.Add("Address", ApiClient.ParameterToString(address)); // query parameter
 if (skip != null) queryParams.Add("Skip", ApiClient.ParameterToString(skip)); // query parameter
 if (take != null) queryParams.Add("Take", ApiClient.ParameterToString(take)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetHistory: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetHistory: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="walletName">The name of the wallet to recover the history for.</param> 
        /// <param name="accountName">Optional. The name of the account to recover the history for. If no account name is specified,  the entire history of the wallet is recovered.</param> 
        /// <param name="address">Optional. If set, will filter the transaction history for all transactions made to or from the given address.</param> 
        /// <param name="skip">An optional value allowing (with Take) pagination of the wallet&#39;s history. If given,  the member specifies the numbers of records in the wallet&#39;s history to skip before  beginning record retrieval; otherwise the wallet history records are retrieved starting from 0.</param> 
        /// <param name="take">An optional value allowing (with Skip) pagination of the wallet&#39;s history. If given,  the member specifies the number of records in the wallet&#39;s history to retrieve in this call; otherwise all  wallet history records are retrieved.</param> 
        /// <param name="prevOutputTxTime">Optional, Previous OutputTxTime, used for pagination</param> 
        /// <param name="prevOutputIndex">Optional, Previous PrevOutputIndex, used for pagination</param> 
        /// <param name="searchQuery">An optional string that can be used to match different data in the transaction records.  It is possible to match on the following: the transaction ID, the address at which funds where received,  and the address to which funds where sent.</param> 
        /// <returns></returns>            
        public void GetTransactionHistory (string walletName, string accountName, string address, int? skip, int? take, int? prevOutputTxTime, int? prevOutputIndex, string searchQuery)
        {
            
            // verify the required parameter 'walletName' is set
            if (walletName == null) throw new ApiException(400, "Missing required parameter 'walletName' when calling GetTransactionHistory");
            
    
            var path = "/api/SmartContractWallet/transaction-history";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (walletName != null) queryParams.Add("WalletName", ApiClient.ParameterToString(walletName)); // query parameter
 if (accountName != null) queryParams.Add("AccountName", ApiClient.ParameterToString(accountName)); // query parameter
 if (address != null) queryParams.Add("Address", ApiClient.ParameterToString(address)); // query parameter
 if (skip != null) queryParams.Add("Skip", ApiClient.ParameterToString(skip)); // query parameter
 if (take != null) queryParams.Add("Take", ApiClient.ParameterToString(take)); // query parameter
 if (prevOutputTxTime != null) queryParams.Add("PrevOutputTxTime", ApiClient.ParameterToString(prevOutputTxTime)); // query parameter
 if (prevOutputIndex != null) queryParams.Add("PrevOutputIndex", ApiClient.ParameterToString(prevOutputIndex)); // query parameter
 if (searchQuery != null) queryParams.Add("SearchQuery", ApiClient.ParameterToString(searchQuery)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTransactionHistory: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTransactionHistory: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Broadcasts a transaction, which either creates a smart contract or calls a method on a smart contract.  If the contract deployment or method call are successful gas and fees are consumed. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to send the transaction.</param> 
        /// <returns></returns>            
        public void SendTransaction (SendTransactionRequest request)
        {
            
    
            var path = "/api/SmartContractWallet/send-transaction";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SendTransaction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SendTransaction: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
