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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace TableLayout
{
    public partial class ControlRoutes : Form
    {
        public ControlRoutes()
        {
            InitializeComponent();
        }

        DataSet dts, dts2, Traffic;
        string query;
        private SqlConnection conn;
        SqlDataAdapter sqadapter;


        private int conteoCliks, NumeroButton;
        SerialPort portArduino, portArduino2, portArduino3, portArduino4, portArduino5;
        Thread EsperaResposta;
        string valor;
        int colum, row, cont, cantidadPorts;

        DateTime date;

        public void ConnexióBasededades()
        {
            string cnx = "";

            ConnectionStringSettings connec =
            ConfigurationManager.ConnectionStrings["Conecció"];

            if (connec != null)
            {
                cnx = connec.ConnectionString;
            }
            conn = new SqlConnection(cnx);
        }

        private void Revisar(AccessControl userControl)
        {
            string Becon = valor.Substring(0, 4);
            string BlackList = valor.Substring(4, 1);
            string ShipTransporter = valor.Substring(4, valor.Length - 4);

            //Pillar descbeacon i idRoute
            query = "SELECT * FROM ActiveBeacons where codeBeacon = '" + Becon + "'";
            sqadapter = new SqlDataAdapter(query, conn);
            conn.Open();
            dts2 = new DataSet();
            sqadapter.Fill(dts2, "ActiveBeacons");
            conn.Close();

            userControl.nameBeacon = dts2.Tables[0].Rows[0]["descBeacon"].ToString(); //descBeacon
            int route = int.Parse(dts2.Tables[0].Rows[0]["IdRoute"].ToString()); //IdRoute
            string sector = dts2.Tables[0].Rows[0]["Sector"].ToString(); //PROBAR QUE VA
            char[] caracter = sector.Substring(0, 1).ToCharArray();
            colum = Convert.ToInt32(caracter[0]) - 64;
            row = int.Parse(sector.Substring(1, 1));

            query = "SELECT * FROM Routes where idRoute = " + route + "";
            sqadapter = new SqlDataAdapter(query, conn);
            conn.Open();
            dts2 = new DataSet();
            sqadapter.Fill(dts2, "Routes");
            conn.Close();

            userControl.nameRoute = dts2.Tables[0].Rows[0]["descRoute"].ToString();

            //MODIFICAR CON BLACKLIST QUITAR TOP 1 y order by /Poner en vez de valorSub = ShipTransporter
            query = "SELECT * FROM BlackList WHERE ShipTransponder = '" + ShipTransporter.Trim() + "'";
            sqadapter = new SqlDataAdapter(query, conn);
            conn.Open();
            dts = new DataSet();
            sqadapter.Fill(dts, "BlackList");
            conn.Close();

            //Valor para determinar (AuthorizedAccess i idTypeShip) 
            byte Authorized = 0;
            int idTypeShip;

            //VERIFICAR Si esta en la BlackList
            if (dts.Tables[0].Rows.Count == 1)
            {
                userControl.nameShip = dts.Tables[0].Rows[0]["descShip"].ToString();
                userControl.shipDesc = dts.Tables[0].Rows[0]["Remarks"].ToString();
                userControl.ValidationMsg = AccessControl.Validations.Warning;

                //Cambiar valorSub = BlackList
                query = "SELECT * FROM ShipTypes WHERE TagId = '" + BlackList + "'";
                sqadapter = new SqlDataAdapter(query, conn);
                conn.Open();
                dts = new DataSet();
                sqadapter.Fill(dts, "ShipTypes");
                conn.Close();

                idTypeShip = int.Parse(dts.Tables[0].Rows[0]["idTypeShip"].ToString());
                userControl.shipType = dts.Tables[0].Rows[0]["DescTypeShip"].ToString();
            }
            else
            {
                query = "SELECT * FROM ShipTypes WHERE TagId = '" + BlackList + "'";
                sqadapter = new SqlDataAdapter(query, conn);
                conn.Open();
                dts = new DataSet();
                sqadapter.Fill(dts, "ShipTypes");
                conn.Close();
                Authorized = 1;

                userControl.nameShip = dts.Tables[0].Rows[0]["DescTypeShip"].ToString();
                userControl.shipDesc = "Information not available.";
                userControl.shipType = dts.Tables[0].Rows[0]["DescTypeShip"].ToString();
                idTypeShip = int.Parse(dts.Tables[0].Rows[0]["idTypeShip"].ToString());

            }

            //Primer insertarem els valors en la taula ROUTETRAFFIC
            string hora = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            date = DateTime.ParseExact(hora, "yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture);


            //DateTime date = DateTime.Now;
            //string hora = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
            query = "insert into RouteTraffic values (" + route + ",'" + ShipTransporter.Trim() + "'," +
                "CAST(N'" + hora + "' AS DateTime)" + "," + idTypeShip + ", " + Authorized + ")";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            //Mostrar DTS [TOP 1 todos los de apartir de tal dia]
            query = "SELECT DescTypeShip , ShipTransponder ,TrafficDate , AuthorizedAccess, descBeacon , descRoute " +
                "FROM RouteTraffic , ShipTypes , ActiveBeacons, Routes " +
                "WHERE RouteTraffic.idTypeShip = ShipTypes.idTypeShip" +
                " and RouteTraffic.idBeacon = ActiveBeacons.idActiveBeacon" +
                " and ActiveBeacons.IdRoute = Routes.idRoute" +
                " and DATEPART(DAY, TrafficDate) = '" + date.Day + "'" +
                " and DATEPART(MONTH, TrafficDate) = '" + date.Month + "'" +
                " and DATEPART(HOUR, TrafficDate) >= '" + date.Hour + "'";
            sqadapter = new SqlDataAdapter(query, conn);
            conn.Open();
            Traffic = new DataSet();
            sqadapter.Fill(Traffic, "RouteTraffic");
            conn.Close();

            if (dgvTraficControl.InvokeRequired)
            {
                dgvTraficControl.Invoke((MethodInvoker)delegate
                {
                    dgvTraficControl.DataSource = Traffic.Tables["RouteTraffic"];
                });
            }
        }

        public void AfegirControl()
        {
            conteoCliks++;
            NumeroButton++;

            AccessControl userControl = new AccessControl();
            //DATASET
            Revisar(userControl);


            if (TLPControl.InvokeRequired)
            {
                TLPControl.Invoke((MethodInvoker)delegate
                {
                    TLPControl.Controls.Add(userControl);
                });
            }

            if (tlpMap.InvokeRequired)
            {
                tlpMap.Invoke((MethodInvoker)delegate
                {
                    PictureBox imatge = new PictureBox();
                    imatge.Image = Image.FromFile("puntomapa.png");
                    imatge.Dock = DockStyle.Fill;
                    imatge.SizeMode = PictureBoxSizeMode.Zoom;

                    if (cont > 0)
                    {
                        tlpMap.Controls.Clear();
                        cont = 0;
                    }

                    tlpMap.Controls.Add(imatge, colum, row); //cotrol, colum row
                    cont++;
                });
            }

            if (conteoCliks >= 3)
            {
                RemoveArbitraryRow(TLPControl, 2);
            }

            valor = "";
        }


        public static void RemoveArbitraryRow(TableLayoutPanel panel, int rowIndex)
        {
            //eliminar todos los controles de la fila que queremos eliminar
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                var control = panel.GetControlFromPosition(i, 0);
                if (panel.InvokeRequired)
                {
                    panel.Invoke((MethodInvoker)delegate
                    {
                        panel.Controls.Remove(control);
                    });
                }
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

        private void ControlRoutes_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (conn != null)
                {
                    query = "DELETE From RouteTraffic where DATEPART(DAY, TrafficDate) = '" + date.Day + "'" +
                                                    " and DATEPART(MONTH, TrafficDate) = '" + date.Month + "'" +
                                                    " and DATEPART(HOUR, TrafficDate) >= '" + date.Hour + "'";

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }

                if (portArduino != null || portArduino2 != null)
                {
                    if (portArduino.IsOpen)
                    {
                        portArduino.Write("A\n");
                        portArduino.Close();
                    }
                    else if (portArduino2.IsOpen)
                    {
                        portArduino2.Write("A\n");
                        portArduino2.Close();
                    }
                }
                if (EsperaResposta != null)
                {
                    EsperaResposta.Abort();
                }
                //EsperaResposta2.Abort();
                //EsperaResposta3.Abort();
                //EsperaResposta4.Abort();
                //EsperaResposta5.Abort();
            }
            catch (Exception)
            {
            }
        }



        private void ControlRoutes_Load(object sender, EventArgs e)
        {
            //Aquest detectarà tots els ports sèrie disponibles i els obrirà per connectar amb els dispositius.
            //Cada connexió es realitzarà en un fil independent, ja que cada port estarà escoltant.
            ConnexióBasededades();

            string[] ports = SerialPort.GetPortNames();

            foreach (var port in ports)
            {
                cbPorts.Items.Add(port);
            }

            query = "SELECT * FROM ActiveBeacons";
            sqadapter = new SqlDataAdapter(query, conn);
            conn.Open();
            dts = new DataSet();
            sqadapter.Fill(dts, "ActiveBeacons");
            conn.Close();

            for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
            {
                cbBeacons.Items.Add(dts.Tables[0].Rows[i]["codeBeacon"].ToString());
            }

            //EsperaResposta = new Thread(LisenerAnser);
            //EsperaResposta.Start();

            //EsperaResposta2 = new Thread(LisenerAnser2);
            //EsperaResposta2.Start();

            //EsperaResposta3 = new Thread(LisenerAnser3);
            //EsperaResposta3.Start();

            //EsperaResposta4 = new Thread(LisenerAnser4);
            //EsperaResposta4.Start();

            //EsperaResposta5 = new Thread(LisenerAnser5);
            //EsperaResposta5.Start();
        }

        List<SerialPort> portsab = new List<SerialPort>();
        private void btnConnect_Click(object sender, EventArgs e)
        {
            portArduino = new SerialPort();
            portArduino.BaudRate = 9600;
            portArduino.PortName = cbPorts.Text;


            if (portsab.Contains(portArduino))
            {
                portsab.Add(portArduino);

                portArduino.Open();
                portArduino.Write("" + cbBeacons.Text + "\n");
                EsperaResposta = new Thread(LisenerAnser);
                EsperaResposta.Start(portArduino);
            }           

            cantidadPorts++;

        }

        //Pasar los puertos como valor para tener mas de uno
        private void LisenerAnser(Object port)
        {
            SerialPort portavaible = (SerialPort)port;
            try
            {
                if (portavaible != null)
                {
                    while (portavaible.IsOpen)
                    {

                        if (portavaible.BytesToRead > 0)
                        {
                            valor += portavaible.ReadLine();
                            AfegirControl();
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }
    }
}
