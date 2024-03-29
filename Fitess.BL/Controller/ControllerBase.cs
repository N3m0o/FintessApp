using Fitess.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitess.BL.Controller
{
   public abstract class ControllerBase
    {
        protected void Save(string fileName, object item)
        {
#pragma warning disable SYSLIB0011
            var formatter = new BinaryFormatter();
            using (var fc = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fc, item);
            }
        }
        protected T Load<T>(string fileName)
        {
#pragma warning disable SYSLIB0011
            var formatter = new BinaryFormatter();
            using (var fc = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fc.Length > 0 && formatter.Deserialize(fc) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
