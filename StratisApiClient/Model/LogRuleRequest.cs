using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StratisApiClient.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
  public class LogRuleRequest {
    /// <summary>
    /// The name of the rule.
    /// </summary>
    /// <value>The name of the rule.</value>
    [DataMember(Name="ruleName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ruleName")]
    public string RuleName { get; set; }

    /// <summary>
    /// The log level.
    /// </summary>
    /// <value>The log level.</value>
    [DataMember(Name="logLevel", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "logLevel")]
    public string LogLevel { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LogRuleRequest {\n");
      sb.Append("  RuleName: ").Append(RuleName).Append("\n");
      sb.Append("  LogLevel: ").Append(LogLevel).Append("\n");
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
