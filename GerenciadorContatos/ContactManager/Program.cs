using ContactManager.Common.Models;

internal class Program
{
	private static void Main(string[] args)
	{
		Console.Clear();

		// Contact c1 = new Standard("Ibrahmovic", "(85) 98888-7777");
		// c1.ReceiveCall();

		Manager mgr = new Manager();
		// mgr.AddContact(c1);
		// mgr.AddContact(new Standard("Raimundo", "(85) 96666-5555"));
		// mgr.AddContact(new Business("Fosneca", "(85) 98786-9890", "(88) 3232-4343"));

		// mgr.ShowContactList();

		bool isProgramRunning = true;

		while (isProgramRunning)
		{
			Console.Clear();

			mgr.PrintMenu();
			string? option = Console.ReadLine();
			mgr.SelectionMenu(option, ref isProgramRunning);
		}

		Console.WriteLine (
			"\n" +
			"😁 Obrigado por testar meu App! 😁\n" +
			"🚀 Espero que tenha tenha curtido a experiência! 🚀\n" +
			"\n" +
			"🧑‍💻 Credits:\n" +
			"\t💼 ~ linkedin.com/in/szaire/\n" +
			"\t👾 ~ github.com/szaire/"
		);

		Console.WriteLine();
	}
}