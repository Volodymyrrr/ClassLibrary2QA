using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Tests
{
    class Singleton
    {
        
        public class singleton
        {
            private static readonly Singleton instance = new Singleton();

            public string Name { get; private set; }

            private singleton()
            {
                Name = System.Guid.NewGuid().ToString();
            }

            public static Singleton GetInstance()
            {
                return instance;
            }
        }

    }
}

