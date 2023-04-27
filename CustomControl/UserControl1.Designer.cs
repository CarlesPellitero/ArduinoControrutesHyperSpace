
namespace CustomControl
{
    partial class AccessControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessControl));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelShip = new System.Windows.Forms.Panel();
            this.rtxtShip = new System.Windows.Forms.RichTextBox();
            this.panelShipName = new System.Windows.Forms.Panel();
            this.txtShip = new System.Windows.Forms.TextBox();
            this.picShip = new System.Windows.Forms.PictureBox();
            this.picValidation = new System.Windows.Forms.PictureBox();
            this.panelBeacon = new System.Windows.Forms.Panel();
            this.txtBeacon = new System.Windows.Forms.TextBox();
            this.picBeacon = new System.Windows.Forms.PictureBox();
            this.panelRoute = new System.Windows.Forms.Panel();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.picRoute = new System.Windows.Forms.PictureBox();
            this.panelMain.SuspendLayout();
            this.panelShip.SuspendLayout();
            this.panelShipName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picValidation)).BeginInit();
            this.panelBeacon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBeacon)).BeginInit();
            this.panelRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelShip);
            this.panelMain.Controls.Add(this.panelBeacon);
            this.panelMain.Controls.Add(this.panelRoute);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(592, 148);
            this.panelMain.TabIndex = 0;
            // 
            // panelShip
            // 
            this.panelShip.Controls.Add(this.rtxtShip);
            this.panelShip.Controls.Add(this.panelShipName);
            this.panelShip.Controls.Add(this.picValidation);
            this.panelShip.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShip.Location = new System.Drawing.Point(0, 56);
            this.panelShip.Name = "panelShip";
            this.panelShip.Size = new System.Drawing.Size(592, 92);
            this.panelShip.TabIndex = 2;
            // 
            // rtxtShip
            // 
            this.rtxtShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtShip.Location = new System.Drawing.Point(0, 36);
            this.rtxtShip.Name = "rtxtShip";
            this.rtxtShip.Size = new System.Drawing.Size(485, 56);
            this.rtxtShip.TabIndex = 2;
            this.rtxtShip.Text = "";
            // 
            // panelShipName
            // 
            this.panelShipName.Controls.Add(this.txtShip);
            this.panelShipName.Controls.Add(this.picShip);
            this.panelShipName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShipName.Location = new System.Drawing.Point(0, 0);
            this.panelShipName.Name = "panelShipName";
            this.panelShipName.Size = new System.Drawing.Size(485, 36);
            this.panelShipName.TabIndex = 1;
            // 
            // txtShip
            // 
            this.txtShip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtShip.Location = new System.Drawing.Point(53, 14);
            this.txtShip.Name = "txtShip";
            this.txtShip.Size = new System.Drawing.Size(432, 22);
            this.txtShip.TabIndex = 1;
            // 
            // picShip
            // 
            this.picShip.Dock = System.Windows.Forms.DockStyle.Left;
            this.picShip.Image = ((System.Drawing.Image)(resources.GetObject("picShip.Image")));
            this.picShip.Location = new System.Drawing.Point(0, 0);
            this.picShip.Name = "picShip";
            this.picShip.Size = new System.Drawing.Size(53, 36);
            this.picShip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShip.TabIndex = 0;
            this.picShip.TabStop = false;
            // 
            // picValidation
            // 
            this.picValidation.BackColor = System.Drawing.Color.Green;
            this.picValidation.Dock = System.Windows.Forms.DockStyle.Right;
            this.picValidation.Image = ((System.Drawing.Image)(resources.GetObject("picValidation.Image")));
            this.picValidation.Location = new System.Drawing.Point(485, 0);
            this.picValidation.Name = "picValidation";
            this.picValidation.Size = new System.Drawing.Size(107, 92);
            this.picValidation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picValidation.TabIndex = 0;
            this.picValidation.TabStop = false;
            // 
            // panelBeacon
            // 
            this.panelBeacon.Controls.Add(this.txtBeacon);
            this.panelBeacon.Controls.Add(this.picBeacon);
            this.panelBeacon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBeacon.Location = new System.Drawing.Point(0, 30);
            this.panelBeacon.Name = "panelBeacon";
            this.panelBeacon.Size = new System.Drawing.Size(592, 26);
            this.panelBeacon.TabIndex = 1;
            // 
            // txtBeacon
            // 
            this.txtBeacon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBeacon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeacon.Location = new System.Drawing.Point(44, 0);
            this.txtBeacon.Name = "txtBeacon";
            this.txtBeacon.Size = new System.Drawing.Size(548, 28);
            this.txtBeacon.TabIndex = 1;
            // 
            // picBeacon
            // 
            this.picBeacon.BackColor = System.Drawing.Color.Black;
            this.picBeacon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picBeacon.Image = ((System.Drawing.Image)(resources.GetObject("picBeacon.Image")));
            this.picBeacon.Location = new System.Drawing.Point(0, 0);
            this.picBeacon.Name = "picBeacon";
            this.picBeacon.Size = new System.Drawing.Size(44, 26);
            this.picBeacon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBeacon.TabIndex = 0;
            this.picBeacon.TabStop = false;
            // 
            // panelRoute
            // 
            this.panelRoute.Controls.Add(this.txtRoute);
            this.panelRoute.Controls.Add(this.picRoute);
            this.panelRoute.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRoute.Location = new System.Drawing.Point(0, 0);
            this.panelRoute.Name = "panelRoute";
            this.panelRoute.Size = new System.Drawing.Size(592, 30);
            this.panelRoute.TabIndex = 0;
            // 
            // txtRoute
            // 
            this.txtRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(44, 0);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(548, 28);
            this.txtRoute.TabIndex = 1;
            // 
            // picRoute
            // 
            this.picRoute.Dock = System.Windows.Forms.DockStyle.Left;
            this.picRoute.Image = ((System.Drawing.Image)(resources.GetObject("picRoute.Image")));
            this.picRoute.Location = new System.Drawing.Point(0, 0);
            this.picRoute.Name = "picRoute";
            this.picRoute.Size = new System.Drawing.Size(44, 30);
            this.picRoute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRoute.TabIndex = 0;
            this.picRoute.TabStop = false;
            // 
            // AccessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Enabled = false;
            this.Name = "AccessControl";
            this.Size = new System.Drawing.Size(592, 148);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panelMain.ResumeLayout(false);
            this.panelShip.ResumeLayout(false);
            this.panelShipName.ResumeLayout(false);
            this.panelShipName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picValidation)).EndInit();
            this.panelBeacon.ResumeLayout(false);
            this.panelBeacon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBeacon)).EndInit();
            this.panelRoute.ResumeLayout(false);
            this.panelRoute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelShip;
        private System.Windows.Forms.RichTextBox rtxtShip;
        private System.Windows.Forms.Panel panelShipName;
        private System.Windows.Forms.TextBox txtShip;
        private System.Windows.Forms.PictureBox picShip;
        private System.Windows.Forms.PictureBox picValidation;
        private System.Windows.Forms.Panel panelBeacon;
        private System.Windows.Forms.TextBox txtBeacon;
        private System.Windows.Forms.PictureBox picBeacon;
        private System.Windows.Forms.Panel panelRoute;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.PictureBox picRoute;
    }
}
