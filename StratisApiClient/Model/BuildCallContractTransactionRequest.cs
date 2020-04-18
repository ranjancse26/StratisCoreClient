using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters to perform a smart contract method call request.
    /// </summary>
    [DataContract]
  public class BuildCallContractTransactionRequest {
    /// <summary>
    /// The name of the wallet containing funds to use to cover transaction fees, gas, and any funds specified in the  Amount field.
    /// </summary>
    /// <value>The name of the wallet containing funds to use to cover transaction fees, gas, and any funds specified in the  Amount field.</value>
    [DataMember(Name="walletName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "walletName")]
    public string WalletName { get; set; }

    /// <summary>
    /// The name of the wallet account containing funds to use to cover transaction fees, gas, and any funds specified in the  Amount field. Defaults to \"account 0\".
    /// </summary>
    /// <value>The name of the wallet account containing funds to use to cover transaction fees, gas, and any funds specified in the  Amount field. Defaults to \"account 0\".</value>
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
    /// The address of the smart contract containing the method.
    /// </summary>
    /// <value>The address of the smart contract containing the method.</value>
    [DataMember(Name="contractAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contractAddress")]
    public string ContractAddress { get; set; }

    /// <summary>
    /// The name of the method to call.
    /// </summary>
    /// <value>The name of the method to call.</value>
    [DataMember(Name="methodName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "methodName")]
    public string MethodName { get; set; }

    /// <summary>
    /// The amount of STRAT (or sidechain coin) to send to the smart contract address.
    /// </summary>
    /// <value>The amount of STRAT (or sidechain coin) to send to the smart contract address.</value>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public string Amount { get; set; }

    /// <summary>
    /// The fees in STRAT (or sidechain coin) to cover the method call transaction.
    /// </summary>
    /// <value>The fees in STRAT (or sidechain coin) to cover the method call transaction.</value>
    [DataMember(Name="feeAmount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "feeAmount")]
    public string FeeAmount { get; set; }

    /// <summary>
    /// The password for the wallet.
    /// </summary>
    /// <value>The password for the wallet.</value>
    [DataMember(Name="password", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }

    /// <summary>
    /// The gas price to charge when the method is run by the miner mining the call transaction.
    /// </summary>
    /// <value>The gas price to charge when the method is run by the miner mining the call transaction.</value>
    [DataMember(Name="gasPrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gasPrice")]
    public long? GasPrice { get; set; }

    /// <summary>
    /// The maximum amount of gas that can be spent executing this transaction.  This limit cannot be exceeded when the method is   run by the miner mining the call transaction. If the gas spent exceeds this value,   execution of the smart contract stops.
    /// </summary>
    /// <value>The maximum amount of gas that can be spent executing this transaction.  This limit cannot be exceeded when the method is   run by the miner mining the call transaction. If the gas spent exceeds this value,   execution of the smart contract stops.</value>
    [DataMember(Name="gasLimit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gasLimit")]
    public long? GasLimit { get; set; }

    /// <summary>
    /// A wallet address containing the funds to cover transaction fees, gas, and any funds specified in the  Amount field. Some methods, such as a withdrawal method on an escrow smart contract,  should only be executed by the deployer. In this case, it is this address that identifies  the deployer.  It is recommended that you use /api/SmartContractWallet/account-addresses to retrieve  an address to use for smart contracts. This enables you to obtain a smart contract transaction history.  However, any sender address containing the required funds will work.
    /// </summary>
    /// <value>A wallet address containing the funds to cover transaction fees, gas, and any funds specified in the  Amount field. Some methods, such as a withdrawal method on an escrow smart contract,  should only be executed by the deployer. In this case, it is this address that identifies  the deployer.  It is recommended that you use /api/SmartContractWallet/account-addresses to retrieve  an address to use for smart contracts. This enables you to obtain a smart contract transaction history.  However, any sender address containing the required funds will work.</value>
    [DataMember(Name="sender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sender")]
    public string Sender { get; set; }

    /// <summary>
    /// An array of encoded strings containing the parameters (and their type) to pass to the smart contract  method when it is called. More information on the  format of a parameter string is available  <a target=\"_blank\" href=\"https://academy.stratisplatform.com/SmartContracts/working-with-contracts.html#parameter-serialization\">here</a>.
    /// </summary>
    /// <value>An array of encoded strings containing the parameters (and their type) to pass to the smart contract  method when it is called. More information on the  format of a parameter string is available  <a target=\"_blank\" href=\"https://academy.stratisplatform.com/SmartContracts/working-with-contracts.html#parameter-serialization\">here</a>.</value>
    [DataMember(Name="parameters", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parameters")]
    public List<string> Parameters { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class BuildCallContractTransactionRequest {\n");
      sb.Append("  WalletName: ").Append(WalletName).Append("\n");
      sb.Append("  AccountName: ").Append(AccountName).Append("\n");
      sb.Append("  Outpoints: ").Append(Outpoints).Append("\n");
      sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
      sb.Append("  MethodName: ").Append(MethodName).Append("\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
      sb.Append("  FeeAmount: ").Append(FeeAmount).Append("\n");
      sb.Append("  Password: ").Append(Password).Append("\n");
      sb.Append("  GasPrice: ").Append(GasPrice).Append("\n");
      sb.Append("  GasLimit: ").Append(GasLimit).Append("\n");
      sb.Append("  Sender: ").Append(Sender).Append("\n");
      sb.Append("  Parameters: ").Append(Parameters).Append("\n");
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
