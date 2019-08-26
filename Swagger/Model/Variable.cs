using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System;

namespace Swagger.Model {

    [DataContract]
    public class Variable {

        [DataMember(Name="nombre", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "tipo", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tipo")]
        public string Tipo { get; set; }

        [DataMember(Name="valor", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "valor")]
        public Object Valor { get; set; }

        public override string ToString()  {
          var sb = new StringBuilder();
          sb.Append("class Variable {\n");
          sb.Append("  Nombre: ").Append(Nombre).Append("\n");
          sb.Append("  Tipo: ").Append(Tipo).Append("\n");
          sb.Append("  Valor: ").Append(Valor).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }

        public string ToJson() {
          return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
