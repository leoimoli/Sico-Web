using Sico.Entidades;
using Sico.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FacturaBWF : System.Web.UI.Page
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
                    CargarComboPersonas();
                    CargarCombo();
                    string NroFactura = ClienteNeg.BuscarNroFactura(ClienteSeleccionado.Cuit);
                    txtFactura.Text = NroFactura;
                    Total = 0;
                    cmbTipoMoneda.Text = "PES - PesosArgentinos";
                    cmbCodigoOperacion.Text = "0 - NO CORRESPONDE";
                    cmbTipoComprobante.Text = "006 - FACTURAS B";
                    txtTipoCambio.Text = "1,000000";
                }
                catch (Exception ex)
                { }
            }
        }

        private void CargarCombo()
        {
            List<string> TipoComprobante = new List<string>();
            TipoComprobante = ComprasNeg.CargarComboTipoComprobante();
            cmbTipoComprobante.Items.Clear();
            ListItem item = new ListItem("Seleccione", "0");
            cmbTipoComprobante.Items.Add(item);
            foreach (var tipo in TipoComprobante)
            {
                item = new ListItem(tipo);
                cmbTipoComprobante.Items.Add(item);
            }


            List<string> CodigoOperacion = new List<string>();
            CodigoOperacion = ComprasNeg.CargarComboCodigoOperacion();
            cmbCodigoOperacion.Items.Clear();
            ListItem item2 = new ListItem("Seleccione", "0");
            cmbCodigoOperacion.Items.Add(item2);
            foreach (var codigo in CodigoOperacion)
            {
                item = new ListItem(codigo);
                cmbCodigoOperacion.Items.Add(item2);
            }
            List<string> TipoMoneda = new List<string>();
            TipoMoneda = ComprasNeg.CargarComboTipoMoneda();
            cmbTipoMoneda.Items.Clear();
            ListItem item3 = new ListItem("Seleccione", "0");
            cmbTipoMoneda.Items.Add(item3);
            foreach (var TipoMon in TipoMoneda)
            {
                item = new ListItem(TipoMon);
                cmbTipoMoneda.Items.Add(item3);
            }


            List<string> Periodo = new List<string>();
            Periodo = PeriodoNeg.CargarComboPeriodoVenta(ClienteSeleccionado.Cuit);
            cmbPeriodo.Items.Clear();
            ListItem item4 = new ListItem("Seleccione", "0");
            cmbPeriodo.Items.Add(item4);
            foreach (var per in Periodo)
            {
                item = new ListItem(per);
                cmbPeriodo.Items.Add(item4);
            }
        }
        private void CargarComboPersonas()
        {
            List<string> Personas = new List<string>();
            Personas = ClienteNeg.CargarComboPersonas(ClienteSeleccionado.Cuit);
            cmbPersona.Items.Clear();
            ListItem item = new ListItem("Seleccione", "0");
            cmbTipoComprobante.Items.Add(item);
            foreach (var tipo in Personas)
            {
                item = new ListItem(tipo);
                cmbPersona.Items.Add(item);
            }
        }
    }
}