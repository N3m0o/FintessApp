using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitess.BL.Model
{
    /// <summary>
    /// Gender 
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        ///  Gender name
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Set gender 
        /// </summary>
        /// <param name="name"> Gender name </param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name) 
        {
            if (string.IsNullOrWhiteSpace(name)) 
            { 
                throw new ArgumentNullException("The gender is entered incorrectly"
                ,nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
