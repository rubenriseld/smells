using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Interfaces;

namespace smells;

using System;

//public sealed class ConsoleUI: IUI
//{
//    private static volatile ConsoleUI? instance;
//    private static object syncRoot = new Object();

//    private ConsoleUI() { }

    //public static ConsoleUI Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            lock (syncRoot)
    //            {
    //                if (instance == null)
    //                    instance = new ConsoleUI();
    //            }
    //        }

    //        return instance;
    //    }
    //}
public class ConsoleUI : IUI
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
