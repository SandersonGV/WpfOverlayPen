using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfOverlayPen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            bool podeCarregar;
            System.Threading.Mutex m = new System.Threading.Mutex(true, "WpfOverlayPen", out podeCarregar);

            if (!podeCarregar)
            {
                MessageBox.Show("Já existe uma instância em execução.");
                return;
            }

            GC.KeepAlive(m);
        }
        

    }
}
