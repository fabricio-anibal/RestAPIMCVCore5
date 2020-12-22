using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestASPNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Calculator : ControllerBase
    {
      

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if(isNumeric(secondNumber) && isNumeric(secondNumber))
            {
                var sum = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        public bool isNumeric(string number)
        {
            double n;

            bool isNumber = double.TryParse(number, System.Globalization.NumberStyles.Any, 
                                            System.Globalization.NumberFormatInfo.InvariantInfo, out n);

            return isNumber;
        }
    }
}
