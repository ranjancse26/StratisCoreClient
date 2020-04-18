using System;
using System.Collections.Generic;
using RestSharp;
using StratisApiClient.Client;

namespace StratisApiClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDynamicContractApi
    {
        /// <summary>
        /// Call a method on the contract by broadcasting a call transaction to the network. 
        /// </summary>
        /// <param name="address">The address of the contract to call.</param>
        /// <param name="method">The name of the method on the contract being called.</param>
        /// <returns></returns>
        void CallMethod (string address, string method);
        /// <summary>
        /// Query the value of a property on the contract using a local call. 
        /// </summary>
        /// <param name="address">The address of the contract to query.</param>
        /// <param name="property">The name of the property to query.</param>
        /// <returns></returns>
        void LocalCallProperty (string address, string property);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DynamicContractApi : IDynamicContractApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicContractApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DynamicContractApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicContractApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DynamicContractApi(String basePath)
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
        /// Call a method on the contract by broadcasting a call transaction to the network. 
        /// </summary>
        /// <param name="address">The address of the contract to call.</param> 
        /// <param name="method">The name of the method on the contract being called.</param> 
        /// <returns></returns>            
        public void CallMethod (string address, string method)
        {
            
            // verify the required parameter 'address' is set
            if (address == null) throw new ApiException(400, "Missing required parameter 'address' when calling CallMethod");
            
            // verify the required parameter 'method' is set
            if (method == null) throw new ApiException(400, "Missing required parameter 'method' when calling CallMethod");
            
    
            var path = "/api/contract/{address}/method/{method}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "address" + "}", ApiClient.ParameterToString(address));
path = path.Replace("{" + "method" + "}", ApiClient.ParameterToString(method));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CallMethod: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CallMethod: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Query the value of a property on the contract using a local call. 
        /// </summary>
        /// <param name="address">The address of the contract to query.</param> 
        /// <param name="property">The name of the property to query.</param> 
        /// <returns></returns>            
        public void LocalCallProperty (string address, string property)
        {
            
            // verify the required parameter 'address' is set
            if (address == null) throw new ApiException(400, "Missing required parameter 'address' when calling LocalCallProperty");
            
            // verify the required parameter 'property' is set
            if (property == null) throw new ApiException(400, "Missing required parameter 'property' when calling LocalCallProperty");
            
    
            var path = "/api/contract/{address}/property/{property}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "address" + "}", ApiClient.ParameterToString(address));
path = path.Replace("{" + "property" + "}", ApiClient.ParameterToString(property));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling LocalCallProperty: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling LocalCallProperty: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
