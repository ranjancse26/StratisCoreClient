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
    public interface IFederationVotingApi
    {
        /// <summary>
        /// Votes to add a federation member. 
        /// </summary>
        /// <param name="request">Request containing member public key</param>
        /// <returns></returns>
        void VoteAddFedMember (HexPubKeyModel request);
        /// <summary>
        /// Votes to kick a federation member. 
        /// </summary>
        /// <param name="request">Request containing member public key</param>
        /// <returns></returns>
        void VoteKickFedMember (HexPubKeyModel request);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class FederationVotingApi : IFederationVotingApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FederationVotingApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public FederationVotingApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="FederationVotingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FederationVotingApi(String basePath)
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
        /// Votes to add a federation member. 
        /// </summary>
        /// <param name="request">Request containing member public key</param> 
        /// <returns></returns>            
        public void VoteAddFedMember (HexPubKeyModel request)
        {
            
    
            var path = "/api/FederationVoting/schedulevote-addfedmember";
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
                throw new ApiException ((int)response.StatusCode, "Error calling VoteAddFedMember: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling VoteAddFedMember: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Votes to kick a federation member. 
        /// </summary>
        /// <param name="request">Request containing member public key</param> 
        /// <returns></returns>            
        public void VoteKickFedMember (HexPubKeyModel request)
        {
            
    
            var path = "/api/FederationVoting/schedulevote-kickfedmember";
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
                throw new ApiException ((int)response.StatusCode, "Error calling VoteKickFedMember: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling VoteKickFedMember: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
