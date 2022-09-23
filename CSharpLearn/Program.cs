using System;

namespace CSharpLearn
{
    class Account
    {
        private string fname;
        private string sname;
        private string accountNo;
        private string pw;
        private double bal;
        private string hist="";

        public string Fname
        {
            get { return fname; }
        }

        public string Sname
        {
            get { return sname; }
        }

        public string AccountNo
        {
            get { return accountNo; }
        }

        public string Pw
        {
            get { return pw; }
        }

        public double Bal
        {
            get { return bal; }
        }

        public string Hist
        {
            get { return hist; }
        }

        public Account(string fname, string sname, string accountNo, string pw, double bal, string hist)
        {
            this.fname = fname;
            this.sname = sname;
            this.accountNo = accountNo;
            this.pw = pw;
            this.bal = bal;
            this.hist = hist;
        }

        public void ListHist()
        {
            string[] list = hist.Split(";");
            foreach (string item in list)
            {
                if (item.StartsWith("p"))
                {
                    Console.WriteLine("You added £" + item.Trim('p'));
                }
                else
                {
                    Console.WriteLine("You withdrew £" + item.Trim('m'));
                }
            }
        }

        public bool Login()
        {
            byte count = 0;
            string inFName = Console.ReadLine();
            string inSName = Console.ReadLine();
            string inPw = Console.ReadLine();
            while (count < 3)
            {
                if (inFName == fname & inSName == sname & inPw == pw)
                {
                    Console.WriteLine("Welcome! {0} {1}.", fname, sname);
                    return true;
                }
                else 
                {
                    Console.WriteLine("The password and the information don't match. You have {0} chances remaining.", 3-count);
                    count++;
                }
            }
            return false;
        }

        public void AddVal(double increment)
        {
            if (Login())
            {
                bal += increment;
                hist+= "s" + increment.ToString();
            }                
        }

        public void Withdraw(double decrement)
        {
            if (Login())
            {
                bal -= decrement;
                hist += "m" + decrement.ToString();
            }
        }
    } 

    static class Atm
    {
        public static void PrintInterface()
        {
            Console.WriteLine("\tYongwook's ATM\t");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Available Services");
        }

        public static void Run()
        {
            PrintInterface();
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            Atm.Run();
        }
    }
}

