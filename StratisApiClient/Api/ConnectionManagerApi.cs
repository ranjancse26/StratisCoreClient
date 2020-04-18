using System;
using System.Collections.Generic;
using RestSharp;
using StratisApiClient.Client;

namespace StratisApiClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IConnectionManagerApi
    {
        /// <summary>
        /// Sends a command to the connection manager. This is an API implementation of an RPC call.
        /// </summary>
        /// <param name="endpoint">The endpoint in string format. Specify an IP address. The default port for the network will be added automatically.</param>
        /// <param name="command">The command to run. {add, remove, onetry}</param>
        /// <returns></returns>
        void AddNodeAPI (string endpoint, string command);
        /// <summary>
        /// Gets information about this node. This is an API implementation of an RPC call.
        /// </summary>
        /// <returns></returns>
        void GetPeerInfoAPI ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ConnectionManagerApi : IConnectionManagerApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionManagerApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ConnectionManagerApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionManagerApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ConnectionManagerApi(String basePath)
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
        /// Sends a command to the connection manager. This is an API implementation of an RPC call.
        /// </summary>
        /// <param name="endpoint">The endpoint in string format. Specify an IP address. The default port for the network will be added automatically.</param> 
        /// <param name="command">The command to run. {add, remove, onetry}</param> 
        /// <returns></returns>            
        public void AddNodeAPI (string endpoint, string command)
        {
            
    
            var path = "/api/ConnectionManager/addnode";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (endpoint != null) queryParams.Add("endpoint", ApiClient.ParameterToString(endpoint)); // query parameter
 if (command != null) queryParams.Add("command", ApiClient.ParameterToString(command)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling AddNodeAPI: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling AddNodeAPI: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets information about this node. This is an API implementation of an RPC call.
        /// </summary>
        /// <returns></returns>            
        public void GetPeerInfoAPI ()
        {
            
    
            var path = "/api/ConnectionManager/getpeerinfo";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetPeerInfoAPI: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetPeerInfoAPI: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
