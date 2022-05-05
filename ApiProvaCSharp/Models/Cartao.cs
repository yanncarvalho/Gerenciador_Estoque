using System.ComponentModel.DataAnnotations;
using ApiProvaCSharp.ValidationAnnotations;
using System.Text.Json.Serialization;

namespace ApiProvaCSharp.Models
{

    public class CartaoCred
    {
        //considerado as principais bandeiras do Brasil - link: https://www.mobills.com.br/blog/bandeira-do-cartao-de-credito/
        public enum Bandeiras {VISA, MASTERCARD, ELO, AMERICAN_EXPRESS, HIPERCARD}

        //não sao permitidos carcateres numerios, especiais ou acentuação
        [Required(AllowEmptyStrings = false), RegularExpression(@"^\w|\s*$")]
        public string? Titular { get; set; }

        [JsonPropertyName("data_expiracao")]
        [Required(AllowEmptyStrings = false), DataCartao]
        public string? DtExpiracao { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required(AllowEmptyStrings = false)]
        public Bandeiras Bandeira { get; set; }

        //considera o cvv pode ter 4 ou 3 digitos - link: https://en.wikipedia.org/wiki/Card_security_code
        [Required(AllowEmptyStrings = false), RegularExpression(@"^\d{3,4}$")]
        public string? CVV { get; set; }

        //considera o ISO/IEC/7812
        [Required(AllowEmptyStrings = false), CreditCard]
        public string? Numero { get; set; }
    }
}


