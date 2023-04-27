using CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableLayout
{
    public partial class ControlRoutes : Form
    {
        public ControlRoutes()
        {
            InitializeComponent();
        }

        private int conteoCliks;
        private int NumeroButton;
        SerialPort portArduino;
        Thread EsperaResposta;

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
        }

        private void ControlRoutes_Load(object sender, EventArgs e)
        {
            //Aquest detectarà tots els ports sèrie disponibles i els obrirà per connectar amb els dispositius.
            //Cada connexió es realitzarà en un fil independent, ja que cada port estarà escoltant.
            string[] ports =  SerialPort.GetPortNames();
            foreach (var port in ports)
            {                
                if (port != null)
                {
                    portArduino = new SerialPort();
                    portArduino.BaudRate = 9600;
                    portArduino.PortName = port;
                    portArduino.Open();
                }

                EsperaResposta = new Thread(LisenerAnser);
            }            
        }

        //pasar los puertos como valor para tener mas de uno
        private void LisenerAnser()
        {
            while (portArduino.IsOpen)
            {
                try
                {
                    valor = portArduino.ReadLine();
                    AfegirEnGraficConfig(valor);
                }
                catch (Exception)
                { }

            }
        }
    }
}
