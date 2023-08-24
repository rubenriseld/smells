using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smells.Interfaces
{
    public interface IUI
    {
        void PrintToConsole(string s);
        string ReadFromConsole();
        void ExitConsole();
        void ClearConsole();
    }
}
