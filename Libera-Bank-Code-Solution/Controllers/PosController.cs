using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libera_Bank_Code_Solution.Models;
using Libera_Bank_Code_Solution.Types;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libera_Bank_Code_Solution.Controllers
{
    [Route("api/[controller]")]
    public class PosController : Controller
    {
        /**
         * Here we mocked a conceptual Till which holds the following
         * Coin object
         *
         * Here we assume that till cannot hold one type of coin multiple times.
         * eg.
         *     we cannot have the following two coins within one till object
         *      new Coin() {CoinType = CoinType.Quarter, NumOfCoin = 1},
         *      new Coin() {CoinType = CoinType.Quarter, NumOfCoin = 5},
         */
        private List<Coin> Till;

        public PosController(ITill till)
        {
            Till = till.Till;
        }

        [HttpGet("GetValues")]
        public IActionResult GetValues()
        {
            // this is used to throw a server error when the list is not initialized;
            // this simulates the scenario that DB returns null or have exception during 
            // retrieve data process
            if (Till == null) return StatusCode(500);

            var totalValue = CalcTillValues(Till);

            return Ok(new {TotalValue = totalValue});
        }
        [HttpGet("GetCountBy/{type}")]
        public IActionResult GetCountBy(string type)
        {
            if (Till == null) return StatusCode(500);

            var coin = Till.Find(c => c.CoinType.ToString().Equals(type, StringComparison.OrdinalIgnoreCase));

            if (coin != null)
            {
                return Ok(coin);
            }

            return StatusCode(404);
        }

        [HttpPut("AddCoin")]
        public IActionResult AddCoin([FromBody] Coin newCoin)
        {
            if (Till == null) return StatusCode(500);
            if (newCoin == null) return StatusCode(400);

            var coin = Till.Find(c => c.CoinType == newCoin.CoinType);

            if (coin != null)
            {
                coin.NumOfCoin += newCoin.NumOfCoin;
                 return Ok();
            }

            return StatusCode(404);
        }

        /**
         * This function will not working, for some reason it get stuck in the makeChange function.
         *
         * I know this need to be done with DP but I really not able to finish this algorithm 
         */
        [HttpGet("GetChanges")]
        public IActionResult GetChanges([FromBody] AmountClass amount)
        {
            if (Till == null) return StatusCode(500);
            //// Initialize result 
            //int res = int.MaxValue;
            //// the combination list holds the different type 
            //List<Coin> combinationCoins = new List<Coin>();
            //// FindMinCoinsCombination(Till, amount.Amount, combinationCoins, ref res);

            
            //if (combinationCoins.Count == 0 || amount.Amount == 0M) return Ok(new {Error = "Cannot Make Change!"});



            return Ok(new {Error= "Sorry, the find min coin algorithm I didn't complete. Sorry for that"});
        }

        /**
         * The main structure of this method are borrowed from
         * https://www.geeksforgeeks.org/find-minimum-number-of-coins-that-make-a-change/
         * I just added a result list to holds the combination instead of simply return the minimum count.
         */
        private int FindMinCoinsCombination(List<Coin> till, decimal amount, List<Coin> resultList, ref int res)
        {

            // if the amount is 0, that means no way to make change; 
            // combinationCoins.Length is 0
            if (amount == 0M)
            {
                return 0;
            }

      
            // loop through current till 
            foreach (var coin in till)
            {
                // if any coin's value is larger than the given amount
                // that means we cannot make changes
                if (coin.Value <= amount)
                {
                    // here the below if statement is help us to record the minimum coins needed for
                    // each type of coin
                    var newCoin = resultList.Find(c => c.CoinType == coin.CoinType);
                    if (newCoin == null)
                    {
                        resultList.Add(new Coin() { CoinType = coin.CoinType, NumOfCoin = 1 });
                    }
                    else
                    {
                        newCoin.NumOfCoin += 1;
                    }

                    int sub_res = FindMinCoinsCombination(till, amount - coin.Value, resultList, ref res);
                    if (sub_res + 1 < res)
                        res = sub_res + 1;
                }
            }

            return res;
        }

        /**
         * Method to calc total values of the till
         * @param till
         * The instance of Till object 
         */
        private decimal CalcTillValues(List<Coin> till)
        {
            decimal result = 0M;
            foreach (var c in till)
            {
                result += c.NumOfCoin * c.Value;
            }

            return result;
        }

    }
}
