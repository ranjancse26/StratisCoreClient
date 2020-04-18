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
    public interface IDiagnosticApi
    {
        /// <summary>
        /// Returns the connected peers with some information 
        /// </summary>
        /// <returns></returns>
        void GetConnectedPeersInfo ();
        /// <summary>
        /// Returns the connected peers with some statistical information. 
        /// </summary>
        /// <param name="connectedOnly">if set to {true} returns statistics related to connected peers only.</param>
        /// <returns>List&lt;PeerStatisticsModel&gt;</returns>
        List<PeerStatisticsModel> GetPeerStatistics (bool? connectedOnly);
        /// <summary>
        /// Gets the Diagnostic Feature status. 
        /// </summary>
        /// <returns></returns>
        void GetStatus ();
        /// <summary>
        /// Starts collecting peers statistics. 
        /// </summary>
        /// <returns></returns>
        void StartCollectingPeerStatistics ();
        /// <summary>
        /// Stops collecting peers statistics.  Stopping a running peer statistic collecotr doesn&#39;t clear obtained results. 
        /// </summary>
        /// <returns></returns>
        void StopCollectingPeerStatistics ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DiagnosticApi : IDiagnosticApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DiagnosticApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DiagnosticApi(String basePath)
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
        /// Returns the connected peers with some information 
        /// </summary>
        /// <returns></returns>            
        public void GetConnectedPeersInfo ()
        {
            
    
            var path = "/api/Diagnostic/GetConnectedPeersInfo";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetConnectedPeersInfo: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetConnectedPeersInfo: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Returns the connected peers with some statistical information. 
        /// </summary>
        /// <param name="connectedOnly">if set to {true} returns statistics related to connected peers only.</param> 
        /// <returns>List&lt;PeerStatisticsModel&gt;</returns>            
        public List<PeerStatisticsModel> GetPeerStatistics (bool? connectedOnly)
        {
            
    
            var path = "/api/Diagnostic/GetPeerStatistics";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (connectedOnly != null) queryParams.Add("connectedOnly", ApiClient.ParameterToString(connectedOnly)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetPeerStatistics: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetPeerStatistics: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<PeerStatisticsModel>) ApiClient.Deserialize(response.Content, typeof(List<PeerStatisticsModel>), response.Headers);
        }
    
        /// <summary>
        /// Gets the Diagnostic Feature status. 
        /// </summary>
        /// <returns></returns>            
        public void GetStatus ()
        {
            
    
            var path = "/api/Diagnostic/GetStatus";
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetStatus: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetStatus: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Starts collecting peers statistics. 
        /// </summary>
        /// <returns></returns>            
        public void StartCollectingPeerStatistics ()
        {
            
    
            var path = "/api/Diagnostic/StartCollectingPeerStatistics";
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
                throw new ApiException ((int)response.StatusCode, "Error calling StartCollectingPeerStatistics: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling StartCollectingPeerStatistics: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Stops collecting peers statistics.  Stopping a running peer statistic collecotr doesn&#39;t clear obtained results. 
        /// </summary>
        /// <returns></returns>            
        public void StopCollectingPeerStatistics ()
        {
            
    
            var path = "/api/Diagnostic/StopCollectingPeerStatistics";
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
                throw new ApiException ((int)response.StatusCode, "Error calling StopCollectingPeerStatistics: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling StopCollectingPeerStatistics: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
