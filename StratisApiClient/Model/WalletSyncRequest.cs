using System;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters for a wallet resynchronization request.
    /// </summary>
    [DataContract]
  public class WalletSyncRequest {
    /// <summary>
    /// The date and time from which to resync the wallet.
    /// </summary>
    /// <value>The date and time from which to resync the wallet.</value>
    [DataMember(Name="date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date")]
    public DateTime? Date { get; set; }

    /// <summary>
    /// Sync from start of wallet creation.
    /// </summary>
    /// <value>Sync from start of wallet creation.</value>
    [DataMember(Name="all", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "all")]
    public bool? All { get; set; }

    /// <summary>
    /// The WalletName to Sync
    /// </summary>
    /// <value>The WalletName to Sync</value>
    [DataMember(Name="walletName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "walletName")]
    public string WalletName { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class WalletSyncRequest {\n");
      sb.Append("  Date: ").Append(Date).Append("\n");
      sb.Append("  All: ").Append(All).Append("\n");
      sb.Append("  WalletName: ").Append(WalletName).Append("\n");
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
