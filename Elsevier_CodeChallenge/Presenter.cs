using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Elsevier_CodeChallenge
{
    /// <summary>
    /// To get information, a collection class is made to seperate the "raw" data (Names.cs) from mainwindow. Good practice to seperate. In future, main functionality should be put in here instead of MW.
    /// </summary>
    public class Presenter
    {
        public ObservableCollection<Names> dataCollection { get; set; }
        public Presenter()
        {
            dataCollection = new ObservableCollection<Names>();
        }
    }
}
