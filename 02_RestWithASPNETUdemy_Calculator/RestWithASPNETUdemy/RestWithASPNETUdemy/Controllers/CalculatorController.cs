using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
                return BadRequest("Invalid Input");

            var resultSum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

            return Ok(resultSum.ToString());
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
                return BadRequest("Invalid Input");

            var resultSubtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

            return Ok(resultSubtraction.ToString());
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
                return BadRequest("Invalid Input");

            var resultMultiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

            return Ok(resultMultiplication.ToString());
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
                return BadRequest("Invalid Input");

            var resultDivision = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

            return Ok(resultDivision.ToString());
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
                return BadRequest("Invalid Input");

            var resultMean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

            return Ok(resultMean.ToString());
        }

        [HttpGet("squareRoot/{strNumber}")]
        public IActionResult SquareRoot(string strNumber)
        {
            if (!IsNumeric(strNumber))
                return BadRequest("Invalid Input");

            var resultSquareRoot = Math.Sqrt((double)ConvertToDecimal(strNumber));

            return Ok(resultSquareRoot.ToString());
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (!decimal.TryParse(strNumber.Replace(",", "."), out decimalValue))
                return 0;

            return decimalValue;
        }
    }
}
