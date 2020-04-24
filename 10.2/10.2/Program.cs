using System;

namespace _10._2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetBanknotes banknotes = new GetBanknotes();
            banknotes.Print(banknotes.Sort(banknotes.InitBanknoteArray()));
        }       
    }
}
