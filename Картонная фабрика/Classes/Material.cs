using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Картонная_фабрика.Classes
{
    internal struct Material
    {
        public string NameMaterial;
        public decimal Price;
        public int Count;
        public static DataTable Materials
        {
            get
            {
                return DataBaseWork.GetTable("Material");
            }
            set
            {

            }
        }
    }
}
