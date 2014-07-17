using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public interface ITestAction
    {
        bool IsReady
        {
            get;
            set;
        }
    
        int MakeAction(int a, int b);
    }
}
