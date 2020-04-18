using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters for a wallet resynchronization request  which takes the hash of the block to resync after.
    /// </summary>
    [DataContract]
  public class HashModel {
    /// <summary>
    /// The hash of the block to resync after.
    /// </summary>
    /// <value>The hash of the block to resync after.</value>
    [DataMember(Name="hash", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "hash")]
    public string Hash { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class HashModel {\n");
      sb.Append("  Hash: ").Append(Hash).Append("\n");
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
