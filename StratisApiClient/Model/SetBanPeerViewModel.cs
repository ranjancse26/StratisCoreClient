using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// Represents the model that will ban and disconnect a connected peer.
    /// </summary>
    [DataContract]
  public class SetBanPeerViewModel {
    /// <summary>
    /// Whether to add or remove the node from the banned list.  <para>  Options are \"Add\" or \"Remove\".  </para>
    /// </summary>
    /// <value>Whether to add or remove the node from the banned list.  <para>  Options are \"Add\" or \"Remove\".  </para></value>
    [DataMember(Name="banCommand", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "banCommand")]
    public string BanCommand { get; set; }

    /// <summary>
    /// The duration in seconds the peer will be banned.
    /// </summary>
    /// <value>The duration in seconds the peer will be banned.</value>
    [DataMember(Name="banDurationSeconds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "banDurationSeconds")]
    public int? BanDurationSeconds { get; set; }

    /// <summary>
    /// The IP address of the connected peer to ban.  <para>  The port should not be specified in this instance.  </para>
    /// </summary>
    /// <value>The IP address of the connected peer to ban.  <para>  The port should not be specified in this instance.  </para></value>
    [DataMember(Name="peerAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "peerAddress")]
    public string PeerAddress { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SetBanPeerViewModel {\n");
      sb.Append("  BanCommand: ").Append(BanCommand).Append("\n");
      sb.Append("  BanDurationSeconds: ").Append(BanDurationSeconds).Append("\n");
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
