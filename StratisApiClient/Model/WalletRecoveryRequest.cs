using System;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters for a wallet recovery request.
    /// </summary>
    [DataContract]
  public class WalletRecoveryRequest {
    /// <summary>
    /// The mnemonic that was used to create the wallet.
    /// </summary>
    /// <value>The mnemonic that was used to create the wallet.</value>
    [DataMember(Name="mnemonic", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mnemonic")]
    public string Mnemonic { get; set; }

    /// <summary>
    /// The password that was used to create the wallet.
    /// </summary>
    /// <value>The password that was used to create the wallet.</value>
    [DataMember(Name="password", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }

    /// <summary>
    /// The passphrase that was used to create the wallet.
    /// </summary>
    /// <value>The passphrase that was used to create the wallet.</value>
    [DataMember(Name="passphrase", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "passphrase")]
    public string Passphrase { get; set; }

    /// <summary>
    /// The name of the wallet.
    /// </summary>
    /// <value>The name of the wallet.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets CreationDate
    /// </summary>
    [DataMember(Name="creationDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creationDate")]
    public DateTime? CreationDate { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class WalletRecoveryRequest {\n");
      sb.Append("  Mnemonic: ").Append(Mnemonic).Append("\n");
      sb.Append("  Password: ").Append(Password).Append("\n");
      sb.Append("  Passphrase: ").Append(Passphrase).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  CreationDate: ").Append(CreationDate).Append("\n");
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
