using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyConversion
{
    public class ConvertCur
    {
        //Conversion Rate
        public const decimal USDtoAUD = 1.25738715M;
        public const decimal EURtoAUD = 1.77731674M;

        public string convert(string code, string amount)
        {
            decimal AUD; //output amount in Australian Dollar after conversion
            int fromAmount; //input amount as an integer

            bool checkInt = int.TryParse(amount, out fromAmount); //check whole number
            if (!checkInt) //not whole number
            {
                throw new FormatException("Invalid amount");
            }
            
            switch (code) //check currency code
            {
                case "USD":
                    AUD = fromAmount * USDtoAUD;
                    break;
                case "EUR":
                    if (fromAmount % 5 == 0) //EUR is a multiple of five
                    {
                        AUD = fromAmount * EURtoAUD;
                    }
                    else
                    {
                        throw new FormatException("Euro must be a multiple of 5");
                    }
                    break;
                default: //inccorect currency code
                    throw new FormatException("Incorrect currency code");
            }

            return AUD.ToString("0.00"); //format output to two decimal places
        }
    }
}
