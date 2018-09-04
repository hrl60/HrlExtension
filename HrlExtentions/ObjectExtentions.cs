using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrlExtentions
{
    public static class ObjectExtentions
    {
        public static bool IsNull(this object source)
        {
            return source == null;
        }
        public static void Raise(this EventHandler eventHandler,
          object sender, EventArgs e)
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        public static bool HasPropertie(this Object Inp, string PropName)
        {
            bool retval = false;
            var inpProp = Inp.GetType().GetProperties();
            if (inpProp.Where(s => s.Name == PropName).Count() > 0)
                retval = true;
            return retval;
        }
      
        public static void Raise<T>(this EventHandler<T> eventHandler,
            object sender, T e)
           where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }
     
     
        

    }
}
