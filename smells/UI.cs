using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells
{
	public class UI :IUI
	{
		public void PrintToConsole(string s)
		{
			Console.Write(s+"\n\t");
		}
		public string ReadFromConsole()
		{
			return Console.ReadLine().ToString();
		}
		public void ExitConsole()
		{
			System.Environment.Exit(0);
		}
		public void ClearConsole()
		{
			Console.Clear();
		}
	}
}
