using Sico.Entidades;
using Sico.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
//using System.Windows.Forms;

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
                    //cmbTipoMoneda.Text = "PES - PesosArgentinos";
                    //cmbCodigoOperacion.Text = "0 - NO CORRESPONDE";
                    //cmbTipoComprobante.Text = "006 - FACTURAS B";
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
            ListItem item = new ListItem("006 - FACTURAS B", "0");
            cmbTipoComprobante.Items.Add(item);
            foreach (var tipo in TipoComprobante)
            {
                item = new ListItem(tipo);
                cmbTipoComprobante.Items.Add(item);
            }


            List<string> CodigoOperacion = new List<string>();
            CodigoOperacion = ComprasNeg.CargarComboCodigoOperacion();
            cmbCodigoOperacion.Items.Clear();
            ListItem item2 = new ListItem("0 - NO CORRESPONDE", "0");
            cmbCodigoOperacion.Items.Add(item2);
            foreach (var codigo in CodigoOperacion)
            {
                item = new ListItem(codigo);
                cmbCodigoOperacion.Items.Add(item2);
            }
            List<string> TipoMoneda = new List<string>();
            TipoMoneda = ComprasNeg.CargarComboTipoMoneda();
            cmbTipoMoneda.Items.Clear();
            ListItem item3 = new ListItem("PES - PesosArgentinos", "0");
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
            cmbPersonas.Items.Clear();
            ListItem item = new ListItem("Seleccione", "0");
            cmbTipoComprobante.Items.Add(item);
            foreach (var tipo in Personas)
            {
                item = new ListItem(tipo);
                cmbPersonas.Items.Add(item);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Sico.Entidades.SubCliente _subCliente = CargarEntidad();
                bool Exito = ClienteNeg.GuardarFacturaSubCliente(_subCliente, ClienteSeleccionado.Cuit);
                if (Exito == true)
                {
                    const string message2 = "Se registro la factura exitosamente.";
                    const string caption2 = "Éxito";
                    LimpiarCampos();
                }
                else
                {

                }
            }
            catch (Exception ex) { }
        }
        private SubCliente CargarEntidad()
        {
            SubCliente _subCliente = new SubCliente();
            _subCliente.ApellidoNombre = cmbPersonas.Text;
            string factura = txtFactura.Text;
            ///// Primera parte del numero
            var split1 = factura.Split('-')[0];
            split1 = split1.Trim();
            ///// Segunda parte del numero
            var split2 = factura.Split('-')[1];
            split2 = split2.Trim();

            if (split1.Length < 5)
            {
                split1 = split1.PadLeft(5, '0');
            }
            if (split2.Length < 8)
            {
                split2 = split2.PadLeft(8, '0');
            }
            string nroFactura = string.Concat(split1, "-", split2);
            _subCliente.NroFactura = nroFactura;
            DateTime fecha = Convert.ToDateTime(dtFecha.Text);
            _subCliente.Fecha = fecha.ToShortDateString();
            if (!String.IsNullOrEmpty(txtTotal1.Text))
                _subCliente.Total1 = Convert.ToDecimal(txtTotal1.Text);
            if (!String.IsNullOrEmpty(txtTotal2.Text))
                _subCliente.Total2 = Convert.ToDecimal(txtTotal2.Text);
            if (!String.IsNullOrEmpty(txtTotal3.Text))
                _subCliente.Total3 = Convert.ToDecimal(txtTotal3.Text);
            if (!String.IsNullOrEmpty(txtNeto1.Text))
                _subCliente.Neto1 = Convert.ToDecimal(txtNeto1.Text);
            if (!String.IsNullOrEmpty(txtNeto2.Text))
                _subCliente.Neto2 = Convert.ToDecimal(txtNeto2.Text);
            if (!String.IsNullOrEmpty(txtNeto3.Text))
                _subCliente.Neto3 = Convert.ToDecimal(txtNeto3.Text);
            _subCliente.Alicuota1 = lbl105.Text;
            _subCliente.Alicuota2 = lbl21.Text;
            _subCliente.Alicuota3 = lbl27.Text;
            if (!String.IsNullOrEmpty(txtIva1.Text))
                _subCliente.Iva1 = Convert.ToDecimal(txtIva1.Text);
            if (!String.IsNullOrEmpty(txtIva2.Text))
                _subCliente.Iva2 = Convert.ToDecimal(txtIva2.Text);
            if (!String.IsNullOrEmpty(txtIva3.Text))
                _subCliente.Iva3 = Convert.ToDecimal(txtIva3.Text);
            _subCliente.Monto = Convert.ToDecimal(txtTotal.Text);
            _subCliente.TipoComprobante = cmbTipoComprobante.Text;
            _subCliente.CodigoMoneda = cmbTipoMoneda.Text;
            _subCliente.TipoDeCambio = txtTipoCambio.Text;
            _subCliente.CodigoTipoOperacion = cmbCodigoOperacion.Text;
            _subCliente.Adjunto = txtAdjuntar.Text;
            _subCliente.Periodo = cmbPeriodo.Text;
            return _subCliente;
        }
        private void LimpiarCampos()
        {
            txtTotal1.Text = null;
            txtTotal2.Text = null;
            txtTotal3.Text = null;
            txtNeto1.Text = null;
            txtNeto2.Text = null;
            txtNeto3.Text = null;
            txtIva1.Text = null;
            txtIva2.Text = null;
            txtIva3.Text = null;
            txtTotal.Text = "-";
            Total = 0;
            txtAdjuntar.Text = null;
            CalcularProximoNumeroBoleta();
        }
        private void CalcularProximoNumeroBoleta()
        {
            string FacturaVieja = txtFactura.Text;
            ///// Primera parte del numero
            var split1 = FacturaVieja.Split('-')[0];
            split1 = split1.Trim();
            ///// Segunda parte del numero
            var split2 = FacturaVieja.Split('-')[1];
            split2 = split2.Trim();
            string prueba = string.Concat(split1, split2);
            int Numero = Convert.ToInt32(prueba);
            int Fac = Numero + 1;
            string prueba2 = Convert.ToString(Fac);
            txtFactura.Text = string.Concat("0000", prueba2);
        }
        public void RecalcularTotal1()
        {
            decimal Valor2 = 0;
            decimal Valor3 = 0;
            decimal NuevoValor = Convert.ToDecimal(txtTotal1.Text);

            if (txtTotal2.Text != "") { Valor2 = Convert.ToDecimal(txtTotal2.Text); }
            if (txtTotal3.Text != "") { Valor3 = Convert.ToDecimal(txtTotal3.Text); }

            Total = NuevoValor + Valor2 + Valor3;
        }
        public void RecalcularTotal2()
        {
            decimal Valor1 = 0;
            decimal Valor3 = 0;
            decimal NuevoValor2 = Convert.ToDecimal(txtTotal2.Text);

            if (txtTotal1.Text != "") { Valor1 = Convert.ToDecimal(txtTotal1.Text); }
            if (txtTotal3.Text != "") { Valor3 = Convert.ToDecimal(txtTotal3.Text); }

            Total = NuevoValor2 + Valor1 + Valor3;
        }
        public void RecalcularTotal3()
        {
            decimal Valor2 = 0;
            decimal Valor1 = 0;
            decimal NuevoValor3 = Convert.ToDecimal(txtTotal3.Text);

            if (txtTotal2.Text != "") { Valor2 = Convert.ToDecimal(txtTotal2.Text); }
            if (txtTotal1.Text != "") { Valor1 = Convert.ToDecimal(txtTotal1.Text); }

            Total = NuevoValor3 + Valor2 + Valor1;
        }
        protected void txtTotal1_TextChanged(object sender, EventArgs e)
        {
            ///// Calculo el NetoGral Alicuota 10,5
            double Total1 = Convert.ToDouble(txtTotal1.Text);
            decimal NetoCalculado = CalcularValorNeto1(Total1);
            txtNeto1.Text = Convert.ToString(NetoCalculado);

            ///// Calculo el IVA Alicuota 10,5
            decimal IvaCalculado = CalcularIva1(NetoCalculado);
            txtIva1.Text = Convert.ToString(IvaCalculado);

            ///// Calculo el Monto Total
            if (Total == 0)
            {
                txtTotal.Text = Convert.ToString(Total1);
                decimal TotalCargado = Convert.ToDecimal(Total1);
                Total = TotalCargado;
            }
            else
            {
                RecalcularTotal1();
                txtTotal.Text = Convert.ToString(Total);
            }
            txtTotal2.Focus();

        }
        protected void txtTotal2_TextChanged(object sender, EventArgs e)
        {

            ///// Calculo el NetoGral Alicuota 21
            double Total2 = Convert.ToDouble(txtTotal2.Text);
            decimal NetoCalculado = CalcularValorNeto2(Total2);
            txtNeto2.Text = Convert.ToString(NetoCalculado);

            ///// Calculo el IVA Alicuota 21
            decimal IvaCalculado = CalcularIva2(NetoCalculado);
            txtIva2.Text = Convert.ToString(IvaCalculado);

            ///// Calculo el Monto Total
            if (Total == 0)
            {
                txtTotal.Text = Convert.ToString(Total2);
                decimal TotalCargado = Convert.ToDecimal(Total2);
                Total = TotalCargado;
            }
            else
            {
                RecalcularTotal2();
                txtTotal.Text = Convert.ToString(Total);
                //decimal TotalCargado = Convert.ToDecimal(Total2);
                //decimal TotalMostrar = Total + TotalCargado;
                //Total = TotalMostrar;
                //lblTotalEdit.Text = Convert.ToString(TotalMostrar);
            }
            txtTotal3.Focus();

        }
        protected void txtTotal3_TextChanged(object sender, EventArgs e)
        {                            ///// Calculo el NetoGral Alicuota 27
            double Total3 = Convert.ToDouble(txtTotal3.Text);
            decimal NetoCalculado = CalcularValorNeto3(Total3);
            txtNeto3.Text = Convert.ToString(NetoCalculado);

            ///// Calculo el IVA Alicuota 27
            decimal IvaCalculado = CalcularIva3(NetoCalculado);
            txtIva3.Text = Convert.ToString(IvaCalculado);

            ///// Calculo el Monto Total
            if (Total == 0)
            {
                txtTotal.Text = Convert.ToString(Total3);
                decimal TotalCargado = Convert.ToDecimal(Total3);
                Total = TotalCargado;
            }
            else
            {
                RecalcularTotal3();
                txtTotal.Text = Convert.ToString(Total);
            }

        }
        private decimal CalcularValorNeto1(double total1)
        {
            string res = Convert.ToString(Math.Round((total1 / 1.105), 2));
            decimal resultado = Convert.ToDecimal(res);
            return resultado;
        }
        private decimal CalcularIva1(decimal netoCalculado)
        {
            double NetoCalculado = Convert.ToDouble(netoCalculado);
            string res = Convert.ToString(Math.Round((NetoCalculado * 0.105), 2));
            decimal resultado = Convert.ToDecimal(res);
            return resultado;
        }
        private decimal CalcularValorNeto2(double total2)
        {
            string res = Convert.ToString(Math.Round((total2 / 1.21), 2));
            decimal resultado = Convert.ToDecimal(res);
            return resultado;
        }
        private decimal CalcularIva2(decimal netoCalculado)
        {
            double NetoCalculado = Convert.ToDouble(netoCalculado);
            string res = Convert.ToString(Math.Round((NetoCalculado * 0.21), 2));
            decimal resultado = Convert.ToDecimal(res);
            return resultado;
        }
        private decimal CalcularValorNeto3(double total3)
        {
            string res = Convert.ToString(Math.Round((total3 / 1.27), 2));
            decimal resultado = Convert.ToDecimal(res);
            return resultado;
        }
        private decimal CalcularIva3(decimal netoCalculado)
        {
            double NetoCalculado = Convert.ToDouble(netoCalculado);
            string res = Convert.ToString(Math.Round((NetoCalculado * 0.27), 2));
            decimal resultado = Convert.ToDecimal(res);
            return resultado;
        }
        protected void cmbPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClienteSeleccionado = (Cliente)HttpContext.Current.Session["usuarios"];
                string cuit = ClienteSeleccionado.Cuit;
                string persona = cmbPersonas.Text;
                string NuevoNroFactura = ClienteNeg.BuscarNroFactura(cuit);
                txtFactura.Text = NuevoNroFactura;
                dtFecha.Enabled = true;
                string apellidoNombre = cmbPersonas.Text;
                List<SubCliente> DatosPersonales = ClienteNeg.BuscarDatosSubClientePorApellidoNombre(apellidoNombre, cuit);
                if (DatosPersonales.Count > 0)
                {
                    //HabilitarLabels();
                    var datos = DatosPersonales.First();
                    if (String.IsNullOrEmpty(datos.Dni))
                    { lblDniEdit.Text = "No informa"; }
                    else { lblDniEdit.Text = datos.Dni; }

                    if (String.IsNullOrEmpty(datos.Direccion))
                    { lblDireccionEdit.Text = "No informa"; }
                    else { lblDireccionEdit.Text = datos.Direccion; }

                    if (String.IsNullOrEmpty(datos.Observacion))
                    { lblObservacionesEdit.Text = "No informa"; }
                    else { lblObservacionesEdit.Text = datos.Observacion; }
                }
            }
            catch (Exception ex)
            { }
        }
    }
}