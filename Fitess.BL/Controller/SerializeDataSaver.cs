﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitess.BL.Controller
{
    internal class SerializeDataSaver : IDataSaver
    {
        public List<T> Load<T> ()  where T: class 
        {
#pragma warning disable SYSLIB0011
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using (var fc = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fc.Length > 0 && formatter.Deserialize(fc) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void Save<T>(List<T> item) where T : class 
        {
#pragma warning disable SYSLIB0011
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using (var fc = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fc, item);
            }
        }
    }
}
