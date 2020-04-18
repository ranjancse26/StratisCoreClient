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
    public interface INodeApi
    {
        /// <summary>
        /// Gets a JSON representation for a given transaction in hex format. 
        /// </summary>
        /// <param name="request">A class containing the necessary parameters for a block search request.</param>
        /// <returns></returns>
        void DecodeRawTransaction (DecodeRawTransactionModel request);
        /// <summary>
        /// Get the currently running async loops/delegates/tasks for diagnostic purposes. 
        /// </summary>
        /// <returns></returns>
        void GetAsyncLoops ();
        /// <summary>
        /// Gets the block header of a block identified by a block hash. Binary serialization is not supported with this method.
        /// </summary>
        /// <param name="hash">The hash of the block to retrieve.</param>
        /// <param name="isJsonFormat">A flag that specifies whether to return the block header in the JSON format. Defaults to true. A value of false is currently not supported.</param>
        /// <returns></returns>
        void GetBlockHeader (string hash, bool? isJsonFormat);
        /// <summary>
        /// Get the enabled log rules. 
        /// </summary>
        /// <returns></returns>
        void GetLogRules ();
        /// <summary>
        /// Gets a raw transaction that is present on this full node.  This method first searches the transaction pool and then tries the block store. Requires txindex&#x3D;1, otherwise only txes that spend or create UTXOs for a wallet can be returned.
        /// </summary>
        /// <param name="trxid">The transaction ID (a hash of the trancaction).</param>
        /// <param name="verbose">A flag that specifies whether to return verbose information about the transaction.</param>
        /// <returns></returns>
        void GetRawTransactionAsync (string trxid, bool? verbose);
        /// <summary>
        /// Gets the unspent outputs of a specific vout in a transaction.  API implementation of RPC call. 
        /// </summary>
        /// <param name="trxid">The transaction ID as a hash string.</param>
        /// <param name="vout">The vout to get the unspent outputs for.</param>
        /// <param name="includeMemPool">A flag that specifies whether to include transactions in the mempool.</param>
        /// <returns></returns>
        void GetTxOutAsync (string trxid, int? vout, bool? includeMemPool);
        /// <summary>
        /// Triggers a shutdown of this node. &lt;seealso cref&#x3D;\&quot;!:https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Simple_requests\&quot; /&gt;
        /// </summary>
        /// <param name="corsProtection">This body parameter is here to prevent a Cross Origin Resource Sharing              (CORS) call from triggering method execution. CORS relaxes security and you can read more about this              &lt;a href&#x3D;\&quot;https://docs.microsoft.com/en-us/aspnet/core/security/cors?view&#x3D;aspnetcore-2.1\&quot;&gt;here&lt;/a&gt;.</param>
        /// <returns></returns>
        void Shutdown (bool? corsProtection);
        /// <summary>
        /// Triggers a shutdown of this node. &lt;seealso cref&#x3D;\&quot;!:https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Simple_requests\&quot; /&gt;
        /// </summary>
        /// <param name="corsProtection">This body parameter is here to prevent a Cross Origin Resource Sharing              (CORS) call from triggering method execution. CORS relaxes security and you can read more about this              &lt;a href&#x3D;\&quot;https://docs.microsoft.com/en-us/aspnet/core/security/cors?view&#x3D;aspnetcore-2.1\&quot;&gt;here&lt;/a&gt;.</param>
        /// <returns></returns>
        void Shutdown_1 (bool? corsProtection);
        /// <summary>
        /// Gets general information about this full node including the version,  protocol version, network name, coin ticker, and consensus height. 
        /// </summary>
        /// <returns></returns>
        void Status ();
        /// <summary>
        /// Changes the log levels for the specified loggers. 
        /// </summary>
        /// <param name="request">The request containing the loggers to modify.</param>
        /// <returns></returns>
        void UpdateLogLevel (LogRulesRequest request);
        /// <summary>
        /// Validates a bech32 or base58 bitcoin address. 
        /// </summary>
        /// <param name="address">A Bitcoin address to validate in a string format.</param>
        /// <returns></returns>
        void ValidateAddress (string address);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class NodeApi : INodeApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public NodeApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeApi"/> class.
        /// </summary>
        /// <returns></returns>
        public NodeApi(String basePath)
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
        /// Gets a JSON representation for a given transaction in hex format. 
        /// </summary>
        /// <param name="request">A class containing the necessary parameters for a block search request.</param> 
        /// <returns></returns>            
        public void DecodeRawTransaction (DecodeRawTransactionModel request)
        {
            
    
            var path = "/api/Node/decoderawtransaction";
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
                throw new ApiException ((int)response.StatusCode, "Error calling DecodeRawTransaction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DecodeRawTransaction: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get the currently running async loops/delegates/tasks for diagnostic purposes. 
        /// </summary>
        /// <returns></returns>            
        public void GetAsyncLoops ()
        {
            
    
            var path = "/api/Node/asyncloops";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetAsyncLoops: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAsyncLoops: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the block header of a block identified by a block hash. Binary serialization is not supported with this method.
        /// </summary>
        /// <param name="hash">The hash of the block to retrieve.</param> 
        /// <param name="isJsonFormat">A flag that specifies whether to return the block header in the JSON format. Defaults to true. A value of false is currently not supported.</param> 
        /// <returns></returns>            
        public void GetBlockHeader (string hash, bool? isJsonFormat)
        {
            
    
            var path = "/api/Node/getblockheader";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (hash != null) queryParams.Add("hash", ApiClient.ParameterToString(hash)); // query parameter
 if (isJsonFormat != null) queryParams.Add("isJsonFormat", ApiClient.ParameterToString(isJsonFormat)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBlockHeader: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBlockHeader: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get the enabled log rules. 
        /// </summary>
        /// <returns></returns>            
        public void GetLogRules ()
        {
            
    
            var path = "/api/Node/logrules";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetLogRules: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetLogRules: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets a raw transaction that is present on this full node.  This method first searches the transaction pool and then tries the block store. Requires txindex&#x3D;1, otherwise only txes that spend or create UTXOs for a wallet can be returned.
        /// </summary>
        /// <param name="trxid">The transaction ID (a hash of the trancaction).</param> 
        /// <param name="verbose">A flag that specifies whether to return verbose information about the transaction.</param> 
        /// <returns></returns>            
        public void GetRawTransactionAsync (string trxid, bool? verbose)
        {
            
    
            var path = "/api/Node/getrawtransaction";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (trxid != null) queryParams.Add("trxid", ApiClient.ParameterToString(trxid)); // query parameter
 if (verbose != null) queryParams.Add("verbose", ApiClient.ParameterToString(verbose)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRawTransactionAsync: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRawTransactionAsync: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the unspent outputs of a specific vout in a transaction.  API implementation of RPC call. 
        /// </summary>
        /// <param name="trxid">The transaction ID as a hash string.</param> 
        /// <param name="vout">The vout to get the unspent outputs for.</param> 
        /// <param name="includeMemPool">A flag that specifies whether to include transactions in the mempool.</param> 
        /// <returns></returns>            
        public void GetTxOutAsync (string trxid, int? vout, bool? includeMemPool)
        {
            
    
            var path = "/api/Node/gettxout";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (trxid != null) queryParams.Add("trxid", ApiClient.ParameterToString(trxid)); // query parameter
 if (vout != null) queryParams.Add("vout", ApiClient.ParameterToString(vout)); // query parameter
 if (includeMemPool != null) queryParams.Add("includeMemPool", ApiClient.ParameterToString(includeMemPool)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTxOutAsync: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTxOutAsync: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Triggers a shutdown of this node. &lt;seealso cref&#x3D;\&quot;!:https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Simple_requests\&quot; /&gt;
        /// </summary>
        /// <param name="corsProtection">This body parameter is here to prevent a Cross Origin Resource Sharing              (CORS) call from triggering method execution. CORS relaxes security and you can read more about this              &lt;a href&#x3D;\&quot;https://docs.microsoft.com/en-us/aspnet/core/security/cors?view&#x3D;aspnetcore-2.1\&quot;&gt;here&lt;/a&gt;.</param> 
        /// <returns></returns>            
        public void Shutdown (bool? corsProtection)
        {
            
    
            var path = "/api/Node/shutdown";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(corsProtection); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Shutdown: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Shutdown: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Triggers a shutdown of this node. &lt;seealso cref&#x3D;\&quot;!:https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Simple_requests\&quot; /&gt;
        /// </summary>
        /// <param name="corsProtection">This body parameter is here to prevent a Cross Origin Resource Sharing              (CORS) call from triggering method execution. CORS relaxes security and you can read more about this              &lt;a href&#x3D;\&quot;https://docs.microsoft.com/en-us/aspnet/core/security/cors?view&#x3D;aspnetcore-2.1\&quot;&gt;here&lt;/a&gt;.</param> 
        /// <returns></returns>            
        public void Shutdown_1 (bool? corsProtection)
        {
            
    
            var path = "/api/Node/stop";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(corsProtection); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Shutdown_1: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Shutdown_1: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets general information about this full node including the version,  protocol version, network name, coin ticker, and consensus height. 
        /// </summary>
        /// <returns></returns>            
        public void Status ()
        {
            
    
            var path = "/api/Node/status";
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
                throw new ApiException ((int)response.StatusCode, "Error calling Status: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Status: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Changes the log levels for the specified loggers. 
        /// </summary>
        /// <param name="request">The request containing the loggers to modify.</param> 
        /// <returns></returns>            
        public void UpdateLogLevel (LogRulesRequest request)
        {
            
    
            var path = "/api/Node/loglevels";
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
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateLogLevel: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling UpdateLogLevel: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Validates a bech32 or base58 bitcoin address. 
        /// </summary>
        /// <param name="address">A Bitcoin address to validate in a string format.</param> 
        /// <returns></returns>            
        public void ValidateAddress (string address)
        {
            
    
            var path = "/api/Node/validateaddress";
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
                throw new ApiException ((int)response.StatusCode, "Error calling ValidateAddress: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ValidateAddress: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
