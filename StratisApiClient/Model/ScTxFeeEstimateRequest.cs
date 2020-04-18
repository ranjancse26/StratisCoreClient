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
  public class ScTxFeeEstimateRequest {
    /// <summary>
    /// Gets or Sets Sender
    /// </summary>
    [DataMember(Name="sender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sender")]
    public string Sender { get; set; }

    /// <summary>
    /// The name of the wallet containing the UTXOs to use in the transaction.
    /// </summary>
    /// <value>The name of the wallet containing the UTXOs to use in the transaction.</value>
    [DataMember(Name="walletName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "walletName")]
    public string WalletName { get; set; }

    /// <summary>
    /// The name of the account containing the UTXOs to use in the transaction.
    /// </summary>
    /// <value>The name of the account containing the UTXOs to use in the transaction.</value>
    [DataMember(Name="accountName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountName")]
    public string AccountName { get; set; }

    /// <summary>
    /// A list of outpoints to use as inputs for the transaction.
    /// </summary>
    /// <value>A list of outpoints to use as inputs for the transaction.</value>
    [DataMember(Name="outpoints", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "outpoints")]
    public List<OutpointRequest> Outpoints { get; set; }

    /// <summary>
    /// A list of transaction recipients. For each recipient, specify the Pubkey script and the amount the  recipient will receive in STRAT (or a sidechain coin). If the transaction was realized,  both the values would be used to create the UTXOs for the transaction recipients.
    /// </summary>
    /// <value>A list of transaction recipients. For each recipient, specify the Pubkey script and the amount the  recipient will receive in STRAT (or a sidechain coin). If the transaction was realized,  both the values would be used to create the UTXOs for the transaction recipients.</value>
    [DataMember(Name="recipients", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "recipients")]
    public List<RecipientModel> Recipients { get; set; }

    /// <summary>
    /// A string containing any OP_RETURN output data to store as part of the transaction.
    /// </summary>
    /// <value>A string containing any OP_RETURN output data to store as part of the transaction.</value>
    [DataMember(Name="opReturnData", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "opReturnData")]
    public string OpReturnData { get; set; }

    /// <summary>
    /// The funds in STRAT (or a sidechain coin) to include with the OP_RETURN output. Currently, specifying  some funds helps OP_RETURN outputs be relayed around the network.
    /// </summary>
    /// <value>The funds in STRAT (or a sidechain coin) to include with the OP_RETURN output. Currently, specifying  some funds helps OP_RETURN outputs be relayed around the network.</value>
    [DataMember(Name="opReturnAmount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "opReturnAmount")]
    public string OpReturnAmount { get; set; }

    /// <summary>
    /// The type of fee to use when working out the fee for the transaction. Specify \"low\", \"medium\", or \"high\".
    /// </summary>
    /// <value>The type of fee to use when working out the fee for the transaction. Specify \"low\", \"medium\", or \"high\".</value>
    [DataMember(Name="feeType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "feeType")]
    public string FeeType { get; set; }

    /// <summary>
    /// A flag that specifies whether to include the unconfirmed amounts as inputs to the transaction.  If this flag is not set, at least one confirmation is required for each input.
    /// </summary>
    /// <value>A flag that specifies whether to include the unconfirmed amounts as inputs to the transaction.  If this flag is not set, at least one confirmation is required for each input.</value>
    [DataMember(Name="allowUnconfirmed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "allowUnconfirmed")]
    public bool? AllowUnconfirmed { get; set; }

    /// <summary>
    /// A flag that specifies whether to shuffle the transaction outputs for increased privacy. Randomizing the  the order in which the outputs appear when the transaction is being built stops it being trivial to  determine whether a transaction output is payment or change. This helps defeat unsophisticated  chain analysis algorithms.   Defaults to true.
    /// </summary>
    /// <value>A flag that specifies whether to shuffle the transaction outputs for increased privacy. Randomizing the  the order in which the outputs appear when the transaction is being built stops it being trivial to  determine whether a transaction output is payment or change. This helps defeat unsophisticated  chain analysis algorithms.   Defaults to true.</value>
    [DataMember(Name="shuffleOutputs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shuffleOutputs")]
    public bool? ShuffleOutputs { get; set; }

    /// <summary>
    /// The address to which the change from the transaction should be returned. If this is not set,  the default behaviour from the Stratis.Bitcoin.Features.Wallet.WalletTransactionHandler will be used to determine the change address.
    /// </summary>
    /// <value>The address to which the change from the transaction should be returned. If this is not set,  the default behaviour from the Stratis.Bitcoin.Features.Wallet.WalletTransactionHandler will be used to determine the change address.</value>
    [DataMember(Name="changeAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "changeAddress")]
    public string ChangeAddress { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ScTxFeeEstimateRequest {\n");
      sb.Append("  Sender: ").Append(Sender).Append("\n");
      sb.Append("  WalletName: ").Append(WalletName).Append("\n");
      sb.Append("  AccountName: ").Append(AccountName).Append("\n");
      sb.Append("  Outpoints: ").Append(Outpoints).Append("\n");
      sb.Append("  Recipients: ").Append(Recipients).Append("\n");
      sb.Append("  OpReturnData: ").Append(OpReturnData).Append("\n");
      sb.Append("  OpReturnAmount: ").Append(OpReturnAmount).Append("\n");
      sb.Append("  FeeType: ").Append(FeeType).Append("\n");
      sb.Append("  AllowUnconfirmed: ").Append(AllowUnconfirmed).Append("\n");
      sb.Append("  ShuffleOutputs: ").Append(ShuffleOutputs).Append("\n");
      sb.Append("  ChangeAddress: ").Append(ChangeAddress).Append("\n");
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
