using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// Represents the model that will disconnect a connected peer.
    /// </summary>
    [DataContract]
  public class DisconnectPeerViewModel {
    /// <summary>
    /// The IP address and port of the connected peer to disconnect.
    /// </summary>
    /// <value>The IP address and port of the connected peer to disconnect.</value>
    [DataMember(Name="peerAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "peerAddress")]
    public string PeerAddress { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DisconnectPeerViewModel {\n");
      sb.Append("  PeerAddress: ").Append(PeerAddress).Append("\n");
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
