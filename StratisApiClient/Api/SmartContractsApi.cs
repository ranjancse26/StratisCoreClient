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
    public interface ISmartContractsApi
    {
        /// <summary>
        /// Builds a transaction to call a smart contract method and then broadcasts the transaction to the network.  If the call is successful, any changes to the smart contract balance or persistent data are propagated  across the network. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param>
        /// <returns></returns>
        void BuildAndSendCallSmartContractTransactionAsync (BuildCallContractTransactionRequest request);
        /// <summary>
        /// Builds a transaction to create a smart contract and then broadcasts the transaction to the network.  If the deployment is successful, methods on the smart contract can be subsequently called. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param>
        /// <returns></returns>
        void BuildAndSendCreateSmartContractTransactionAsync (BuildCreateContractTransactionRequest request);
        /// <summary>
        /// Builds a transaction to call a smart contract method. Although the transaction is created, the  call is not made, and no gas or fees are consumed.  Instead the created transaction is returned as a JSON object.  Transactions built using this method can be deployed using /api/SmartContractWallet/send-transaction  However, unless there is a need to closely examine the transaction before deploying it, you should use  api/SmartContracts/build-and-send-call. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param>
        /// <returns></returns>
        void BuildCallSmartContractTransaction (BuildCallContractTransactionRequest request);
        /// <summary>
        /// Builds a transaction to create a smart contract. Although the transaction is created, the smart contract is not  deployed on the network, and no gas or fees are consumed.  Instead the created transaction is returned as a hexadecimal string within a JSON object.  Transactions built using this method can be deployed using /api/SmartContractWallet/send-transaction.  However, unless there is a need to closely examine the transaction before deploying it, you should use  api/SmartContracts/build-and-send-create. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param>
        /// <returns></returns>
        void BuildCreateSmartContractTransaction (BuildCreateContractTransactionRequest request);
        /// <summary>
        /// Builds a transaction to transfer funds on a smart contract network. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param>
        /// <returns></returns>
        void BuildTransaction (BuildContractTransactionRequest request);
        /// <summary>
        /// Gets a fee estimate for a specific smart contract account-based transfer transaction.  This differs from fee estimation on standard networks due to the way inputs must be selected for account-based transfers. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to build the the fee estimation transaction.</param>
        /// <returns></returns>
        void EstimateFee (ScTxFeeEstimateRequest request);
        /// <summary>
        /// Gets all addresses owned by a wallet which have a balance associated with them. This  method effectively returns the balance of all the UTXOs associated with a wallet.  In a case where multiple UTXOs are associated with one address, the amounts  are tallied to give a total for that address. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve the addresses from.</param>
        /// <returns></returns>
        void GetAddressesWithBalances (string walletName);
        /// <summary>
        /// Gets the balance of a smart contract in STRAT (or the sidechain coin). This method only works for smart contract addresses. 
        /// </summary>
        /// <param name="address">The address of the smart contract to retrieve the balance for.</param>
        /// <returns></returns>
        void GetBalance (string address);
        /// <summary>
        /// Gets the bytecode for a smart contract as a hexadecimal string. The bytecode is decompiled to  C# source, which is returned as well. Be aware, it is the bytecode which is being executed,  so this is the \&quot;source of truth\&quot;. 
        /// </summary>
        /// <param name="address">The address of the smart contract to retrieve as bytecode and C# source.</param>
        /// <returns></returns>
        void GetCode (string address);
        /// <summary>
        /// Gets a smart contract transaction receipt. Receipts contain information about how a smart contract transaction was executed.  This includes the value returned from a smart contract call and how much gas was used. 
        /// </summary>
        /// <param name="txHash">A hash of the smart contract transaction (the transaction ID).</param>
        /// <returns></returns>
        void GetReceiptAPI (string txHash);
        /// <summary>
        /// Gets a single piece of smart contract data, which was stored as a key–value pair using the  SmartContract.PersistentState property.   The method performs a lookup in the smart contract  state database for the supplied smart contract address and key.  The value associated with the given key, deserialized for the specified data type, is returned.  If the key does not exist or deserialization fails, the method returns the default value for  the specified type. 
        /// </summary>
        /// <param name="contractAddress">The address of the smart contract.</param>
        /// <param name="storageKey">The key for the piece of stored data to retrieve.</param>
        /// <param name="dataType">The stored data type.</param>
        /// <returns></returns>
        void GetStorage (string contractAddress, string storageKey, string dataType);
        /// <summary>
        /// Makes a local call to a method on a smart contract that has been successfully deployed. A transaction   is not created as the call is never propagated across the network. All persistent data held by the     smart contract is copied before the call is made. Only this copy is altered by the call  and the actual data is unaffected. Even if an amount of funds are specified to send with the call,  no funds are in fact sent.  The purpose of this function is to query and test methods. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param>
        /// <returns></returns>
        void LocalCallSmartContractTransaction (LocalCallContractRequest request);
        /// <summary>
        /// Searches a smart contract&#39;s receipts for those which match a specific event. The SmartContract.Log() function  is capable of storing C# structs, and structs are used to store information about different events occurring   on the smart contract. For example, a \&quot;TransferLog\&quot; struct could contain \&quot;From\&quot; and \&quot;To\&quot; fields and be used to log  when a smart contract makes a transfer of funds from one wallet to another. The log entries are held inside the smart contract,  indexed using the name of the struct, and are linked to individual transaction receipts.  Therefore, it is possible to return a smart contract&#39;s transaction receipts  which match a specific event (as defined by the struct name). 
        /// </summary>
        /// <param name="contractAddress">The contract address from which events were raised.</param>
        /// <param name="eventName">The name of the event raised.</param>
        /// <param name="topics">The topics to search. All specified topics must be present.</param>
        /// <param name="fromBlock">The block number from which to start searching.</param>
        /// <param name="toBlock">The block number where searching finishes.</param>
        /// <returns></returns>
        void ReceiptSearchAPI (string contractAddress, string eventName, List<string> topics, int? fromBlock, int? toBlock);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SmartContractsApi : ISmartContractsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartContractsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public SmartContractsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartContractsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SmartContractsApi(String basePath)
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
        public void BuildAndSendCallSmartContractTransactionAsync (BuildCallContractTransactionRequest request)
        {
            
    
            var path = "/api/SmartContracts/build-and-send-call";
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
                throw new ApiException ((int)response.StatusCode, "Error calling BuildAndSendCallSmartContractTransactionAsync: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling BuildAndSendCallSmartContractTransactionAsync: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Builds a transaction to create a smart contract and then broadcasts the transaction to the network.  If the deployment is successful, methods on the smart contract can be subsequently called. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param> 
        /// <returns></returns>            
        public void BuildAndSendCreateSmartContractTransactionAsync (BuildCreateContractTransactionRequest request)
        {
            
    
            var path = "/api/SmartContracts/build-and-send-create";
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
                throw new ApiException ((int)response.StatusCode, "Error calling BuildAndSendCreateSmartContractTransactionAsync: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling BuildAndSendCreateSmartContractTransactionAsync: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Builds a transaction to call a smart contract method. Although the transaction is created, the  call is not made, and no gas or fees are consumed.  Instead the created transaction is returned as a JSON object.  Transactions built using this method can be deployed using /api/SmartContractWallet/send-transaction  However, unless there is a need to closely examine the transaction before deploying it, you should use  api/SmartContracts/build-and-send-call. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param> 
        /// <returns></returns>            
        public void BuildCallSmartContractTransaction (BuildCallContractTransactionRequest request)
        {
            
    
            var path = "/api/SmartContracts/build-call";
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
                throw new ApiException ((int)response.StatusCode, "Error calling BuildCallSmartContractTransaction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling BuildCallSmartContractTransaction: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Builds a transaction to create a smart contract. Although the transaction is created, the smart contract is not  deployed on the network, and no gas or fees are consumed.  Instead the created transaction is returned as a hexadecimal string within a JSON object.  Transactions built using this method can be deployed using /api/SmartContractWallet/send-transaction.  However, unless there is a need to closely examine the transaction before deploying it, you should use  api/SmartContracts/build-and-send-create. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param> 
        /// <returns></returns>            
        public void BuildCreateSmartContractTransaction (BuildCreateContractTransactionRequest request)
        {
            
    
            var path = "/api/SmartContracts/build-create";
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
                throw new ApiException ((int)response.StatusCode, "Error calling BuildCreateSmartContractTransaction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling BuildCreateSmartContractTransaction: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Builds a transaction to transfer funds on a smart contract network. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param> 
        /// <returns></returns>            
        public void BuildTransaction (BuildContractTransactionRequest request)
        {
            
    
            var path = "/api/SmartContracts/build-transaction";
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
                throw new ApiException ((int)response.StatusCode, "Error calling BuildTransaction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling BuildTransaction: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets a fee estimate for a specific smart contract account-based transfer transaction.  This differs from fee estimation on standard networks due to the way inputs must be selected for account-based transfers. 
        /// </summary>
        /// <param name="request">An object containing the parameters used to build the the fee estimation transaction.</param> 
        /// <returns></returns>            
        public void EstimateFee (ScTxFeeEstimateRequest request)
        {
            
    
            var path = "/api/SmartContracts/estimate-fee";
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
                throw new ApiException ((int)response.StatusCode, "Error calling EstimateFee: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling EstimateFee: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets all addresses owned by a wallet which have a balance associated with them. This  method effectively returns the balance of all the UTXOs associated with a wallet.  In a case where multiple UTXOs are associated with one address, the amounts  are tallied to give a total for that address. 
        /// </summary>
        /// <param name="walletName">The name of the wallet to retrieve the addresses from.</param> 
        /// <returns></returns>            
        public void GetAddressesWithBalances (string walletName)
        {
            
    
            var path = "/api/SmartContracts/address-balances";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressesWithBalances: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressesWithBalances: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the balance of a smart contract in STRAT (or the sidechain coin). This method only works for smart contract addresses. 
        /// </summary>
        /// <param name="address">The address of the smart contract to retrieve the balance for.</param> 
        /// <returns></returns>            
        public void GetBalance (string address)
        {
            
    
            var path = "/api/SmartContracts/balance";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetBalance: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBalance: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the bytecode for a smart contract as a hexadecimal string. The bytecode is decompiled to  C# source, which is returned as well. Be aware, it is the bytecode which is being executed,  so this is the \&quot;source of truth\&quot;. 
        /// </summary>
        /// <param name="address">The address of the smart contract to retrieve as bytecode and C# source.</param> 
        /// <returns></returns>            
        public void GetCode (string address)
        {
            
    
            var path = "/api/SmartContracts/code";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetCode: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetCode: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets a smart contract transaction receipt. Receipts contain information about how a smart contract transaction was executed.  This includes the value returned from a smart contract call and how much gas was used. 
        /// </summary>
        /// <param name="txHash">A hash of the smart contract transaction (the transaction ID).</param> 
        /// <returns></returns>            
        public void GetReceiptAPI (string txHash)
        {
            
    
            var path = "/api/SmartContracts/receipt";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (txHash != null) queryParams.Add("txHash", ApiClient.ParameterToString(txHash)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetReceiptAPI: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetReceiptAPI: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets a single piece of smart contract data, which was stored as a key–value pair using the  SmartContract.PersistentState property.   The method performs a lookup in the smart contract  state database for the supplied smart contract address and key.  The value associated with the given key, deserialized for the specified data type, is returned.  If the key does not exist or deserialization fails, the method returns the default value for  the specified type. 
        /// </summary>
        /// <param name="contractAddress">The address of the smart contract.</param> 
        /// <param name="storageKey">The key for the piece of stored data to retrieve.</param> 
        /// <param name="dataType">The stored data type.</param> 
        /// <returns></returns>            
        public void GetStorage (string contractAddress, string storageKey, string dataType)
        {
            
            // verify the required parameter 'contractAddress' is set
            if (contractAddress == null) throw new ApiException(400, "Missing required parameter 'contractAddress' when calling GetStorage");
            
            // verify the required parameter 'storageKey' is set
            if (storageKey == null) throw new ApiException(400, "Missing required parameter 'storageKey' when calling GetStorage");
            
            // verify the required parameter 'dataType' is set
            if (dataType == null) throw new ApiException(400, "Missing required parameter 'dataType' when calling GetStorage");
            
    
            var path = "/api/SmartContracts/storage";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (contractAddress != null) queryParams.Add("ContractAddress", ApiClient.ParameterToString(contractAddress)); // query parameter
 if (storageKey != null) queryParams.Add("StorageKey", ApiClient.ParameterToString(storageKey)); // query parameter
 if (dataType != null) queryParams.Add("DataType", ApiClient.ParameterToString(dataType)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetStorage: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetStorage: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Makes a local call to a method on a smart contract that has been successfully deployed. A transaction   is not created as the call is never propagated across the network. All persistent data held by the     smart contract is copied before the call is made. Only this copy is altered by the call  and the actual data is unaffected. Even if an amount of funds are specified to send with the call,  no funds are in fact sent.  The purpose of this function is to query and test methods. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to build the transaction.</param> 
        /// <returns></returns>            
        public void LocalCallSmartContractTransaction (LocalCallContractRequest request)
        {
            
    
            var path = "/api/SmartContracts/local-call";
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
                throw new ApiException ((int)response.StatusCode, "Error calling LocalCallSmartContractTransaction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling LocalCallSmartContractTransaction: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Searches a smart contract&#39;s receipts for those which match a specific event. The SmartContract.Log() function  is capable of storing C# structs, and structs are used to store information about different events occurring   on the smart contract. For example, a \&quot;TransferLog\&quot; struct could contain \&quot;From\&quot; and \&quot;To\&quot; fields and be used to log  when a smart contract makes a transfer of funds from one wallet to another. The log entries are held inside the smart contract,  indexed using the name of the struct, and are linked to individual transaction receipts.  Therefore, it is possible to return a smart contract&#39;s transaction receipts  which match a specific event (as defined by the struct name). 
        /// </summary>
        /// <param name="contractAddress">The contract address from which events were raised.</param> 
        /// <param name="eventName">The name of the event raised.</param> 
        /// <param name="topics">The topics to search. All specified topics must be present.</param> 
        /// <param name="fromBlock">The block number from which to start searching.</param> 
        /// <param name="toBlock">The block number where searching finishes.</param> 
        /// <returns></returns>            
        public void ReceiptSearchAPI (string contractAddress, string eventName, List<string> topics, int? fromBlock, int? toBlock)
        {
            
    
            var path = "/api/SmartContracts/receipt-search";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (contractAddress != null) queryParams.Add("contractAddress", ApiClient.ParameterToString(contractAddress)); // query parameter
 if (eventName != null) queryParams.Add("eventName", ApiClient.ParameterToString(eventName)); // query parameter
 if (topics != null) queryParams.Add("topics", ApiClient.ParameterToString(topics)); // query parameter
 if (fromBlock != null) queryParams.Add("fromBlock", ApiClient.ParameterToString(fromBlock)); // query parameter
 if (toBlock != null) queryParams.Add("toBlock", ApiClient.ParameterToString(toBlock)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ReceiptSearchAPI: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ReceiptSearchAPI: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
