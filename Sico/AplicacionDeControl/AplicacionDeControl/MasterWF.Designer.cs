namespace AplicacionDeControl
{
    partial class MasterWF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterWF));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.personalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organigramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalToolStripMenuItem,
            this.configuracionesToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // personalToolStripMenuItem
            // 
            this.personalToolStripMenuItem.Image = global::AplicacionDeControl.Properties.Resources.grupo_de_usuarios;
            this.personalToolStripMenuItem.Name = "personalToolStripMenuItem";
            this.personalToolStripMenuItem.Size = new System.Drawing.Size(98, 25);
            this.personalToolStripMenuItem.Text = "Personal";
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardiasToolStripMenuItem,
            this.licenciasToolStripMenuItem,
            this.organigramaToolStripMenuItem});
            this.configuracionesToolStripMenuItem.Image = global::AplicacionDeControl.Properties.Resources.configuraciones_1_;
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(151, 25);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // guardiasToolStripMenuItem
            // 
            this.guardiasToolStripMenuItem.Name = "guardiasToolStripMenuItem";
            this.guardiasToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.guardiasToolStripMenuItem.Text = "Guardias";
            // 
            // licenciasToolStripMenuItem
            // 
            this.licenciasToolStripMenuItem.Name = "licenciasToolStripMenuItem";
            this.licenciasToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.licenciasToolStripMenuItem.Text = "Licencias";
            // 
            // organigramaToolStripMenuItem
            // 
            this.organigramaToolStripMenuItem.Name = "organigramaToolStripMenuItem";
            this.organigramaToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.organigramaToolStripMenuItem.Text = "Organigrama";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Image = global::AplicacionDeControl.Properties.Resources.resultar;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(100, 25);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Image = global::AplicacionDeControl.Properties.Resources.relacion_de_usuarios;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(99, 25);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::AplicacionDeControl.Properties.Resources.logout_2_;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(69, 25);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // MasterWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 743);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MasterWF";
            this.Text = "Administrador de Personal";
            this.Load += new System.EventHandler(this.MasterWF_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem personalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organigramaToolStripMenuItem;
    }
}