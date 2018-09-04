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
        /// <summary>
        /// Check object is Null
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNull(this object source)
        {
            return source == null;
        }

        /// <summary>
        /// Check Object Has specify Property By Name
        /// </summary>
        /// <param name="Inp"></param>
        /// <param name="PropName"></param>
        /// <returns></returns>
        public static bool HasPropertie(this Object Inp, string PropName)
        {
            bool retval = false;
            var inpProp = Inp.GetType().GetProperties();
            if (inpProp.Where(s => s.Name == PropName).Count() > 0)
                retval = true;
            return retval;
        }
      
      
     
        

    }
}
