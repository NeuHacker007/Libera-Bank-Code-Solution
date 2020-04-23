using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libera_Bank_Code_Solution.Models;

namespace Libera_Bank_Code_Solution.Types
{
    public interface ITill
    {
        List<Coin> Till { get; set; }
    }
}
