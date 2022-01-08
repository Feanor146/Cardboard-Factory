using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Картонная_фабрика.Classes
{
    internal struct Product
    {
        public string Name;
        public decimal Price;
        public int Count;
        public static DataTable Products            
        {
            get
            {
                return DataBaseWork.GetTable("Products");
            }
            set
            {

            }
        }            
    }
}
