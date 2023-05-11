using Calculadora.Models;

internal class Program
{
	private static void Main(string[] args)
	{
		Console.Clear();

		Calculator calc = new Calculator();

		try
		{
			while(!calc.IsFinished)
			{
				Console.Clear();
				calc.Interface();
				int option = Convert.ToInt32(Console.ReadLine());
				calc.ChooseOptions(option);
			}

			Console.WriteLine("===========================");
			Console.WriteLine($"Resultado = {calc.Result}");
		}
		catch (FormatException fEx)
		{
			Console.WriteLine($"Argumento inválido! Utilize apenas números.\n{fEx.Message}");
		}
	}
}