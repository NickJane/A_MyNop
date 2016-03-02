using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Infrastructure
{
    public class MyEngineContext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static MyNopEngine Initialize(bool forceRecreate)
        {
            if (Singleton<MyNopEngine>.Instance == null || forceRecreate)
            { 
                Singleton<MyNopEngine>.Instance = new MyNopEngine();
                Singleton<MyNopEngine>.Instance.Initialize();
            }
            return Singleton<MyNopEngine>.Instance;
        }

        public static MyNopEngine Current
        {
            get
            {
                if (Singleton<MyNopEngine>.Instance == null)
                {
                    Initialize(false);
                }
                return Singleton<MyNopEngine>.Instance;
            }
        }
    }
}
