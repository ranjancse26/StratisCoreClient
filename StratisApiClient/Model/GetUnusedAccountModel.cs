using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters for a new account request.
    /// </summary>
    [DataContract]
  public class GetUnusedAccountModel {
    /// <summary>
    /// The name of the wallet in which to create the account.
    /// </summary>
    /// <value>The name of the wallet in which to create the account.</value>
    [DataMember(Name="walletName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "walletName")]
    public string WalletName { get; set; }

    /// <summary>
    /// The password for the wallet.
    /// </summary>
    /// <value>The password for the wallet.</value>
    [DataMember(Name="password", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GetUnusedAccountModel {\n");
      sb.Append("  WalletName: ").Append(WalletName).Append("\n");
      sb.Append("  Password: ").Append(Password).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
