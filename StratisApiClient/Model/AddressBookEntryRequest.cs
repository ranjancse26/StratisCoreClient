using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters to perform an add address book entry request.
    /// </summary>
    [DataContract]
  public class AddressBookEntryRequest {
    /// <summary>
    /// A label to attach to the address book entry.
    /// </summary>
    /// <value>A label to attach to the address book entry.</value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// The address to enter in the address book.
    /// </summary>
    /// <value>The address to enter in the address book.</value>
    [DataMember(Name="address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "address")]
    public string Address { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddressBookEntryRequest {\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
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
