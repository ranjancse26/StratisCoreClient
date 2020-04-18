using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// Object to sign a message.
    /// </summary>
    [DataContract]
  public class SignMessageRequest {
    /// <summary>
    /// Gets or Sets WalletName
    /// </summary>
    [DataMember(Name="walletName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "walletName")]
    public string WalletName { get; set; }

    /// <summary>
    /// Gets or Sets Password
    /// </summary>
    [DataMember(Name="password", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }

    /// <summary>
    /// Gets or Sets ExternalAddress
    /// </summary>
    [DataMember(Name="externalAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "externalAddress")]
    public string ExternalAddress { get; set; }

    /// <summary>
    /// Gets or Sets Message
    /// </summary>
    [DataMember(Name="message", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "message")]
    public string Message { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SignMessageRequest {\n");
      sb.Append("  WalletName: ").Append(WalletName).Append("\n");
      sb.Append("  Password: ").Append(Password).Append("\n");
      sb.Append("  ExternalAddress: ").Append(ExternalAddress).Append("\n");
      sb.Append("  Message: ").Append(Message).Append("\n");
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
