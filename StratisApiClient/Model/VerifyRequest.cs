using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// Object to verify a signed message.
    /// </summary>
    [DataContract]
  public class VerifyRequest {
    /// <summary>
    /// Gets or Sets Signature
    /// </summary>
    [DataMember(Name="signature", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "signature")]
    public string Signature { get; set; }

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
      sb.Append("class VerifyRequest {\n");
      sb.Append("  Signature: ").Append(Signature).Append("\n");
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
