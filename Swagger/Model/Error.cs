using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;


namespace Swagger.Model {

    [DataContract]
    public class Error {

        [DataMember(Name="codigo", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "codigo")]
        public int? Codigo { get; set; }

        [DataMember(Name="mensaje", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "mensaje")]
        public string Mensaje { get; set; }

        public override string ToString()  {
          var sb = new StringBuilder();
          sb.Append("class Error {\n");
          sb.Append("  Codigo: ").Append(Codigo).Append("\n");
          sb.Append("  Mensaje: ").Append(Mensaje).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }

        public string ToJson() {
          return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
