using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TaskOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnScore.IsEnabled = false;
           

         
        }
        
        public int j = 1;
        //uses the customdictionary class to genearte the dictionary
        CustomDictionary<int, string> cd = new CustomDictionary<int, string>();
        CustomDictionary<int, string> cd2 = new CustomDictionary<int, string>();
        //mehtod for the button click event 
        CallNumbers cn = new CallNumbers();
        
        private void btnStart_Clcik(object sender, RoutedEventArgs e)
        {




          //  forloop genrates the radomized codes
            for (int i = 0; i < 10; i++)
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
               // outputs the codes on the listbox
           // CallNumbers.GeneratingCallNumber(10);
                lbUnsorted.Items.Add(dis1);
               
            }
           

            btnStart.IsEnabled = false;
           
        }

        //method for the double click list event on the unsorted list
        private void lbUnsorted_doubleClicked(object sender, MouseButtonEventArgs e)
        {
  
                lbSorted.Items.Add(lbUnsorted.SelectedItem);
                cd2.Add(j++, lbUnsorted.SelectedItem.ToString());
                lbUnsorted.Items.Remove(lbUnsorted.SelectedItem);

            int size = cd2.Size();

            if (size == 10)
            {
                
                btnScore.IsEnabled = true;
            }
                
            
            return;

        }

        private void btnScore_Click(object sender, RoutedEventArgs e)
        {
            
            
            int value = 0;
            cd.Sort();
           for (int i = 0; i < 10; i++)
            {
            
                    foreach (string item in cd2.values)
                    {
                        if (cd2.values[i] == cd.values[i])
                        {
                            value ++;
                        }
                    

                }
              
            }
            if (value >= 50 && value < 80)
            {
                MessageBox.Show("Fair attempt you have achieved an above average score of : " + value.ToString() + "%" + "Correct order is :" + "\n" + cd.values[0] + "\n" + cd.values[1] + "\n" + cd.values[2] + "\n" + cd.values[3] + "\n" + cd.values[4] + "\n" + cd.values[5] + "\n" + cd.values[6] + "\n" + cd.values[7] + "\n" + cd.values[9]);
            }
            if (value >= 80 && value <= 90)
            {
                MessageBox.Show("Well done you have achieved a brilliant score of : " + value.ToString() + "%" + "Correct order is :" + "\n" + cd.values[0] + "\n" + cd.values[1] + "\n" + cd.values[2] + "\n" + cd.values[3] + "\n" + cd.values[4] + "\n" + cd.values[5] + "\n" + cd.values[6] + "\n" + cd.values[7] + "\n" + cd.values[9]);
            }
            if (value == 100)
            {
                MessageBox.Show("Well done you have clocked the game.... your score is : " + value.ToString()+ "%" + "Correct order is :" + "\n" + cd.values[0] + "\n" + cd.values[1] + "\n" + cd.values[2] + "\n" + cd.values[3] + "\n" + cd.values[4] + "\n" + cd.values[5] + "\n" + cd.values[6] + "\n" + cd.values[7] + "\n" + cd.values[9]);
            }
            if (value >= 10 && value <= 40)
            {
                MessageBox.Show("You have a below average score of : " + value.ToString()+ "%" + "Correct order is :" + "\n" + cd.values[0] + "\n" + cd.values[1] + "\n" + cd.values[2] + "\n" + cd.values[3] + "\n" + cd.values[4] + "\n" + cd.values[5] + "\n" + cd.values[6] + "\n" + cd.values[7] + "\n" + cd.values[9]);
            }
            if (value == 0)
            { 
                MessageBox.Show("Poor attempt, you got : " + value.ToString() + "%" + "Correct order is :" + "\n" + cd.values[0] + "\n" + cd.values[1] + "\n" + cd.values[2] + "\n" + cd.values[3] + "\n" + cd.values[4] + "\n" + cd.values[5] + "\n" + cd.values[6] + "\n" + cd.values[7] + "\n" + cd.values[9]);
            }

            cd.Sort();
            lbUnsorted.Items.Add("Correct Order");
            lbUnsorted.Items.Add(cd);

        }

        private void btnHow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HOW TO PLAY:" + "\n" +
                "\n" + "First Click on the PLAY button" +
                "\n" + "Once all the call numbers are generated in the LEFT list box" +
                "\n" + "Double click on the call numbers from SMALLEST to BIGGEST" +
                "\n" + "Once all callnumber are moved from the LEFT list box to the RIGHT list box" +
                "\n" + "Click the SCORE button and wait for the results :)" +
                "\n" + "There is NO going back so think carefully" +
                "\n" + "You get ONE attempt" + 
                "\n" + "Once you got your score either click the EXIT button the top RIGHT of the screen" + 
                "\n" + "Or click the BACK button on the top LEFT of the screen to go back to the main screen");
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



