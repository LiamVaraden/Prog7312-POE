using java.awt.dnd;
using java.util;
using System;
using System.Collections;
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
using Random = System.Random;

namespace TaskOne
{
    /// <summary>
    /// Interaction logic for IdentifyingAreas.xaml
    /// </summary>
    public partial class IdentifyingAreas : Window
    {
        public IdentifyingAreas()
        {
            InitializeComponent();
            btnScore.IsEnabled = false;
           
        }
        ListBox dragSource = null;
        CustomDictionary<int, string> cd = new CustomDictionary<int, string>();
        private Dictionary<string, string> Descriptions = new Dictionary<string, string>();
        //string[] list2;
        List<string> list2 = new List<string>();
        //Random random = new Random();

        int correctAns = 0 ;
        int incorrectAns= 0 ;
        public static Random random = new Random();
        //private List<int> list = new List<int>();
        public SortedDictionary<string, string> dds = new SortedDictionary<string, string>();
   
        public void MakingNumber()
        {
            //CREATING A LIST TO ENSURE NO DUPLICATE
            var list = new List<String> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            //FORLOOP ITERATES TO CREATE THE THE RANDOM CALL NUMBERS
            for (int i = 0; i < 4 ; i++)
            {

                
                int index = random.Next(list.Count);
                string num = list[index];
               //REMOVES FROM THE LIST TO ENSURE IT CANT BE USED AGAIN
                list.Remove(num);
                
               
                int nums1 = random.Next(10, 100);
                int nums2 = random.Next(10, 100);
                char[] lets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

                Random first = new Random();
                Random second = new Random();
                Random third = new Random();
                string dis1 = " ";
                dis1 =num+ nums1.ToString("00") + "." + nums2.ToString("00")
                                + " " + lets[first.Next(0, 25)].ToString()
                                + lets[second.Next(0, 25)].ToString()
                                + lets[third.Next(0, 25)].ToString();
  
                        cd.Add(i, dis1); 
                        lbUnsorted.Items.Add(dis1);
       
               
                

            }
        }


   
     
        public void MakingAnswers()
        { 
           
              for (int i = 0; i < 4; i++)
            { 
                string temp1 = lbUnsorted.Items[i].ToString().Substring(0, 1);
                Descriptions.Add(temp1, dds[temp1]);
                list2.Add(dds[temp1]);
                dds.Remove(temp1);
          
               
            } 
            Dictionary<string, string> shuffled = dds.OrderBy(
            x => random.Next()).ToDictionary(items => items.Key, items => items.Value);
          
         

            
           

            for (int i = 0; i < shuffled.Count - 3; i++)
            {
                Descriptions.Add(shuffled.ElementAt(i).Key, shuffled.ElementAt(i).Value);
             

            }
         
            //MessageBox.Show(String.Join(Environment.NewLine, Descriptions));
         
           
            foreach (KeyValuePair<string, string> kv in Descriptions.OrderBy(x => x.Value).ToList())
            {
             
                lbSorted.Items.Add(kv.Value);
            }

            
        }



        private void btnStart_Clcik(object sender, RoutedEventArgs e)
        {
            
            cd.Clear();
            lbSorted.Items.Clear();
            lbUnsorted.Items.Clear();
            btnScore.IsEnabled = true;
            dds.Clear();
            dds.Add("0", "General Knowledge");
            dds.Add("1", "Philosophy & Psychology");
            dds.Add("2", "Religion");
            dds.Add("3", "Social Science");
            dds.Add("4", "Languages");
            dds.Add("5", "Science");
            dds.Add("6", "Technology");
            dds.Add("7", "Arts & Recreation");
            dds.Add("8", "Literature");
            dds.Add("9", "History & Geography");
            Descriptions.Clear();

            MakingNumber();
            MakingAnswers();

          
        }
        //button click event for matching
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //cheack method call
            Check();
        }
        
