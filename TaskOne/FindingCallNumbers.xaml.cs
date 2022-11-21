using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskOne
{
    /// <summary>
    /// Interaction logic for FindingCallNumbers.xaml
    /// </summary>
    public partial class FindingCallNumbers : Window
    {
        public static string answer;
        public FindingCallNumbers()
        {
            InitializeComponent();
            tbT3.IsEnabled = false;
            btnScore.IsEnabled = false;
        }
        static Random rnd = new Random();
        TextFileCreation tfc = new TextFileCreation();
        List<string> thirdlvl = new List<string>();
        List<string> secondlvl = new List<string>();
        List<string> firstlvl = new List<string>();
        List<string> ans = new List<string>(4);
        List<string> ans2 = new List<string>(4);
        string[] lines = System.IO.File.ReadAllLines(@"CallNumbers2.txt"); // replace with your path
        int count;
        int cor;
        
        private void t3_Click(object sender, RoutedEventArgs e)
        {
            firstlvl.Clear();
            secondlvl.Clear();
            thirdlvl.Clear();

            ans.Clear();
            ans2.Clear();
            tbT3.Clear();
            lbT3.Items.Clear();
            tbT3.IsEnabled = true;
            lbT3.IsEnabled = true;
            gen();


            genAns();

        }
        public void gen()
        {
            //string[] lines = System.IO.File.ReadAllLines("C:\\Users\\liamv\\Desktop\\Semester 2\\PROG7312\\CallNumbers2.txt");
            foreach (string line in lines)
            {
                string sm = line;
                //sorting call numbers into the first level
                if (sm.Substring(0, 2) == "00")
                {
                    firstlvl.Add(sm);


                }
                if (sm.Substring(0, 2) == "10")
                {
                    firstlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "20")
                {
                    firstlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "30")
                {
                    firstlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "40")
                {
                    firstlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "50")
                {
                    firstlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "60")
                {
                    firstlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "70")
                {
                    firstlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "80")
                {
                    firstlvl.Add(sm);
                }
                if (sm.Substring(0, 2) == "90")
                {
                    firstlvl.Add(sm);
                }

                //sorting call numbers into the second level
                if (sm.Substring(0, 3) == "010")
                {
                    secondlvl.Add(sm);
                }
                if (sm.Substring(0, 3) == "120")
                {
                    secondlvl.Add(sm);

                }
                if (sm.Substring(0, 3) == "230")
                {
                    secondlvl.Add(sm);
                }
                if (sm.Substring(0, 3) == "340")
                {
                    secondlvl.Add(sm);
                }
                if (sm.Substring(0, 3) == "490")
                {
                    secondlvl.Add(sm);
                }
                if (sm.Substring(0, 3) == "550")
                {
                    secondlvl.Add(sm);
                }
                if (sm.Substring(0, 3) == "630")
                {
                    secondlvl.Add(sm);
                }
                if (sm.Substring(0, 3) == "740")
                {
                    secondlvl.Add(sm);
                }
                if (sm.Substring(0, 3) == "820")
                {
                    secondlvl.Add(sm);
                }
                if (sm.Substring(0, 3) == "950")
                {
                    secondlvl.Add(sm);

                }

                //sorting call numbers into the third level
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
         

        }

        public void genAns()
        {
            int r = rnd.Next(thirdlvl.Count);
            answer = thirdlvl[r];
            for (int i = 0; i < firstlvl.Count; i++)
            {
                if (answer.Substring(0, 1) == firstlvl[i].Substring(0, 1))
                {
                    ans.Add(firstlvl[i]);
                    firstlvl.RemoveAt(i);
                }
            }

         

            int lng = answer.Length - 4;
            tbT3.Text = answer.Substring(4, lng);

            for (int i = 0; i < 3; i++)
            {
                int j = rnd.Next(firstlvl.Count);
                ans.Add(firstlvl[j]);
                firstlvl.RemoveAt(j);
            }
            var randomized = ans.OrderBy(item => rnd.Next());
            foreach (string item in randomized)
            {

                lbT3.Items.Add(item);
            }
          



        }
        private void lbT3DoubleClick(object sender, MouseButtonEventArgs e)
        {
            count++;
            if (lbT3.SelectedItem.ToString().Substring(0, 1) == answer.Substring(0, 1))
            {
                cor++;
                MessageBox.Show("Correct");
            }
            if (lbT3.SelectedItem.ToString().Substring(0, 1) != answer.Substring(0, 1))
            {
                MessageBox.Show("incorrect");
            }
        



                lbT3.Items.Clear();

            for (int i = 0; i < secondlvl.Count; i++)
            {
                if (answer.Substring(0, 1) == secondlvl[i].Substring(0, 1))
                {
                    ans2.Add(secondlvl[i]);
                    secondlvl.RemoveAt(i);
                }
            }

            //  thirdlvl.Remove(answer);
            // ans.Add(answer);
           
            int lng = answer.Length - 4;
         

            for (int i = 0; i < 3; i++)
            {
                int j = rnd.Next(secondlvl.Count);
                ans2.Add(secondlvl[j]);
                secondlvl.RemoveAt(j);
            }
            var randomizedd = ans2.OrderBy(item => rnd.Next());
            foreach (string item in randomizedd)
            {

                lbT3.Items.Add(item);
            }
            if (count == 2)
            {
                    lbT3.IsEnabled = false;
                    lbT3.Items.Clear();
                btnScore.IsEnabled = true;
                }
            

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IntialPage ip = new IntialPage();
            Close();
            ip.Show();
        }

        private void btnScore_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Out of the 2 question you were asked to distinguish the Call number category, you got " + cor + " right, which is " 
                + "\n" + "The correct answers were: "
                + "\n" + "Question 1 =" + ans[0]
                + "\n" + "Question 2 =" + ans2[0]);
        }

        private void btnHow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HOW TO PLAY:" + "\n" +
                "\n" + "First Click on the PLAY button" +
                "\n" + "Once all the third level call number is generated in the text box at the top of the screen, and the list box below has generated the first level call numbers" +
                "\n" + "DOUBLE CLICK on the first level call number in the list box which is the corrsponding answer to the third level call number in the text box " +
                "\n" + "If the answer is incorrect or correct, you will move to the next level" +
                "\n" + "Now the list box is populated with second level call numbers" +
                "\n" + "DOUBLE CLICK on the second level call number in the list box which is the corrsponding answer to the third level call number in the text box " +
                "\n" + "Once you are done the list box will go grey, and then you click on the Score button" +
                "\n" + "GOOD LUCK AND ENJOY :)");
        }
    }
}
