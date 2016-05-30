using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

// 22+48

namespace Calculator0
{
    interface IOperation
    {
        char Symbol { get; }
        int Operate(int l, int r);
    }

    [Export(typeof(IOperation))]
    public class Plus : IOperation
    {
        public char Symbol => '+';

        public int Operate(int l, int r)
        {
            return l+r;
        }
    }

    [Export(typeof(IOperation))]
    public class Minus : IOperation
    {
        public char Symbol => '-';

        public int Operate(int l, int r)
        {
            return l - r;
        }
    }

    [Export(typeof(IOperation))]
    public class Mult : IOperation
    {
        public char Symbol => '*';

        public int Operate(int l, int r)
        {
            return l * r;
        }
    }

    [Export(typeof(IOperation))]
    public class Div : IOperation
    {
        public char Symbol => '/';

        public int Operate(int l, int r)
        {
            return l / r;
        }
    }

    class Calculator
    {
        [ImportMany(typeof(IOperation))]
        public List<IOperation> operations;

        public string Calculate(string command)
        {
            int left;
            int right;
            char opSymbol;
            int opInx = FindFirstNonDigit(command);
            if (opInx < 0)
                return "No operator specified";
            try
            {
                left = int.Parse(command.Substring(0, opInx));
                right = int.Parse(command.Substring(opInx + 1));
            }
            catch (Exception)
            {
                return "Error parsing commmand";
            }

            opSymbol = command[opInx];
            foreach (IOperation op in operations)
            {
                if (op.Symbol == opSymbol)
                    return op.Operate(left, right).ToString();
            }    

            return "Unknown operation '" + opSymbol + "'!";
        }

        private static int FindFirstNonDigit(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!Char.IsDigit(s[i]))
                    return i;
            }
            return -1;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            //calc.operations = new List<IOperation>(new IOperation[] {new Plus(), new Minus(), new Mult(), new Div()});
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(calc);

            String s;
            Console.WriteLine("Enter Command:");
            while (true)
            {
                s = Console.ReadLine();
                Console.WriteLine(calc.Calculate(s));
            }
        }
    }
}
