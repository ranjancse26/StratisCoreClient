using System;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters for a wallet recovery request using its extended public key.  Note that the recovered wallet will not have a private key and is  only suitable for returning the wallet history using further API calls. As such,  only the extended public key is used in the recovery process.
    /// </summary>
    [DataContract]
  public class WalletExtPubRecoveryRequest {
    /// <summary>
    /// The extended public key used by the wallet.
    /// </summary>
    /// <value>The extended public key used by the wallet.</value>
    [DataMember(Name="extPubKey", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "extPubKey")]
    public string ExtPubKey { get; set; }

    /// <summary>
    /// The index of the account to generate for the wallet. For example, specifying a value of 0  generates \"account0\".
    /// </summary>
    /// <value>The index of the account to generate for the wallet. For example, specifying a value of 0  generates \"account0\".</value>
    [DataMember(Name="accountIndex", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountIndex")]
    public int? AccountIndex { get; set; }

    /// <summary>
    /// The name to give the recovered wallet.
    /// </summary>
    /// <value>The name to give the recovered wallet.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The creation date and time to give the recovered wallet.
    /// </summary>
    /// <value>The creation date and time to give the recovered wallet.</value>
    [DataMember(Name="creationDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creationDate")]
    public DateTime? CreationDate { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class WalletExtPubRecoveryRequest {\n");
      sb.Append("  ExtPubKey: ").Append(ExtPubKey).Append("\n");
      sb.Append("  AccountIndex: ").Append(AccountIndex).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  CreationDate: ").Append(CreationDate).Append("\n");
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
