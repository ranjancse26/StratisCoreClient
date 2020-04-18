using System;
using System.Collections.Generic;
using RestSharp;
using StratisApiClient.Client;

namespace StratisApiClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IConsensusApi
    {
        /// <summary>
        /// Get the threshold states of softforks currently being deployed.  Allowable states are: Defined, Started, LockedIn, Failed, Active. 
        /// </summary>
        /// <returns></returns>
        void DeploymentFlags ();
        /// <summary>
        /// Gets the hash of the block at the consensus tip. This is an API implementation of an RPC call.
        /// </summary>
        /// <returns></returns>
        void GetBestBlockHashAPI ();
        /// <summary>
        /// Gets the hash of the block at a given height. This is an API implementation of an RPC call.
        /// </summary>
        /// <param name="height">The height of the block to get the hash for.</param>
        /// <returns></returns>
        void GetBlockHashAPI (int? height);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ConsensusApi : IConsensusApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsensusApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ConsensusApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsensusApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ConsensusApi(String basePath)
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
        /// Get the threshold states of softforks currently being deployed.  Allowable states are: Defined, Started, LockedIn, Failed, Active. 
        /// </summary>
        /// <returns></returns>            
        public void DeploymentFlags ()
        {
            
    
            var path = "/api/Consensus/deploymentflags";
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
                throw new ApiException ((int)response.StatusCode, "Error calling DeploymentFlags: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DeploymentFlags: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the hash of the block at the consensus tip. This is an API implementation of an RPC call.
        /// </summary>
        /// <returns></returns>            
        public void GetBestBlockHashAPI ()
        {
            
    
            var path = "/api/Consensus/getbestblockhash";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetBestBlockHashAPI: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBestBlockHashAPI: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the hash of the block at a given height. This is an API implementation of an RPC call.
        /// </summary>
        /// <param name="height">The height of the block to get the hash for.</param> 
        /// <returns></returns>            
        public void GetBlockHashAPI (int? height)
        {
            
    
            var path = "/api/Consensus/getblockhash";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (height != null) queryParams.Add("height", ApiClient.ParameterToString(height)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBlockHashAPI: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBlockHashAPI: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
