using Bank_Acc.Classes;

namespace Bank
{ 
    public class Bank_Account
    {
        /// <summary>
        /// СОЗДАНИЕ КЛАССОВ
        /// </summary>
        
        private int account_number; //номер счёта
        private DateTime account_opening_ate; //дата открытия счёта
        private int invoice_amount; //сумма счета
        private double deposit_period; //срок вклада
        private string status;
        private Client client;

        public Bank_Account (int account_number, DateTime account_opening_ate, int invoice_amount, double deposit_period, string status, Client client)
        {
            this.account_number = account_number;
            this.account_opening_ate = account_opening_ate;
            this.invoice_amount = invoice_amount;
            this.deposit_period = deposit_period;
            this.status = status;
            this.client = client;
        }

        public Bank_Account()
        {
            this.client = new Client();
        }
        
        /// <summary>
        /// ВНУТРЕННИЕ МЕТОДЫ
        /// </summary>

        private DateTime end_deposit() //дата окончания вклада
        {
            return account_opening_ate.AddDays(deposit_period);
        }

        private string statuschange() //статус вклада
        {
            if (invoice_amount == 0)
            {
                status = "closed"; //закрытый
            }
            else if (invoice_amount > 0)
            {
                status = "opened"; //открытый
            }
            else if (invoice_amount < 0)
            {
                status = "bankrupt"; //банкротный
            }
            return status;
        }

        /// <summary>
        /// ВНЕШНИЕ МЕТОДЫ
        /// </summary>

        public int popolnenie (int summa_popoln)
        {
            return invoice_amount + summa_popoln;
        }
        public int snyatie (int summa_snyatia)
        {
            if (invoice_amount > summa_snyatia)
            {
                invoice_amount = invoice_amount - summa_snyatia;
            }
            if (invoice_amount <= 0)
            {
                return 0;
            }

            return invoice_amount;
        }

        public int perevod (int account_number2, int summa_perevoda, int invoice_amount2)
        {
            if (invoice_amount <= 0)
            {
                return 0;
            }
            else if (invoice_amount <= summa_perevoda)
            {
                return 0;
            }
            else
            {
                return invoice_amount2 = invoice_amount2 + summa_perevoda;
            }
        }
    }

}