using System.Text.Json.Serialization;
namespace ApiProvaCSharp.Models
{

  public class CompraEstado
  {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status { APROVADO, REJEITADO };
    public static Status Get(double valor)
    {
      return (valor > 100.0d) ? Status.APROVADO
                              : Status.REJEITADO;
    }
  }
}
