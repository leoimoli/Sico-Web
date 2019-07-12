using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sico.Entidades;
using System.Windows.Forms;
using Sico.Dao;

namespace Sico.Negocio
{
    public class PericiaNeg
    {
        public static bool GurdarPericia(Pericias _pericia)
        {
            bool exito = false;
            try
            {
                ValidarDatos(_pericia);
                bool PericiaExistente = ValidarPericiaExistente(_pericia.Tribunal, _pericia.Causa);

                if (PericiaExistente == true)
                {
                    const string message = "Ya existe una pericia registrada con el mismo nombre de causa y tribunal asociado.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    _pericia.Estado = "Iniciada";
                    exito = PericiaDao.InsertPericia(_pericia);
                }
            }
            catch (Exception ex)
            {

            }
            return exito;
        }

        public static List<Pericias> BuscarHistorialPericia(object idPericia)
        {
            int idPer = Convert.ToInt32(idPericia);
            List<Pericias> _listaPericias = new List<Pericias>();
            try
            {
                _listaPericias = PericiaDao.BuscarHistorialPericia(idPer);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaPericias;
        }

        private static bool ValidarPericiaExistente(string tribunal, string causa)
        {
            bool existe = PericiaDao.ValidarPericiaExistente(tribunal, causa);
            return existe;
        }
        private static void ValidarDatos(Pericias _pericia)
        {
            if (String.IsNullOrEmpty(_pericia.Tribunal) || _pericia.Tribunal == "Seleccione")
            {
                const string message = "El campo Tribunal es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_pericia.NroCausa))
            {
                const string message = "El campo Nro.Causa es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_pericia.Causa))
            {
                const string message = "El campo Causa es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (_pericia.Compartido == 1)
            {
                if (String.IsNullOrEmpty(_pericia.Email))
                {
                    const string message = "El campo Email es obligatorio.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
            }

        }
        public static List<Pericias> BuscarPericiasPorTribunal(string tribunal)
        {
            List<Pericias> _listaPericias = new List<Pericias>();
            try
            {
                _listaPericias = PericiaDao.BuscarPericiasPorTribunal(tribunal);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaPericias;
        }

        public static List<Pericias> BuscarPericiasPorCausa(string causa)
        {
            List<Pericias> _listaPericias = new List<Pericias>();
            try
            {
                _listaPericias = PericiaDao.BuscarPericiasPorCausa(causa);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaPericias;
        }
        public static bool GurdarHistorialPericia(Pericias _pericia)
        {
            bool exito = false;
            try
            {
                ValidarDatosHistorialPericia(_pericia);
                exito = PericiaDao.InsertHistorialPericia(_pericia);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }

        private static void ValidarDatosHistorialPericia(Pericias _pericia)
        {
            if (_pericia.Estado == "Seleccione")
            {
                const string message = "El campo Estado es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (_pericia.Fecha > DateTime.Now)
            {
                const string message = "La fecha no puede ser mayor a la fecha actual.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }
    }
}
