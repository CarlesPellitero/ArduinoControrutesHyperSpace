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

        private Image shipImgVar;

        public Image shipImage
        {
            get { return shipImgVar; }
            set { picShip.Image = value; }
        }

        private Image beaconImageVar;

        public Image beaconImage
        {
            get { return beaconImageVar; }
            set { picBeacon.Image = value; }
        }
        private Image routeImageVar;

        public Image routeImage
        {
            get { return routeImageVar; }
            set { picRoute.Image = value; }
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
                picValidation.Image = Image.FromFile(Path.Combine(Application.StartupPath, "warning.png"));
            }
        }
    }
}
