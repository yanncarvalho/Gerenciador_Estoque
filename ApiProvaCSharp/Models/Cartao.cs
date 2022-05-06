using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ApiProvaCSharp.ValidationAnnotations;
using Newtonsoft.Json;

namespace ApiProvaCSharp.Models
{

    public class CartaoCred
    {
        //considerado as principais bandeiras do Brasil - link: https://www.mobills.com.br/blog/bandeira-do-cartao-de-credito/
        public enum Bandeiras {VISA, MASTERCARD, ELO, AMERICAN_EXPRESS, HIPERCARD}

        //não sao permitidos carcateres numericos, especiais, acentuação ou pontuação
        [Required(AllowEmptyStrings = false), RegularExpression(@"^([\w|\s])*$")]
        public string? Titular { get; set; }

        [JsonProperty("data_expiracao")]
        [JsonRequired, DataCartaoCred]
        public string? DtExpiracao { get; set; }
        
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonRequired]
        public Bandeiras Bandeira { get; set; }

        //considera o cvv pode ter 4 ou 3 digitos - link: https://en.wikipedia.org/wiki/Card_security_code
        [Required(AllowEmptyStrings = false), RegularExpression(@"^\d{3,4}$")]
        public string? CVV { get; set; }

        //considera o ISO/IEC/7812
        [Required(AllowEmptyStrings = false), CreditCard]
        public string? Numero { get; set; }
    }
}


