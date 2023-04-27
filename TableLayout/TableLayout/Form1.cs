using CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableLayout
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int conteoCliks;
        private int NumeroButton;

        private void button1_Click_1(object sender, EventArgs e)
        {
            conteoCliks++;
            NumeroButton++;

            AccessControl userControl = new AccessControl();
            tableLayoutPanel1.Controls.Add(userControl);

            if (conteoCliks >= 3)
            {
                RemoveArbitraryRow(tableLayoutPanel1, 2);
            }
                 
        }


            public static void RemoveArbitraryRow(TableLayoutPanel panel, int rowIndex)
            {
            //if (rowIndex >= panel.RowCount)
            //{
            //    return;
            //}

            
            //eliminar todos los controles de la fila que queremos eliminar
                for (int i = 0; i < panel.ColumnCount; i++)
                {
                    var control = panel.GetControlFromPosition(i, 0);
                    panel.Controls.Remove(control);
                }             
            //mover hacia arriba los controles de fila que vienen después de la fila que queremos elimina
                for (int i = rowIndex + 1; i < panel.RowCount; i++)
                {
                    for (int j = 0; j < panel.ColumnCount; j++)
                    {
                        var control = panel.GetControlFromPosition(j, i);
                        if (control != null)
                        {
                            panel.SetRow(control, i - 1);
                        }
                    }
                }

                //var removeStyle = panel.RowCount - 1;

                ////if (panel.RowStyles.Count > removeStyle)
                ////    panel.RowStyles.RemoveAt(removeStyle);

                ////panel.RowCount--;
            }
      

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        
    }
}
