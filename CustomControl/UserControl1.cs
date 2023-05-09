using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class AccessControl : UserControl
    {
        public AccessControl()
        {
            InitializeComponent();
        }

        private string nameShipVar;

        public string nameShip
        {
            get { return nameShipVar; }
            set { txtShip.Text = value; }
        }
        private string nameRouteVar;

        public string nameRoute
        {
            get { return nameRouteVar; }
            set { txtRoute.Text = value; }
        }
        private string nameBeaconVar;

        public string nameBeacon
        {
            get { return nameBeaconVar; }
            set { txtBeacon.Text = value; }
        }

        private string shipDescVar;

        public string shipDesc
        {
            get { return shipDescVar; }
            set { rtxtShip.Text = value; }
        }

        private string shipTypVar;

        public string shipType
        {
            get { return shipTypVar; }
            set { shipTypVar = value; }
        }

        public enum Validations
        {
            Warning,
            Okay
        };

        private Validations ValMsg = Validations.Okay;

        public Validations ValidationMsg
        {
            get { return ValMsg; }
            set { ValMsg = value; }
        }




        private void UserControl1_Load(object sender, EventArgs e)
        {
            if (ValMsg == Validations.Warning)
            {
                picValidation.Image = Image.FromFile(Path.Combine(Application.StartupPath, "alert.png"));
            }
            if (shipTypVar.Equals("First Order Navy Spaceship") || shipTypVar.Equals("First Order Consular Spaceship"))
            {
                picShip.Image = Image.FromFile(Path.Combine(Application.StartupPath, "s tar-wars.png.png"));

            }
            else if (shipTypVar.Equals("Cargo Spaceship"))
            {
                picShip.Image = Image.FromFile(Path.Combine(Application.StartupPath, "PersonalShipW.png"));
            }
        }
    }
}
