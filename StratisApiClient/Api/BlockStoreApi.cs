using System;
using System.Collections.Generic;
using RestSharp;
using StratisApiClient.Client;

namespace StratisApiClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBlockStoreApi
    {
        /// <summary>
        /// Retrieves the Stratis.Bitcoin.Features.BlockStore.Controllers.BlockStoreController.addressIndexer&#39;s tip. 
        /// </summary>
        /// <returns></returns>
        void GetAddressIndexerTip ();
        /// <summary>
        /// Provides balance of the given addresses confirmed with at least minConfirmations confirmations. 
        /// </summary>
        /// <param name="addresses">A comma delimited set of addresses that will be queried.</param>
        /// <param name="minConfirmations">Only blocks below consensus tip less this parameter will be considered.</param>
        /// <returns></returns>
        void GetAddressesBalances (string addresses, int? minConfirmations);
        /// <summary>
        /// Retrieves the block which matches the supplied block hash. 
        /// </summary>
        /// <param name="hash">The hash of the required block.</param>
        /// <param name="showTransactionDetails">A flag that indicates whether to return each block transaction complete with details  or simply return transaction hashes (TX IDs).</param>
        /// <param name="outputJson"></param>
        /// <returns></returns>
        void GetBlock (string hash, bool? showTransactionDetails, bool? outputJson);
        /// <summary>
        /// Gets the current consensus tip height. This is an API implementation of an RPC call.
        /// </summary>
        /// <returns></returns>
        void GetBlockCount ();
        /// <summary>
        /// Provides verbose balance data of the given addresses. 
        /// </summary>
        /// <param name="addresses">A comma delimited set of addresses that will be queried.</param>
        /// <returns></returns>
        void GetVerboseAddressesBalancesData (string addresses);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BlockStoreApi : IBlockStoreApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockStoreApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public BlockStoreApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockStoreApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BlockStoreApi(String basePath)
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
        /// Retrieves the Stratis.Bitcoin.Features.BlockStore.Controllers.BlockStoreController.addressIndexer&#39;s tip. 
        /// </summary>
        /// <returns></returns>            
        public void GetAddressIndexerTip ()
        {
            
    
            var path = "/api/BlockStore/addressindexertip";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressIndexerTip: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressIndexerTip: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Provides balance of the given addresses confirmed with at least minConfirmations confirmations. 
        /// </summary>
        /// <param name="addresses">A comma delimited set of addresses that will be queried.</param> 
        /// <param name="minConfirmations">Only blocks below consensus tip less this parameter will be considered.</param> 
        /// <returns></returns>            
        public void GetAddressesBalances (string addresses, int? minConfirmations)
        {
            
    
            var path = "/api/BlockStore/getaddressesbalances";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (addresses != null) queryParams.Add("addresses", ApiClient.ParameterToString(addresses)); // query parameter
 if (minConfirmations != null) queryParams.Add("minConfirmations", ApiClient.ParameterToString(minConfirmations)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressesBalances: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressesBalances: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Retrieves the block which matches the supplied block hash. 
        /// </summary>
        /// <param name="hash">The hash of the required block.</param> 
        /// <param name="showTransactionDetails">A flag that indicates whether to return each block transaction complete with details  or simply return transaction hashes (TX IDs).</param> 
        /// <param name="outputJson"></param> 
        /// <returns></returns>            
        public void GetBlock (string hash, bool? showTransactionDetails, bool? outputJson)
        {
            
            // verify the required parameter 'hash' is set
            if (hash == null) throw new ApiException(400, "Missing required parameter 'hash' when calling GetBlock");
            
    
            var path = "/api/BlockStore/block";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (hash != null) queryParams.Add("Hash", ApiClient.ParameterToString(hash)); // query parameter
 if (showTransactionDetails != null) queryParams.Add("ShowTransactionDetails", ApiClient.ParameterToString(showTransactionDetails)); // query parameter
 if (outputJson != null) queryParams.Add("OutputJson", ApiClient.ParameterToString(outputJson)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBlock: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBlock: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the current consensus tip height. This is an API implementation of an RPC call.
        /// </summary>
        /// <returns></returns>            
        public void GetBlockCount ()
        {
            
    
            var path = "/api/BlockStore/GetBlockCount";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBlockCount: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBlockCount: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Provides verbose balance data of the given addresses. 
        /// </summary>
        /// <param name="addresses">A comma delimited set of addresses that will be queried.</param> 
        /// <returns></returns>            
        public void GetVerboseAddressesBalancesData (string addresses)
        {
            
    
            var path = "/api/BlockStore/getverboseaddressesbalances";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (addresses != null) queryParams.Add("addresses", ApiClient.ParameterToString(addresses)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetVerboseAddressesBalancesData: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetVerboseAddressesBalancesData: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
