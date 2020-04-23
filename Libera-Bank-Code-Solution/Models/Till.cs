using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libera_Bank_Code_Solution.Types;

namespace Libera_Bank_Code_Solution.Models
{
    public class TillClass : ITill
    {
        public List<Coin> Till { get; set; }
    }
}
