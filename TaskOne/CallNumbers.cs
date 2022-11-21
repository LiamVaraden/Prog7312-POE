using System;
using System.Collections.Generic;
using System.Text;

namespace TaskOne
{ 
   public class CallNumbers
    {
       //public CustomDictionary<int, string> cd = new CustomDictionary<int, string>();
        public static void GeneratingCallNumber(int i)
        {
           CustomDictionary<int, string> cd = new CustomDictionary<int, string>();
            for (i = 0; i < 10; i++)
            {


                Random random = new Random();
                int nums1 = random.Next(100, 1000);
                int nums2 = random.Next(10, 100);
                char[] lets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

                Random first = new Random();
                Random second = new Random();
                Random third = new Random();
                string dis1 = " ";
                dis1 = nums1.ToString("000") + "." + nums2.ToString("00")
                        + " " + lets[first.Next(0, 25)].ToString()
                        + lets[second.Next(0, 25)].ToString()
                        + lets[third.Next(0, 25)].ToString();


                //adds the codes to the dictionary 
               cd.Add(i, dis1);
               

            }
        }
    }
}
