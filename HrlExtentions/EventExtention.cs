using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrlExtentions
{
    public static class EventExtentions
    {
      /// <summary>
      /// Raise Event Manualy
      /// </summary>
      /// <param name="eventHandler"></param>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        public static void Raise(this EventHandler eventHandler,
          object sender, EventArgs e)
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        /// <summary>
        ///  Raise Event Manualy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
