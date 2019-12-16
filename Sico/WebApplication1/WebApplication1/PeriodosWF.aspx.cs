﻿using Sico.Entidades;
using Sico.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class PeriodosWF : System.Web.UI.Page
    {
        public Cliente ClienteSeleccionado { get; set; }
        public static decimal Total;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteSeleccionado = (Cliente)HttpContext.Current.Session["usuarios"];
                lblCliente.Text = ClienteSeleccionado.NombreRazonSocial;
                lblCuit.Text = ClienteSeleccionado.Cuit;
                try
                {
                    CargarCombo();
                    Total = 0;
                }
                catch (Exception ex)
                { }
            }
        }

        private void CargarCombo()
        {
            string[] Año = Sico.Clases_Maestras.ValoresConstantes.Años;
            cmbAño.Items.Add("Seleccione");
            cmbAño.Items.Clear();
            foreach (string item in Año)
            {
                cmbAño.Text = "Seleccione";
                cmbAño.Items.Add(item);
            }

            string[] Transaccion = Sico.Clases_Maestras.ValoresConstantes.Transacción;
            cmbTransacción.Items.Add("Seleccione");
            cmbTransacción.Items.Clear();
            foreach (string item in Transaccion)
            {
                cmbTransacción.Text = "Seleccione";
                cmbTransacción.Items.Add(item);
            }
        }     
        protected void gvPeriodos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                gvPeriodos.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                int idPeriodo = (int)gvPeriodos.SelectedValue;
                switch (e.CommandName)
                {
                    //case "Ver":
                    //    this.Ver(Convert.ToInt32(e.CommandArgument)); break;
                    //case "Editar":
                    //    this.Editar(Convert.ToInt32(e.CommandArgument)); break;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void gvPeriodos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvPeriodos.DataSource = this.Session["usuarios"];
                gvPeriodos.PageIndex = e.NewPageIndex;
                gvPeriodos.SelectedIndex = -1;
                gvPeriodos.DataBind(); ;
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                HabilitarCampos();
            }
            catch (Exception ex)
            { }
        }
        private void HabilitarCampos()
        {
            lblNombrePeriodo.Visible = true;
            //lblAñoNuevo.Visible = true;
            cmbAño.Visible = true;
            txtNombrePeriodo.Visible = true;
            txtNombrePeriodo.Focus();
        }
        private void LimpiarCamposCarga()
        {
            CargarCombo();
            txtNombrePeriodo.Text = null;
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarCamposCarga();
            }
            catch (Exception ex)
            { }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cuit = ClienteSeleccionado.Cuit;
                string Año = cmbAño.Text;
                string nombre = txtNombrePeriodo.Text;
                bool Exito = PeriodoNeg.GuardarPeriodoVenta(cuit, nombre, Año);
                if (Exito == true)
                {
                    const string message2 = "Se registro el período exitosamente.";
                    const string caption2 = "Éxito";
                    var result2 = MessageBox.Show(message2, caption2,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Asterisk);
                    LimpiarCamposCarga();
                }
                else
                {

                }
            }
            catch (Exception ex)
            { }
        }
    }
}