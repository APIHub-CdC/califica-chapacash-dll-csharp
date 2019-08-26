using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;


namespace Swagger.Model {

    [DataContract]
    public class Respuesta {

        [DataMember(Name="numeroConsulta", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "numeroConsulta")]
        public decimal? NumeroConsulta { get; set; }

        [DataMember(Name="claveRecomendacion", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "claveRecomendacion")]
        public string ClaveRecomendacion { get; set; }

        [DataMember(Name="recomendacion", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "recomendacion")]
        public string Recomendacion { get; set; }

        [DataMember(Name="tipoProducto", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "tipoProducto")]
        public string TipoProducto { get; set; }

        [DataMember(Name="nombreProducto", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "nombreProducto")]
        public string NombreProducto { get; set; }

        [DataMember(Name="montoLineaCredito", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "montoLineaCredito")]
        public decimal? MontoLineaCredito { get; set; }

        [DataMember(Name="flagLineaCreditoAlta", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "flagLineaCreditoAlta")]
        public decimal? FlagLineaCreditoAlta { get; set; }

        [DataMember(Name="msgLineaCreditoAlta", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "msgLineaCreditoAlta")]
        public string MsgLineaCreditoAlta { get; set; }

        [DataMember(Name="mensaje", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "mensaje")]
        public string Mensaje { get; set; }

        [DataMember(Name="motivos", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "motivos")]
        public List<Object> Motivos { get; set; }

        [DataMember(Name="variables", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "variables")]
        public List<Variable> Variables { get; set; }

        public override string ToString()  {
          var sb = new StringBuilder();
          sb.Append("class Respuesta {\n");
          sb.Append("  NumeroConsulta: ").Append(NumeroConsulta).Append("\n");
          sb.Append("  ClaveRecomendacion: ").Append(ClaveRecomendacion).Append("\n");
          sb.Append("  Recomendacion: ").Append(Recomendacion).Append("\n");
          sb.Append("  TipoProducto: ").Append(TipoProducto).Append("\n");
          sb.Append("  NombreProducto: ").Append(NombreProducto).Append("\n");
          sb.Append("  MontoLineaCredito: ").Append(MontoLineaCredito).Append("\n");
          sb.Append("  FlagLineaCreditoAlta: ").Append(FlagLineaCreditoAlta).Append("\n");
          sb.Append("  MsgLineaCreditoAlta: ").Append(MsgLineaCreditoAlta).Append("\n");
          sb.Append("  Mensaje: ").Append(Mensaje).Append("\n");
          sb.Append("  Motivos: ").Append(Motivos).Append("\n");
          sb.Append("  Variables: ").Append(Variables).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }

        public string ToJson() {
          return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
