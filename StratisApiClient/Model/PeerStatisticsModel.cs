using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
  public class PeerStatisticsModel {
    /// <summary>
    /// Gets or Sets PeerEndPoint
    /// </summary>
    [DataMember(Name="peerEndPoint", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "peerEndPoint")]
    public string PeerEndPoint { get; set; }

    /// <summary>
    /// Gets or Sets Connected
    /// </summary>
    [DataMember(Name="connected", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "connected")]
    public bool? Connected { get; set; }

    /// <summary>
    /// Gets or Sets Inbound
    /// </summary>
    [DataMember(Name="inbound", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "inbound")]
    public bool? Inbound { get; set; }

    /// <summary>
    /// Gets or Sets BytesSent
    /// </summary>
    [DataMember(Name="bytesSent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bytesSent")]
    public long? BytesSent { get; set; }

    /// <summary>
    /// Gets or Sets BytesReceived
    /// </summary>
    [DataMember(Name="bytesReceived", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bytesReceived")]
    public long? BytesReceived { get; set; }

    /// <summary>
    /// Gets or Sets ReceivedMessages
    /// </summary>
    [DataMember(Name="receivedMessages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "receivedMessages")]
    public int? ReceivedMessages { get; set; }

    /// <summary>
    /// Gets or Sets SentMessages
    /// </summary>
    [DataMember(Name="sentMessages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sentMessages")]
    public int? SentMessages { get; set; }

    /// <summary>
    /// Gets or Sets LatestEvents
    /// </summary>
    [DataMember(Name="latestEvents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "latestEvents")]
    public List<string> LatestEvents { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PeerStatisticsModel {\n");
      sb.Append("  PeerEndPoint: ").Append(PeerEndPoint).Append("\n");
      sb.Append("  Connected: ").Append(Connected).Append("\n");
      sb.Append("  Inbound: ").Append(Inbound).Append("\n");
      sb.Append("  BytesSent: ").Append(BytesSent).Append("\n");
      sb.Append("  BytesReceived: ").Append(BytesReceived).Append("\n");
      sb.Append("  ReceivedMessages: ").Append(ReceivedMessages).Append("\n");
      sb.Append("  SentMessages: ").Append(SentMessages).Append("\n");
      sb.Append("  LatestEvents: ").Append(LatestEvents).Append("\n");
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
