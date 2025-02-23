using System;

namespace Menu
{
    public class Money:Convert
    {
        private int _money;
        public int money
        {
            get { return _money; }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new Exception("Від'ємне значення");
                    }
                    _money = value;
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private int _penny;
        public int penny
        {
            get { return _penny; }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new Exception("Від'ємне значення");
                    }
                    _penny = value;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
        private string _currency;
        private decimal _exchangeRate; 
        public decimal exchangeRate
        {
            get { return _exchangeRate; }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new Exception("Від'ємне значення");
                    }
                    _exchangeRate = value;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Money(int money, int penny, string currency, decimal exchangeRate)
        {
             this.money = money;  
            this.penny = penny;
            _currency = currency;
            this.exchangeRate = exchangeRate;
            Normalize();
        }

        private void Normalize()
        {
            if (_penny >= 100)
            {
                _money += _penny / 100;
                _penny %= 100;
            }
        }

        public string Sum() => $"{_money}.{_penny:D2} {_currency}";

        public int GetTotalInCents() => (_money * 100) + _penny;
       
        public void SetMoney(int sum)
        {
            _penny = sum % 100;
            _money = sum / 100;
        }

      
        public Money ConvertTo(Money targetCurrency)
        {
            decimal totalInBaseCurrency = GetTotalInCents() / 100m / _exchangeRate; 
            decimal convertedAmount = totalInBaseCurrency * targetCurrency._exchangeRate;

            int newMoney = (int)convertedAmount;
            int newPenny = (int)((convertedAmount - newMoney) * 100);

            return new Money(newMoney, newPenny, targetCurrency._currency, targetCurrency._exchangeRate);
        }
    }
}
