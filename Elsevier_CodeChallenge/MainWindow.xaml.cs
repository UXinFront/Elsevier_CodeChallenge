using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
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

namespace Elsevier_CodeChallenge
{
    /// <summary>
    /// UI buttons works as triggers (buttons), textboxes for string input. 
    /// String will be split with either "," (if exists) or " " as seperators. Each new string will be set to First and Last name strings.
    /// If the amount of seperators exceed 2 ((first + middle) + last), the remaining will be added to firstname. To get the last name, a .Last has been used to pick last element in index. 
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Presenter namelist = new Presenter();
        public event PropertyChangedEventHandler? PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
            Presenter presenter = namelist;
            DataContext = presenter;
         }
        
        //              < BUTTON TRIGGER >              //
        // button acts as trigger for proces to split name in first and last name, using space as seperator, and using "," as operator for creating it as first or last.
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string Name = InputNameBox.Text;

            // checks to see if there are spaces in between words to create new strings out of. Checks if count of spaces are higher than 1, if so, combines them into first name.
            // For comma-rule condition (see below) to not trigger as well, condition is set to not contain comma (",")
            if (Name.Contains(' ') && !Name.Contains(","))
            {
                 string[] NameArray = Name.Split(' ');
                string firstname = "";
                string lastname = "";
                if (NameArray.Length>2)
                {
                   
                    firstname = NameArray[0] + " "+ NameArray[1];
                    lastname = NameArray.Last();

                    // debugging
                    Debug.WriteLine(firstname);
                    Debug.WriteLine(lastname);

                    namelist.dataCollection.Add(new Names(firstname, lastname));
                }
               else
                { 
                    firstname = NameArray[0];
                    lastname = NameArray[1];

                    // debugging
                    Debug.WriteLine(firstname);
                    Debug.WriteLine(lastname);

                    namelist.dataCollection.Add(new Names(firstname, lastname));
                }
                JsonReturner.SimpleWrite(namelist);
            }

            // checks if name has a comma separating. If so, will reorder for Last name to be the first string and vice versa.
            if (Name.Trim().Contains(','))
            {
               string[] NameArray = Name.Split(',');
               string firstname = NameArray[1].Trim();
               string lastname = NameArray[0].Trim();
                lastname = lastname.Replace(",", "");
                
                // debugging
                Debug.WriteLine(firstname);
                Debug.WriteLine(lastname);

                namelist.dataCollection.Add(new Names(firstname,lastname));

            }
            
        }

        //              < ESC/ENTER TRIGGER >              //
        // Small function to add (enter) or clear(esc) text quickly in WPF.
        private void InputNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SaveBtn_Click(sender, e);
            }
            if (e.Key == Key.Escape)
            {
                InputNameBox.Clear();
            }

        }
    }
}
