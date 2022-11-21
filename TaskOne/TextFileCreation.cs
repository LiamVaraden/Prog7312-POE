using System;
using System.Collections.Generic;
using System.Text;

namespace TaskOne
{
    class TextFileCreation
    {
        List<string> thirdlvl = new List<string>();
        public void gen()
        {
            string[] lines = System.IO.File.ReadAllLines("C:\\Users\\liamv\\Desktop\\Semester 2\\PROG7312\\CallNumbers2.txt");

          
            foreach (string line in lines)
            {
             
                string sm = line;

         
                if (sm.Substring(0, 2) == "01" && sm.Substring(0, 3) != "010")
                {
                    thirdlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "12" && sm.Substring(0, 3) != "120")
                {

                    thirdlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "23" && sm.Substring(0, 3) != "230")
                {
                    thirdlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "34" && sm.Substring(0, 3) != "340")
                {
                    thirdlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "49" && sm.Substring(0, 3) != "490")
                {
                    thirdlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "55" && sm.Substring(0, 3) != "550")
                {
                    thirdlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "63" && sm.Substring(0, 3) != "630")
                {
                    thirdlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "74" && sm.Substring(0, 3) != "740")
                {
                    thirdlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "82" && sm.Substring(0, 3) != "820")
                {
                    thirdlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "95" && sm.Substring(0, 3) != "950")
                {
                    thirdlvl.Add(sm);
                }

            }
            foreach (string item in thirdlvl)
            {
                FindingCallNumbers findingCallNumbers = new FindingCallNumbers();
                findingCallNumbers.lbT3.Items.Add(item); 
            }
           
        }
    }
}
