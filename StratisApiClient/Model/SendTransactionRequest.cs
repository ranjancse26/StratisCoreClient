using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters for a send transaction request.
    /// </summary>
    [DataContract]
  public class SendTransactionRequest {
    /// <summary>
    /// A string containing the transaction in hexadecimal format.
    /// </summary>
    /// <value>A string containing the transaction in hexadecimal format.</value>
    [DataMember(Name="hex", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "hex")]
    public string Hex { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SendTransactionRequest {\n");
      sb.Append("  Hex: ").Append(Hex).Append("\n");
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
