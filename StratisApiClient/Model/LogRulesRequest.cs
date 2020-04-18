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
  public class LogRulesRequest {
    /// <summary>
    /// Gets or Sets LogRules
    /// </summary>
    [DataMember(Name="logRules", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "logRules")]
    public List<LogRuleRequest> LogRules { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LogRulesRequest {\n");
      sb.Append("  LogRules: ").Append(LogRules).Append("\n");
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
