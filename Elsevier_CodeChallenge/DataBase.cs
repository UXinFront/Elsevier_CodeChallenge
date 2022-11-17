using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Elsevier_CodeChallenge
{
    public class DataBase
    {
        public ObservableCollection<Names> dataBase;

        public DataBase()
        {
            dataBase = new ObservableCollection<Names>();
        }
        public void CreateNameList()
        {
            foreach (Names name in dataBase)
            {
                dataBase.Add(name);
            }
        }

    }

   

}
