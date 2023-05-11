using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class Calculator
    {
        public Calculator()
        {
			IsFinished = false;
		}

		private double _result;
		private bool _isFinished;

		public double Result { get; set; }
        public bool IsFinished { get; set; }

		public void Sum(double num) => Result += num;
		public void Minus(double num) => Result -= num;
		public void Times(double num) => Result *= num;
		public void Divide(double num) => Result /= num;
		public void Clear() => Result = 0;

		public void Interface()
        {
			Console.WriteLine("Operações da Calculadora:");
			Console.WriteLine($"Total = {Result}");
			Console.WriteLine("1 - Soma");
			Console.WriteLine("2 - Subtrair");
			Console.WriteLine("3 - Multiplicar");
			Console.WriteLine("4 - Dividir");
			Console.WriteLine("5 - Limpar");
			Console.WriteLine("6 - Resultado");
			Console.WriteLine("===========================");
			Console.Write(">> ");
		}

        public void ChooseOptions(int option)
        {
            if (option >= 1 && option <= 4)
            {
                Console.WriteLine($"Digite o valor para a operação {option}");
                Console.Write(">> ");
                double value = Convert.ToDouble(Console.ReadLine());
                MathOperation(option, value);
            }
            else if (option == 5) Clear();
            else if (option == 6) IsFinished = true;
            else
            {
                Console.WriteLine("Opção Inválida! Pressione qualquer tecla e tente novamente...");
                Console.ReadKey();
            }
        }

        private void MathOperation(int option, double value)
        {
            switch (option)
            {
                case 1:
					Sum(value);
					break;
                case 2:
					Minus(value);
					break;
                case 3:
					Times(value);
					break;
                case 4:
					Divide(value);
					break;
			}
        }
	}
}