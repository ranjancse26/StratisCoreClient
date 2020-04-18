using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
  public class RecipientModel {
    /// <summary>
    /// The destination address.
    /// </summary>
    /// <value>The destination address.</value>
    [DataMember(Name="destinationAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "destinationAddress")]
    public string DestinationAddress { get; set; }

    /// <summary>
    /// The amount that will be sent.
    /// </summary>
    /// <value>The amount that will be sent.</value>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public string Amount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RecipientModel {\n");
      sb.Append("  DestinationAddress: ").Append(DestinationAddress).Append("\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
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
