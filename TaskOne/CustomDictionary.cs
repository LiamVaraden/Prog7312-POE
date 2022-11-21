using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskOne
{
    class CustomDictionary <K, V>
    {
       public List<K> keys = new List<K>();
       public List<V> values = new List<V>();


        public void Add(K key, V value)
        {
            //check
            if (key == null )
            {
                throw new ArgumentException("Key cannot be null");
    }

            if (!keys.Contains(key))
                {
                //add the item --- key + value
                keys.Add(key);
                values.Add(value);
            }
            else
{
    throw new ArgumentException("key already exists");
}
        }

        public override string ToString()
        {
            string s = ""; MainWindow mainWindow = new MainWindow();
            for (int i = 0; i < keys.Count(); i++)
            {
                s +=values[i] + "\n" ;
               
               
            }

            return (s);
        }
        public int Size()
        {
            return keys.Count();

        }
        public void Sort()
        {
            var keyArray = keys.ToArray();
            var valueArray = values.ToArray();

            Array.Sort( valueArray, keyArray);
            keys = new List<K>(keyArray);
            values = new List<V>(valueArray);
        }
        public void Clear()
        {
            keys.Clear();
            values.Clear();
        }

    }
}


