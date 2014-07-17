using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MainRealisation : ITestAction
    {
        public bool IsReady {get; set; }

        public int MakeAction(int a, int b)
        {
            return a + b;
        }
    }
}
