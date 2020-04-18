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
  public class DistributeUtxosRequest {
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
    /// Gets or Sets UseUniqueAddressPerUtxo
    /// </summary>
    [DataMember(Name="useUniqueAddressPerUtxo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "useUniqueAddressPerUtxo")]
    public bool? UseUniqueAddressPerUtxo { get; set; }

    /// <summary>
    /// Gets or Sets ReuseAddresses
    /// </summary>
    [DataMember(Name="reuseAddresses", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reuseAddresses")]
    public bool? ReuseAddresses { get; set; }

    /// <summary>
    /// Gets or Sets UseChangeAddresses
    /// </summary>
    [DataMember(Name="useChangeAddresses", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "useChangeAddresses")]
    public bool? UseChangeAddresses { get; set; }

    /// <summary>
    /// Gets or Sets UtxosCount
    /// </summary>
    [DataMember(Name="utxosCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "utxosCount")]
    public int? UtxosCount { get; set; }

    /// <summary>
    /// Gets or Sets UtxoPerTransaction
    /// </summary>
    [DataMember(Name="utxoPerTransaction", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "utxoPerTransaction")]
    public int? UtxoPerTransaction { get; set; }

    /// <summary>
    /// Gets or Sets TimestampDifferenceBetweenTransactions
    /// </summary>
    [DataMember(Name="timestampDifferenceBetweenTransactions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "timestampDifferenceBetweenTransactions")]
    public int? TimestampDifferenceBetweenTransactions { get; set; }

    /// <summary>
    /// The minimum number of confirmations a transaction needs to have to be included.  To include unconfirmed transactions, set this value to 0.
    /// </summary>
    /// <value>The minimum number of confirmations a transaction needs to have to be included.  To include unconfirmed transactions, set this value to 0.</value>
    [DataMember(Name="minConfirmations", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minConfirmations")]
    public int? MinConfirmations { get; set; }

    /// <summary>
    /// A list of outpoints to use as inputs for the transaction.
    /// </summary>
    /// <value>A list of outpoints to use as inputs for the transaction.</value>
    [DataMember(Name="outpoints", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "outpoints")]
    public List<OutpointRequest> Outpoints { get; set; }

    /// <summary>
    /// Gets or Sets DryRun
    /// </summary>
    [DataMember(Name="dryRun", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dryRun")]
    public bool? DryRun { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DistributeUtxosRequest {\n");
      sb.Append("  WalletName: ").Append(WalletName).Append("\n");
      sb.Append("  AccountName: ").Append(AccountName).Append("\n");
      sb.Append("  WalletPassword: ").Append(WalletPassword).Append("\n");
      sb.Append("  UseUniqueAddressPerUtxo: ").Append(UseUniqueAddressPerUtxo).Append("\n");
      sb.Append("  ReuseAddresses: ").Append(ReuseAddresses).Append("\n");
      sb.Append("  UseChangeAddresses: ").Append(UseChangeAddresses).Append("\n");
      sb.Append("  UtxosCount: ").Append(UtxosCount).Append("\n");
      sb.Append("  UtxoPerTransaction: ").Append(UtxoPerTransaction).Append("\n");
      sb.Append("  TimestampDifferenceBetweenTransactions: ").Append(TimestampDifferenceBetweenTransactions).Append("\n");
      sb.Append("  MinConfirmations: ").Append(MinConfirmations).Append("\n");
      sb.Append("  Outpoints: ").Append(Outpoints).Append("\n");
      sb.Append("  DryRun: ").Append(DryRun).Append("\n");
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
