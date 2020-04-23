
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Libera_Bank_Code_Solution.Types;

namespace Libera_Bank_Code_Solution.Models
{
    public class Coin
    {
        // This JsonConverter and StringEnumConverter will help us
        // to serialize/deserialize the Enum while we take Enum as parameter
        // in our controller
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CoinType CoinType { get; set; }
        [Range(0, byte.MaxValue, ErrorMessage = "Num is beyond the capacity of Till")]
        public byte NumOfCoin { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Coin Value beyond scope")]
        public decimal Value { get; set; }
    }
}
