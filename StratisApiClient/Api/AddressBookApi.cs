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
    public interface IAddressBookApi
    {
        /// <summary>
        /// Adds an entry to the address book. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to add an address book entry.</param>
        /// <returns></returns>
        void AddAddress (AddressBookEntryRequest request);
        /// <summary>
        /// Gets the address book entries with the option to implement pagination.  For example, specifying a value of 40 for skip and a value of 20 for take  gets entries 21 to 40.  If neither skip or take arguments are provided, then the entire address  book is retrieved.  An address book can be accessed from a wallet, but it is a standalone feature,  which is not attached to any wallet. 
        /// </summary>
        /// <param name="skip">A value representing how many entries to skip before retrieving the first entry.</param>
        /// <param name="take">A value representing how many entries to retrieve.</param>
        /// <returns></returns>
        void GetAddressBook (int? skip, int? take);
        /// <summary>
        /// Removes an entry from the address book. 
        /// </summary>
        /// <param name="label">The label of the entry to remove.</param>
        /// <returns></returns>
        void RemoveAddress (string label);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AddressBookApi : IAddressBookApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AddressBookApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AddressBookApi(String basePath)
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
        /// Adds an entry to the address book. 
        /// </summary>
        /// <param name="request">An object containing the necessary parameters to add an address book entry.</param> 
        /// <returns></returns>            
        public void AddAddress (AddressBookEntryRequest request)
        {
            
    
            var path = "/api/AddressBook/address";
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
                throw new ApiException ((int)response.StatusCode, "Error calling AddAddress: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling AddAddress: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Gets the address book entries with the option to implement pagination.  For example, specifying a value of 40 for skip and a value of 20 for take  gets entries 21 to 40.  If neither skip or take arguments are provided, then the entire address  book is retrieved.  An address book can be accessed from a wallet, but it is a standalone feature,  which is not attached to any wallet. 
        /// </summary>
        /// <param name="skip">A value representing how many entries to skip before retrieving the first entry.</param> 
        /// <param name="take">A value representing how many entries to retrieve.</param> 
        /// <returns></returns>            
        public void GetAddressBook (int? skip, int? take)
        {
            
    
            var path = "/api/AddressBook";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skip != null) queryParams.Add("skip", ApiClient.ParameterToString(skip)); // query parameter
 if (take != null) queryParams.Add("take", ApiClient.ParameterToString(take)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressBook: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetAddressBook: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Removes an entry from the address book. 
        /// </summary>
        /// <param name="label">The label of the entry to remove.</param> 
        /// <returns></returns>            
        public void RemoveAddress (string label)
        {
            
    
            var path = "/api/AddressBook/address";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (label != null) queryParams.Add("label", ApiClient.ParameterToString(label)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveAddress: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveAddress: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
