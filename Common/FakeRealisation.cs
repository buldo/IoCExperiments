using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class FakeRealisation : ITestAction
    {
        public bool IsReady
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public int MakeAction(int a, int b)
        {
            return 256;
        }
    }
}
