using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankEvent
{

    class BankAccount
    {
        private int acctNum;
        private double balance;
        public event EventHandler BalanceAdjusted;


        public BankAccount(int acct)
        {

            acctNum = acct;
            balance = 0;

        }

        public int AcctNum
        {

            get
            {

                return acctNum;
            }

        }

        public double Balance
        {

            get
            {
                return balance;

            }
        }

        public void MakeDeposit(double amt)
        {
            balance += amt;
            OnBalanceAdjusted(EventArgs.Empty);


        }

        public void MakeWithdrawl(double amt)
        {

            balance -= amt;
            OnBalanceAdjusted(EventArgs.Empty);

        }

        public void OnBalanceAdjusted(EventArgs e)
        {

            BalanceAdjusted(this, e);

        }



    }

    class EventListener
    {


        private BankAccount acct;
        public EventListener(BankAccount account)
        {

            acct = account;
            acct.BalanceAdjusted += new EventHandler(BankAccountBalanceAdjusted);


        }

        private void BankAccountBalanceAdjusted(object sender, EventArgs e)
        {

            WriteLine("The account balance has been adjusted.");
            WriteLine(" Account # {0} balance {1}", acct.AcctNum, acct.Balance.ToString("C2"));
        }





    }

    class DemoBankAccountEvent
    {

        static void Main()
        {

            const int TRANSACTIONS = 5;
            char code;
            double amt;

            BankAccount acct = new BankAccount(334455);
            EventListener listener = new EventListener(acct);

            for (int x = 0; x < TRANSACTIONS; ++x) {
                try
                {
                    Write("Enter D for deposit or W for Withdrawl");
                    code = Convert.ToChar(ReadLine());
                    if (code == 'D')
                    {

                        Write("Enter dollar amount ");
                        amt = Convert.ToDouble(ReadLine());
                        acct.MakeDeposit(amt);


                    }
                    else if (code == 'W')
                    {
                        if (Convert.ToDouble(acct.Balance) >= 1) {
                            Write("Enter dollar amount ");
                            amt = Convert.ToDouble(ReadLine());
                            if (amt <= acct.Balance)
                            {
                                acct.MakeWithdrawl(amt);
                            }
                            else
                            {
                                x -= 1;//Resets x back a step in order to maintain 5 total possible real transactions upon invalid withdrawl entry. 
                                Console.WriteLine("Cannot withdraw specified amount. Your balance will be exceeded and penalties would apply!");
                            }
                        }
                        else
                        {
                            x -= 1;//Resets x back a step in order to maintain 5 total possible real transactions upon invalid withdrawl entry. 
                            Console.WriteLine("There is not enough to withdraw! Make a deposit first greater than your desired withdrawl amount.");
                        }
                    }
                    else
                    {
                        x -= 1;//Resets x back a step in order to maintain 5 total possible real transactions upon invalid code entry. 
                        WrongCharacterException wce = new WrongCharacterException();
                        throw wce;
                        

                    }

                }/*I added the try and catch block as a fun way to practice catching and throwing an exception as well as creating resilience.*/

                catch (WrongCharacterException)
                {
                    WriteLine("You entered an invalid character code. Please try again.");


                }
            }

        }

        class WrongCharacterException : FormatException
        {
        } 

    }

}