        //this method runs through the custom dictonary and the matched items by the user to see if its correct
        private void Check()
        {
           //checks if items for both lists are selected
            if (lbUnsorted.SelectedItems.Count > 0 && lbSorted.SelectedItems.Count > 0)
            {
               
                //variable to hold the first number of the call from thr user selection 
                var cn = lbUnsorted.SelectedItem.ToString().Substring(0, 1);

                //holds the answer from lst box 2
                var desc = lbSorted.SelectedItem.ToString();

                //checks that there is a value selected
                if (cn.Equals(null) || desc.Equals(null))
                {
                    MessageBox.Show("Please select an item from both boxes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                //check to see if its correct
                if (Descriptions[cn] == desc)
                {
                    //adds to answer variable
                    //outputs correct
                    //removes the answers once correct
                    correctAns++;
                    MessageBox.Show("Perfect Match :) ");
                    lbUnsorted.Items.Remove(lbUnsorted.SelectedItem);
                    lbSorted.Items.Remove(lbSorted.SelectedItem);

                }
                //output for incorrect answer
                if (Descriptions[cn] != desc)
                {
                    MessageBox.Show("Incorrect match...try again :(" );
                    incorrectAns++;
                }
                 
                }
            //if both are lists boxes are not sleected it will output a message
           else
            {
                MessageBox.Show("Please select an item from both Columns");
            }

            
       





              

            }

        private void btnScore_Click(object sender, RoutedEventArgs e)
        {
            double inscore = (correctAns + incorrectAns);
            double score = correctAns/inscore  *100;
            string outp = " ";

            if (score >= 50 && score < 80)
            {
                outp = "Fair attempt you have achieved an above average score of : " + score.ToString("0.00") + "%";
            }
            if (score >= 80 && score <= 90)
            {
                outp = "Well done you have achieved a brilliant score of : " + score.ToString("0.00") + "%";
            }
            if (score == 100)
            {
                outp = "Well done you have clocked the game.... your score is : " + score.ToString("0.00") + "%";
            }
            if (score >= 10 && score <= 40)
            {
                outp = "You have a below average score of : " + score.ToString("0.00") + "%";
            }
            if (score == 0)
            {
                outp = "Poor attempt, you got : " + score.ToString("0.00") + "%";
            }


            MessageBox.Show("Number of correct answers selected : " + correctAns.ToString()+
             "\n" + "Number of correct answers selected : " + incorrectAns.ToString()+
            "\n" + "Total number of attempts to match all call numbers to its genre : "+  inscore.ToString()+
            "\n"+ outp + "\n" + "The correct answers are: " + "\n" + cd.values[0]+ " = " + list2[0] + "\n" + cd.values[1] + " = " + list2[1] + "\n" + cd.values[2] + " = " + list2[2] + "\n" + cd.values[3] + " = " + list2[3] + "\n" +
                "");

        }

        private void btnHow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HOW TO PLAY:" + "\n" +
                "\n" + "First Click on the PLAY button" +
                "\n" + "Once all the call numbers are generated in the LEFT list box and the Genre in the RIGHT list box" +
                "\n" + " " +
                "\n" + "BELOW IS THE EXAMPLE OF HOW THEY SHOULD BE MATCHED" +
                "\n" + "000.00.AA-099.99.ZZ = General Knowledge" +
                "\n" + "100.00.AA-199.99.ZZ = Philosophy & Phsychology" +
                "\n" + "200.00.AA-299.99.ZZ = Religion" +
                "\n" + "300.00.AA-399.99.ZZ = Social Science" +
                "\n" + "400.00.AA-499.99.ZZ = Languages" +
                "\n" + "500.00.AA-599.99.ZZ = Science" +
                "\n" + "600.00.AA-699.99.ZZ = Technology" +
                "\n" + "700.00.AA-799.99.ZZ = Arts & Recreation" +
                "\n" + "800.00.AA-899.99.ZZ = Literature" +
                "\n" + "900.00.AA-999.99.ZZ = History & Geography" +
                "\n" + " " +
                "\n" + "Select the call number and its corresopnding genre by clicking on them once" +
                "\n" + "Once you have selected them, click the match button in the middle of the two list boxes" +
                "\n" + "If the answer is correct it will notify you with a message box that says PERFECT MATCH :) " +
                "\n" + "If the answer is incorrect it will notify you with a message box that says INCORRECT MATCH...TRY AGAIN :( " +
                "\n" + " " +
                "\n" + "Click the SCORE button and wait for the results :)" +
                "\n" + "You can play the game as many times as you wish by clicking the PLAY button" +
                "\n" + "Once you got your score and you dont wish to practice anymore, either click the EXIT button the top RIGHT of the screen" +
                "\n" + "Or click the BACK button on the top LEFT of the screen to go back to the main screen" +
                "\n" + "ENJOY AND GOODLUCK :)");

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
    }


    }


    

