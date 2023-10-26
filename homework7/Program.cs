using System;
using System.Collections.Generic;

namespace homework7
{
    internal class Firm
    {
        public virtual void CalculateSalary()
        {
            Console.WriteLine("Мы таким не занимаемся.");
        }
        public virtual void GiveABonus()
        {
            Console.WriteLine("Мы таким не занимаемся.");
        }
        public virtual void TakeInventory()
        {
            Console.WriteLine("Мы таким не занимаемся.");
        }
        public virtual void InstallOperatingSystem()
        {
            Console.WriteLine("Мы таким не занимаемся.");
        }
        public virtual void UpdateOperatingSystem()
        {
            Console.WriteLine("Мы таким не занимаемся.");
        }
        public virtual void WriteProgramCode()
        {
            Console.WriteLine("Мы таким не занимаемся.");
        }
        public virtual void ConfigureInternalLogic()
        {
            Console.WriteLine("Мы таким не занимаемся.");
        }
        public virtual void UpdateTheProgram()
        {
            Console.WriteLine("Мы таким не занимаемся.");
        }
    }
    internal class Accounting : Firm
    {
        public override void CalculateSalary()
        {
            Console.WriteLine("Вам посчитали зарплату.");
        }
        public override void TakeInventory()
        {
            Console.WriteLine("Была произведена инвентаризация.");
        }
    }
    internal sealed class Accounting_Workers : Accounting
    {
        public Accounting_Workers(string name)
        {
            this.name = name;
        }
        private string name;
        private Firm department;
        private Accounting_Workers chief;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Firm Department
        {
            get { return department; }
            set { department = value; }
        }
        public Accounting_Workers Chief
        {
            get { return chief; }
            set { chief = value; }
        }
    }
    internal class InformationTechnologyDepartment : Firm
    {
        private string name;
        private Firm department;
        private Firm chief;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Firm Department
        {
            get { return department; }
            set { department = value; }
        }
        public Firm Chief
        {
            get { return chief; }
            set { chief = value; }
        }
        public override void InstallOperatingSystem()
        {
            Console.WriteLine("Нужно перенаправить эту задачу в отдел системщиков.");
        }
        public override void UpdateOperatingSystem()
        {
            Console.WriteLine("Нужно перенаправить эту задачу в отдел системщиков.");
        }
        public override void WriteProgramCode()
        {
            Console.WriteLine("Нужно перенаправить эту задачу в отдел разработчиков.");
        }
        public override void ConfigureInternalLogic()
        {
            Console.WriteLine("Нужно перенаправить эту задачу в отдел разработчиков.");
        }
        public override void UpdateTheProgram()
        {
            Console.WriteLine("Нужно перенаправить эту задачу в отдел разработчиков.");
        }
    }
    internal class Networks : InformationTechnologyDepartment
    {
        public override void InstallOperatingSystem()
        {
            Console.WriteLine("Операционная система установлена.");
        }
        public override void UpdateOperatingSystem()
        {
            Console.WriteLine("Операционная система обновлена.");
        }
    }
    internal sealed class Networks_Workers : Networks
    {
        public Networks_Workers(string name)
        {
            this.name = name;
        }
        private string name;
        private Firm department;
        private InformationTechnologyDepartment chief;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Firm Department
        {
            get { return department; }
            set { department = value; }
        }
        public InformationTechnologyDepartment Chief
        {
            get { return chief; }
            set { chief = value; }
        }
    }
    internal class DevelopmentAndSupport : InformationTechnologyDepartment
    {
        public override void WriteProgramCode()
        {
            Console.WriteLine("Мы написали программный код.");
        }
        public override void ConfigureInternalLogic()
        {
            Console.WriteLine("Внутренняя логика настроена.");
        }
        public override void UpdateTheProgram()
        {
            Console.WriteLine("Программа обновлена.");
        }
    }
    internal sealed class DevelopmentAndSupport_Workers : DevelopmentAndSupport
    {
        public DevelopmentAndSupport_Workers(string name)
        {
            this.name = name;
        }
        private string name;
        private Firm department;
        private DevelopmentAndSupport_Workers chief;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Firm Department
        {
            get { return department; }
            set { department = value; }
        }
        public DevelopmentAndSupport_Workers Chief
        {
            get { return chief; }
            set { chief = value; }
        }
    }
    internal class Worker
    {
        private string name;
        private Firm department;
        private Worker chief;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Firm Department
        {
            get { return department; }
            set { department = value; }
        }
        public Worker Chief
        {
            get { return chief; }
            set { chief = value; }
        }
    }
    internal sealed class Program
    {
        public static void SelectAction(Firm worker, char number)
        {
            switch (number)
            {
                case '1': worker.CalculateSalary(); break;
                case '2': worker.TakeInventory(); break;
                case '3': worker.InstallOperatingSystem(); break;
                case '4': worker.UpdateOperatingSystem(); break;
                case '5': worker.WriteProgramCode(); break;
                case '6': worker.GiveABonus(); break;
                case '7': worker.ConfigureInternalLogic(); break;
                case '8': worker.UpdateTheProgram(); break;
                default: Console.WriteLine("\nТакого действия нет."); break;
            }
        }
        static void Main(string[] args)
        {
            Worker CEO = new Worker();
            CEO.Name = "Семён";
            CEO.Department = new Firm();
            CEO.Chief = CEO;

            Accounting_Workers financial_director = new Accounting_Workers("Рашид");
            //financial_director.Department = new Accounting();
            //financial_director.Chief = CEO;

            Worker automation_director = new Worker();
            automation_director.Name = "О Ильхам";
            automation_director.Department = new InformationTechnologyDepartment();
            automation_director.Chief = CEO;

            Worker chief_in_accounting = new Worker();
            chief_in_accounting.Name = "Лукас";
            chief_in_accounting.Department = new Accounting();
            //automation_director.Chief = financial_director;

            InformationTechnologyDepartment head_of_information_systems = new InformationTechnologyDepartment();
            head_of_information_systems.Name = "Оркадий";
            head_of_information_systems.Department = new InformationTechnologyDepartment();
            //head_of_information_systems.Chief = automation_director;

            InformationTechnologyDepartment deputy_head_of_information_systems = new InformationTechnologyDepartment();
            deputy_head_of_information_systems.Name = "Володя";
            deputy_head_of_information_systems.Department = new InformationTechnologyDepartment();
            deputy_head_of_information_systems.Chief = head_of_information_systems;

            Networks_Workers head_of_systems_engineers = new Networks_Workers("Ильшат");
            head_of_systems_engineers.Department = new Networks();
            head_of_systems_engineers.Chief = deputy_head_of_information_systems;

            Worker deputy_head_of_systems_engineers = new Worker();
            deputy_head_of_systems_engineers.Name = "Иваныч";
            deputy_head_of_systems_engineers.Department = new Networks();
            //deputy_head_of_systems_engineers.Chief = head_of_systems_engineers;

            {
                Console.WriteLine("1 - посчитать зарплату;\n2 - провести инвентаризацию;\n3 - установить операционную систему;\n4 - обновить систему;\n5 - написать код;\n6 - выдать премию;\n7 - настроить внутреннюю логику;\n8 - обновить программу");
                bool flag = false;
                char number;
                do
                {
                    Console.WriteLine("\nВыберите действие: ");
                    number = Console.ReadKey().KeyChar;
                    flag = Char.IsDigit(number);
                } while (!flag);
                Firm worker = new Firm();
                Console.WriteLine("\nВведите имя сотрудника, который должен выполнить эту задачу: ");
                List<Networks_Workers> workers_nets = new List<Networks_Workers>(3)
                {
                    new Networks_Workers("Илья"),
                    new Networks_Workers("Витя"),
                    new Networks_Workers("Женя")
                };
                List<DevelopmentAndSupport_Workers> workers_development = new List<DevelopmentAndSupport_Workers>(4)
                {
                    new DevelopmentAndSupport_Workers("Марат"),
                    new DevelopmentAndSupport_Workers("Дина"),
                    new DevelopmentAndSupport_Workers("Ильдар"),
                    new DevelopmentAndSupport_Workers("Антон"),
                };
                foreach (Networks_Workers worker_1 in workers_nets)
                {
                    SelectAction(worker_1, number);
                }
            }
        }
    }
}