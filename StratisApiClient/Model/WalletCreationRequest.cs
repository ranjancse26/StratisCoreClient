using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// A class containing the necessary parameters for a create wallet request.
    /// </summary>
    [DataContract]
  public class WalletCreationRequest {
    /// <summary>
    /// The mnemonic used to create the HD wallet.
    /// </summary>
    /// <value>The mnemonic used to create the HD wallet.</value>
    [DataMember(Name="mnemonic", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mnemonic")]
    public string Mnemonic { get; set; }

    /// <summary>
    /// A password used to encrypt the wallet for secure storage.
    /// </summary>
    /// <value>A password used to encrypt the wallet for secure storage.</value>
    [DataMember(Name="password", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }

    /// <summary>
    /// An optional additional seed, which is joined together with the Stratis.Bitcoin.Features.Wallet.Models.WalletCreationRequest.Mnemonic  when the wallet is created.  Although you will be prompted to enter a passphrase, an empty string is still valid.
    /// </summary>
    /// <value>An optional additional seed, which is joined together with the Stratis.Bitcoin.Features.Wallet.Models.WalletCreationRequest.Mnemonic  when the wallet is created.  Although you will be prompted to enter a passphrase, an empty string is still valid.</value>
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
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class WalletCreationRequest {\n");
      sb.Append("  Mnemonic: ").Append(Mnemonic).Append("\n");
      sb.Append("  Password: ").Append(Password).Append("\n");
      sb.Append("  Passphrase: ").Append(Passphrase).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
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
