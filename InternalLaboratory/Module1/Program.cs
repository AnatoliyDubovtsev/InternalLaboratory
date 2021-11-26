public class Program
{
	public static void Main()
	{
		System.Console.WriteLine("Class Program");
		FirstFile.FirstFile.ShowMessage("Class FirstFile");
		SecondFile.SecondFile secondFile = new SecondFile.SecondFile("Class SecondFile");
		secondFile.ShowMessage();
		System.Console.ReadLine();
	}
}