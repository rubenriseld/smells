using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Interfaces;

namespace smells
{
    public class ConsoleUI :IUI
	{
		public void Output(string s)
		{
			Console.WriteLine(s);
		}
		public string Input()
		{
			return Console.ReadLine().ToString();
		}
		public void Exit()
		{
			System.Environment.Exit(0);
		}
		public void Clear()
		{
			Console.Clear();
		}
	}
}
