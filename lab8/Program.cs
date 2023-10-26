using System;
using System.Collections.Generic;
using System.IO;

namespace lab8
{
    public enum AccountTypes
    {
        Current,
        Savings
    }
    class Song
    {
        private string name;
        private string author;
        private Song prev;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public Song Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
        }
        public string PrintTitleAndAuthor()
        {
            string s = name + ' ' + author;
            Console.WriteLine(s);
            return(s);
        }
        public override bool Equals(object d)
        {
            Song song = (Song)d;
            if ((song.Name == Name) && (song.Author == Author))
            {
                Console.WriteLine("Песни одинаковые.");
                return true;
            }
            else
            {
                Console.WriteLine("Песни разные.");
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    internal class BankAccount
    {
        static private ulong number = CreateAccountNumber();
        private double balance;
        private AccountTypes type;
        public ulong Number
        {
            get { return number; }
            set { number = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public AccountTypes Type
        {
            get { return type; }
            set { type = value; }
        }
        static private ulong CreateAccountNumber()
        {
            Random n = new Random(0);
            bool flag = false;
            do
            {
                flag = ulong.TryParse(Convert.ToString(n.Next()), out number);
            } while (!flag);
            return (number);
        }
        public void CreateNewAccountNumber()
        {
            BankAccount.number += 1;
        }
        public void WithdrawMoney(double sum)
        {
            if (sum > balance)
            {
                throw new ArgumentOutOfRangeException("У вас нет таких денег.");
            }
            else
            {
                balance -= sum;
            }
        }
        public void PutMoney(double sum)
        {
            balance += sum;
        }
        public void TransferMoney(ref BankAccount account_taker, double sum)
        {
            byte k = 0;
            if (balance >= sum)
            {
                k++;
            }
            WithdrawMoney(sum);
            if (k == 1)
            {
                account_taker.PutMoney(sum);
            }
        }
        public void Print()
        {
            Console.WriteLine($"Номер счёта: {number}\nБаланс: {balance}\nТип счёта: {type}");
        }
    }
    internal class Program
    {
        private static string ReverseTheLine(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            string new_s = "";
            foreach (char c in array)
            {
                new_s += c;
            }
            return new_s;
        }
        public static void SearchMail(ref string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    s.Remove(0, i);
                    break;
                }
            }
        }
        private static bool CheckImplementInterface(object parameter)
        {
            //System.IFormattable thing = parameter as System.IFormattable;
            if (parameter is IFormattable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {

            // упражнение 8.1
            //{
            //    BankAccount account_1 = new BankAccount();
            //    BankAccount account_2 = new BankAccount();
            //    account_1.CreateNewAccountNumber();
            //    account_2.CreateNewAccountNumber();
            //    account_1.Balance = 8092.3;
            //    account_2.Balance = 3054.48;
            //    account_1.Type = AccountTypes.Current;
            //    account_2.Type = AccountTypes.Current;
            //    double sum = 4000;
            //    account_1.TransferMoney(ref account_2, sum);
            //    account_1.Print();
            //    account_2.Print();
            //}

            {
                Console.WriteLine("Упражнение 8.2:");
                Console.Write("Введите строку, которую хоите перевернуть (потом нажмите Enter): ");
                Console.WriteLine(ReverseTheLine(Console.ReadLine()));
            }

            {
                Console.WriteLine("\nУпражнение 8.3:");
                Console.Write("\nУкажите имя файла (Enter): ");
                string file_name = Console.ReadLine();
                string link = @"C:\";
                if (File.Exists(link + @"\" + file_name))
                {
                    string read_text = File.ReadAllText(link);
                    string create_text = read_text.ToLower();
                    File.WriteAllText(link, create_text);
                }
                else
                {
                    Console.WriteLine("Файла с таким именем не существует.");
                }
            }

            {
                Console.WriteLine("\nУпражнение 8.4:");
                if (CheckImplementInterface(AccountTypes.Current))
                {
                    Console.WriteLine("Введённый объект реализует интерфейс IFormattable .");
                }
                else
                {
                    Console.WriteLine("Введённый объект не реализует интерфейс IFormattable .");
                }
            }

            {
                Console.WriteLine("\nДомашнее задание 8.1:");
                string link = @"C:\Users\ламлеса\Desktop";
                File.Create(link);
                FileInfo file = new FileInfo(link + @"\" + "Текстовый документ.txt");
                string read_text = File.ReadAllText(link + @"\" + "Текстовый документ.txt");
                StreamReader sr = new StreamReader("C: /Users/ламлеса/Desktop/Текстовый документ.txt");
                while (sr.ReadLine() != null)
                {
                    string s = sr.ReadLine();
                    SearchMail(ref s);
                    File.AppendAllText(link, s);
                }
            }

            {
                Console.WriteLine("\nДомашнее задание 8.2:");
                List<Song> songs = new List<Song>(4)
                {
                    new Song("Country House", "Blur"),
                    new Song("Переплетено", "Oxxxymiron"),
                    new Song("Из окна", "Noize MC"),
                    new Song("The Lovecats", "The Cure")
                };
                songs[0].Equals(songs[1]);
            }
        }
    }
}