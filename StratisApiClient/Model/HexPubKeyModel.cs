using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
  public class HexPubKeyModel {
    /// <summary>
    /// Gets or Sets PubKeyHex
    /// </summary>
    [DataMember(Name="pubKeyHex", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pubKeyHex")]
    public string PubKeyHex { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class HexPubKeyModel {\n");
      sb.Append("  PubKeyHex: ").Append(PubKeyHex).Append("\n");
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
