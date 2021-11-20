namespace SecondFile
{
	public class SecondFile
	{
		private string _message;
		
		public SecondFile() {}
		
		public SecondFile(string message)
		{
			_message = message;
		}

		public void ShowMessage()
		{
			System.Console.WriteLine(_message);
		}
	}
}