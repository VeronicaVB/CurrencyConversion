using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyConversion
{
    public class ConvertCur
    {
        //Conversion Rate
        public const decimal USDtoAUD = 1.26M;
        public const decimal EURtoAUD = 1.78M;
        public const decimal YENtoAUD = 1.54M;

        public const decimal feeLess1000 = 0.02M;
        public const decimal feeMore1000 = 0.015M;

        public string convert(string code, string amount)
        {
            decimal AUD; //output amount in Australian Dollar after conversion
            decimal fee; //output of conversio fee
            int fromAmount; //input amount as an integer

            if (String.IsNullOrEmpty(code) || String.IsNullOrEmpty(amount))
            {
                throw new FormatException("Missing Input");
            }

            bool checkInt = int.TryParse(amount, out fromAmount); //check whole number
            if (!checkInt) //not whole number
            {
                throw new ArithmeticException("Invalid amount");
            }

            int.TryParse(amount, out fromAmount);
            if (fromAmount < 1) //not whole number
            {
                throw new ArithmeticException("Invalid amount - must be greater than 0");
                
            }

            switch (code) //check currency code
            {
                case "USD":
                    AUD = fromAmount * USDtoAUD;
                    break;
                case "YEN":
                    AUD = fromAmount * YENtoAUD;
                    break;
                case "EUR":
                    if (fromAmount % 5 == 0) //EUR is a multiple of five
                    {
                        AUD = fromAmount * EURtoAUD;
                    }
                    else
                    {
                        throw new ArithmeticException("Euro must be a multiple of 5");
                    }
                    break;
                default: //inccorect currency code
                    throw new FormatException("Incorrect currency code");
            }

            if (AUD < 1000)
            {
                fee = AUD * feeLess1000;
            }
            else
            {
                fee = AUD * feeMore1000;
            }

            AUD = AUD - fee;

            return AUD.ToString("0.00"); //format output to two decimal places
        }
    }
}
