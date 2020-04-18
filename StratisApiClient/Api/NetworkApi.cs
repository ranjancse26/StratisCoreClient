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
    public interface INetworkApi
    {
        /// <summary>
        /// Clears the node of all banned peers. &lt;seealso href&#x3D;\&quot;https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Simple_requests\&quot; /&gt;
        /// </summary>
        /// <param name="corsProtection">This body parameter is here to prevent a CORS call from triggering method execution.</param>
        /// <returns></returns>
        void ClearBannedPeers (bool? corsProtection);
        /// <summary>
        /// Disconnects a connected peer. 
        /// </summary>
        /// <param name="viewModel">The model that represents the peer to disconnect.</param>
        /// <returns></returns>
        void DisconnectPeer (DisconnectPeerViewModel viewModel);
        /// <summary>
        /// Retrieves a list of all banned peers. 
        /// </summary>
        /// <returns></returns>
        void GetBans ();
        /// <summary>
        /// Adds or remove a peer from the node&#39;s banned peers list. 
        /// </summary>
        /// <param name="viewModel">The model that represents the peer to add or remove from the banned list.</param>
        /// <returns></returns>
        void SetBan (SetBanPeerViewModel viewModel);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class NetworkApi : INetworkApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public NetworkApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkApi"/> class.
        /// </summary>
        /// <returns></returns>
        public NetworkApi(String basePath)
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
        /// Clears the node of all banned peers. &lt;seealso href&#x3D;\&quot;https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Simple_requests\&quot; /&gt;
        /// </summary>
        /// <param name="corsProtection">This body parameter is here to prevent a CORS call from triggering method execution.</param> 
        /// <returns></returns>            
        public void ClearBannedPeers (bool? corsProtection)
        {
            
    
            var path = "/api/Network/clearbanned";
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
                throw new ApiException ((int)response.StatusCode, "Error calling ClearBannedPeers: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ClearBannedPeers: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Disconnects a connected peer. 
        /// </summary>
        /// <param name="viewModel">The model that represents the peer to disconnect.</param> 
        /// <returns></returns>            
        public void DisconnectPeer (DisconnectPeerViewModel viewModel)
        {
            
    
            var path = "/api/Network/disconnect";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(viewModel); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DisconnectPeer: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DisconnectPeer: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Retrieves a list of all banned peers. 
        /// </summary>
        /// <returns></returns>            
        public void GetBans ()
        {
            
    
            var path = "/api/Network/getbans";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetBans: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetBans: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Adds or remove a peer from the node&#39;s banned peers list. 
        /// </summary>
        /// <param name="viewModel">The model that represents the peer to add or remove from the banned list.</param> 
        /// <returns></returns>            
        public void SetBan (SetBanPeerViewModel viewModel)
        {
            
    
            var path = "/api/Network/setban";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(viewModel); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SetBan: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SetBan: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
