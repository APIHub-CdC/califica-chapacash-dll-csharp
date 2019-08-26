using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;


namespace Swagger.Model {

    [DataContract]
    public class Peticion {

        [DataMember(Name="numeroDocumento", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "numeroDocumento")]
        public string NumeroDocumento { get; set; }

        [DataMember(Name="tipoDocumento", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "tipoDocumento")]
        public int? TipoDocumento { get; set; }

        [DataMember(Name="primNomRazSoc", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "primNomRazSoc")]
        public string PrimNomRazSoc { get; set; }

        [DataMember(Name="segundoNombre", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "segundoNombre")]
        public string SegundoNombre { get; set; }

        [DataMember(Name="apellidoPaterno", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [DataMember(Name="apellidoMaterno", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [DataMember(Name="tipoProducto", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "tipoProducto")]
        public string TipoProducto { get; set; }

        [DataMember(Name="ingresoBruto", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "ingresoBruto")]
        public decimal? IngresoBruto { get; set; }

        [DataMember(Name="otrosIngresos", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "otrosIngresos")]
        public decimal? OtrosIngresos { get; set; }

        [DataMember(Name="impuestosGastosVariables", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "impuestosGastosVariables")]
        public decimal? ImpuestosGastosVariables { get; set; }

        [DataMember(Name="otrosDescuentos", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "otrosDescuentos")]
        public decimal? OtrosDescuentos { get; set; }

        [DataMember(Name="gastosFijos", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "gastosFijos")]
        public decimal? GastosFijos { get; set; }

        [DataMember(Name="deudasVigentes", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "deudasVigentes")]
        public decimal? DeudasVigentes { get; set; }

        [DataMember(Name="cuota", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "cuota")]
        public decimal? Cuota { get; set; }

        [DataMember(Name="plazo", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "plazo")]
        public decimal? Plazo { get; set; }

        public override string ToString()  {
          var sb = new StringBuilder();
          sb.Append("class DatosConsulta {\n");
          sb.Append("  NumeroDocumento: ").Append(NumeroDocumento).Append("\n");
          sb.Append("  TipoDocumento: ").Append(TipoDocumento).Append("\n");
          sb.Append("  PrimNomRazSoc: ").Append(PrimNomRazSoc).Append("\n");
          sb.Append("  SegundoNombre: ").Append(SegundoNombre).Append("\n");
          sb.Append("  ApellidoPaterno: ").Append(ApellidoPaterno).Append("\n");
          sb.Append("  ApellidoMaterno: ").Append(ApellidoMaterno).Append("\n");
          sb.Append("  TipoProducto: ").Append(TipoProducto).Append("\n");
          sb.Append("  IngresoBruto: ").Append(IngresoBruto).Append("\n");
          sb.Append("  OtrosIngresos: ").Append(OtrosIngresos).Append("\n");
          sb.Append("  ImpuestosGastosVariables: ").Append(ImpuestosGastosVariables).Append("\n");
          sb.Append("  OtrosDescuentos: ").Append(OtrosDescuentos).Append("\n");
          sb.Append("  GastosFijos: ").Append(GastosFijos).Append("\n");
          sb.Append("  DeudasVigentes: ").Append(DeudasVigentes).Append("\n");
          sb.Append("  Cuota: ").Append(Cuota).Append("\n");
          sb.Append("  Plazo: ").Append(Plazo).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }

        public string ToJson() {
          return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
