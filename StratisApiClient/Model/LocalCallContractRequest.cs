using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters to perform a local smart contract method call request.
    /// </summary>
    [DataContract]
  public class LocalCallContractRequest {
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
    /// The amount of STRAT (or sidechain coin) to send to the smart contract address.   No funds are actually sent, but the Amount field allows  certain scenarios, where the funds sent dictates the result, to be checked.
    /// </summary>
    /// <value>The amount of STRAT (or sidechain coin) to send to the smart contract address.   No funds are actually sent, but the Amount field allows  certain scenarios, where the funds sent dictates the result, to be checked.</value>
    [DataMember(Name="amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amount")]
    public string Amount { get; set; }

    /// <summary>
    /// The gas price to use. This is used to calculate the expected expenditure  if the method is run by a miner mining a call transaction rather than  locally.
    /// </summary>
    /// <value>The gas price to use. This is used to calculate the expected expenditure  if the method is run by a miner mining a call transaction rather than  locally.</value>
    [DataMember(Name="gasPrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gasPrice")]
    public long? GasPrice { get; set; }

    /// <summary>
    /// The maximum amount of gas that can be spent executing this transaction.  Although the gas expenditure is theoretical rather than actual,  this limit cannot be exceeded even when the method is run locally.
    /// </summary>
    /// <value>The maximum amount of gas that can be spent executing this transaction.  Although the gas expenditure is theoretical rather than actual,  this limit cannot be exceeded even when the method is run locally.</value>
    [DataMember(Name="gasLimit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gasLimit")]
    public long? GasLimit { get; set; }

    /// <summary>
    /// A wallet address containing the funds to cover transaction fees, gas, and any funds specified in the  Amount field.  Note that because the method call is local no funds are spent. However, the concept of the sender address  is still valid and may need to be checked.  For example, some methods, such as a withdrawal method on an escrow smart contract, should only be executed  by the deployer, and in this case, it is the Sender address that identifies the deployer.
    /// </summary>
    /// <value>A wallet address containing the funds to cover transaction fees, gas, and any funds specified in the  Amount field.  Note that because the method call is local no funds are spent. However, the concept of the sender address  is still valid and may need to be checked.  For example, some methods, such as a withdrawal method on an escrow smart contract, should only be executed  by the deployer, and in this case, it is the Sender address that identifies the deployer.</value>
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
      sb.Append("class LocalCallContractRequest {\n");
      sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
      sb.Append("  MethodName: ").Append(MethodName).Append("\n");
      sb.Append("  Amount: ").Append(Amount).Append("\n");
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
