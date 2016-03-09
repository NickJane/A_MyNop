using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nop.Data
{
    public class UnitOfWorkFactory
    {
        private static string CONTEXT_KEY = "Ef_DbContext_Static_Key";
        private static readonly object _syncObj = new object();
        public static IUnitOfWork CurrentUnitOfWork
        {

            get
            {
                if (IsInWebContext())
                {
                    if (HttpContext.Current.Items[CONTEXT_KEY] == null)
                    {

                        HttpContext.Current.Items[CONTEXT_KEY] = MyEngineContext.Current.Resolve<IUnitOfWork>();
                    }

                    return (IUnitOfWork)HttpContext.Current.Items[CONTEXT_KEY];
                    //return EngineContext.Current.Resolve<IUnitOfWork>();
                }
                else
                {
                    lock (_syncObj)
                    {

                        if (CallContext.GetData(CONTEXT_KEY) == null || ((IUnitOfWork)CallContext.GetData(CONTEXT_KEY)).Context == null)
                        {
                            //var dataSettingsManager = new DataSettingsManager();
                            //var dataProviderSettings = dataSettingsManager.LoadSettings();
                            //var nopObject = new NopObjectContext(dataSettingsManager.LoadSettings().DataConnectionString);
                            //UnitOfWork unitOfWork = new UnitOfWork(nopObject);

                            CallContext.SetData(CONTEXT_KEY, MyEngineContext.Current.Resolve<IUnitOfWork>());
                        }
                        return (IUnitOfWork)CallContext.GetData(CONTEXT_KEY);
                    }
                }
            }

        }
        public static bool HasContextOpen()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items[CONTEXT_KEY] == null)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if (CallContext.GetData(CONTEXT_KEY) == null)
                {
                    return false;
                }
                return true;
            }
        }
        public static bool IsInWebContext()
        {
            return HttpContext.Current != null;
        }
        public static void DisponseContext()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[CONTEXT_KEY] = null;
            }
            else
            {
                CallContext.SetData(CONTEXT_KEY, null);
                CallContext.FreeNamedDataSlot(CONTEXT_KEY);
            }
        }
    }
}
