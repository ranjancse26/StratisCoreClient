using System;
using System.Collections.Generic;
using RestSharp;
using StratisApiClient.Client;

namespace StratisApiClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IContractSwaggerApi
    {
        /// <summary>
        /// Dynamically generates a swagger document for the contract at the given address. 
        /// </summary>
        /// <param name="address">The contract&#39;s address.</param>
        /// <returns></returns>
        void ContractSwaggerDoc (string address);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ContractSwaggerApi : IContractSwaggerApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractSwaggerApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ContractSwaggerApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractSwaggerApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContractSwaggerApi(String basePath)
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
        /// Dynamically generates a swagger document for the contract at the given address. 
        /// </summary>
        /// <param name="address">The contract&#39;s address.</param> 
        /// <returns></returns>            
        public void ContractSwaggerDoc (string address)
        {
            
            // verify the required parameter 'address' is set
            if (address == null) throw new ApiException(400, "Missing required parameter 'address' when calling ContractSwaggerDoc");
            
    
            var path = "/swagger/contracts/{address}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "address" + "}", ApiClient.ParameterToString(address));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ContractSwaggerDoc: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ContractSwaggerDoc: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
