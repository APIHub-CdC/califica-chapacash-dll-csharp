using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;


namespace Swagger.Model {

  [DataContract]
  public class Errores {

        [DataMember(Name="Errores", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "Errores")]
        public List<Error> _Errores { get; set; }

        public override string ToString()  {
          var sb = new StringBuilder();
          sb.Append("class Errores {\n");
          sb.Append("  _Errores: ").Append(_Errores).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }

        public string ToJson() {
          return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
