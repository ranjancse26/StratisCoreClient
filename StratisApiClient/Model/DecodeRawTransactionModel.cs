using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters for a block search request.
    /// </summary>
    [DataContract]
  public class DecodeRawTransactionModel {
    /// <summary>
    /// The transaction to be decoded in hex format.
    /// </summary>
    /// <value>The transaction to be decoded in hex format.</value>
    [DataMember(Name="rawHex", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rawHex")]
    public string RawHex { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DecodeRawTransactionModel {\n");
      sb.Append("  RawHex: ").Append(RawHex).Append("\n");
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
