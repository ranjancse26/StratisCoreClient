using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
  public class SplitCoinsRequest {
    /// <summary>
    /// Gets or Sets WalletName
    /// </summary>
    [DataMember(Name="walletName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "walletName")]
    public string WalletName { get; set; }

    /// <summary>
    /// Gets or Sets AccountName
    /// </summary>
    [DataMember(Name="accountName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountName")]
    public string AccountName { get; set; }

    /// <summary>
    /// Gets or Sets WalletPassword
    /// </summary>
    [DataMember(Name="walletPassword", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "walletPassword")]
    public string WalletPassword { get; set; }

    /// <summary>
    /// The amount that will be sent.
    /// </summary>
    /// <value>The amount that will be sent.</value>
    [DataMember(Name="totalAmountToSplit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalAmountToSplit")]
    public string TotalAmountToSplit { get; set; }

    /// <summary>
    /// Gets or Sets UtxosCount
    /// </summary>
    [DataMember(Name="utxosCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "utxosCount")]
    public int? UtxosCount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SplitCoinsRequest {\n");
      sb.Append("  WalletName: ").Append(WalletName).Append("\n");
      sb.Append("  AccountName: ").Append(AccountName).Append("\n");
      sb.Append("  WalletPassword: ").Append(WalletPassword).Append("\n");
      sb.Append("  TotalAmountToSplit: ").Append(TotalAmountToSplit).Append("\n");
      sb.Append("  UtxosCount: ").Append(UtxosCount).Append("\n");
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
