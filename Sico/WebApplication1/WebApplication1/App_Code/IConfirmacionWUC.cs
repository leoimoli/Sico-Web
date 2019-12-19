using System;
using System.ComponentModel;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.UI;
namespace Sinai.Presenters.ViewInterfaces
{
    public interface IConfirmacionWUC
    {
        string TargetControlID { set; }
        string Mensaje { set; }
        bool Enabled { set; }
        //bool Invertir { set; }
        bool Visible { set; }
        bool Valor { get; }
    }
}
