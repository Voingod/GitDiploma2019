using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateRadius
{
    public class RadiusCL
    {
        static public double[] Radius(string path, string select, string from)
        {
            DataTable dt = new DataTable();
            string stringcoonGlobal = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";

            OleDbConnection connGlobal = new OleDbConnection(stringcoonGlobal);

            OleDbDataAdapter da = new OleDbDataAdapter("Select " + select + " from [" + from + "$]", connGlobal);

            da.Fill(dt);

            double middle = 0;

            List<double> Radius = new List<double>();
            List<double> ForCulc = new List<double>();

            for (int j = 0; j < dt.Columns.Count; j++)
            {
                double summ = 0;

                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    summ += Convert.ToDouble(dt.Rows[i][j]);
                }

                middle = summ / (dt.Rows.Count - 1);
                ForCulc.Clear();
                for (int i = 1; i < dt.Rows.Count; i++)
                {

                    ForCulc.Add((Math.Abs(Convert.ToDouble(dt.Rows[i][j]) - middle)));
                }
                Radius.Add(ForCulc.Sum() / (dt.Rows.Count - 1));

                
            }
            return Radius.ToArray();
        }
    }
}
