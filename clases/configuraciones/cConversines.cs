using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace clases.configuraciones
{
    public static class cConversines
    {

        
        public static DataSet toDataSet<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            return ds;
            
        }



        public static void toCombo<T>(this IList<T> data, ComboBox pComboBox)
        {

            //foreach (T item in data)
            //{
            //    lista.Add(new Item());
            //}

           

            //comboBox1.DisplayMember = "Name";
            //comboBox1.ValueMember = "Value";
            //comboBox1.DataSource = lista;
            //// Se asigna el evento para control el cambio de seleccion
            //comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);



        }





    }
}
