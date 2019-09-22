using ProjectAtleti.Objects;
using ProjectAtleti.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectAtleti.UserControls
{
    /// <summary>
    /// Logica di interazione per AtletaUserControl.xaml
    /// </summary>
    public partial class AtletaUserControl : UserControl
    {
        public AtletaUserControl()
        {
            InitializeComponent();
        }

        internal void Save()
        {
            AtletaEntity atleta = this.DataContext as AtletaEntity;
            int result = 0;

            if(CanSave())
            {
                if (atleta.AtletaId == -1)
                    result = new AtletaService().Add(atleta);
                else result = new AtletaService().Update(atleta);

                if (result == 0)
                    MessageBox.Show("Atleta Salvato!");
                else MessageBox.Show("Errore duante il salvataggio!");
            }

            
        }

        private bool CanSave()
        {
            AtletaEntity atleta = this.DataContext as AtletaEntity;

            if(string.IsNullOrEmpty(atleta.FiscalCode))
            {
                MessageBox.Show("Inserisci il Codice Fiscale!");
                return false;
            }

            if (string.IsNullOrEmpty(atleta.Name))
            {
                MessageBox.Show("Inserisci il Nome!");
                return false;
            }

            if (string.IsNullOrEmpty(atleta.Surname))
            {
                MessageBox.Show("Inserisci il Cognome!");
                return false;
            }

            return true;
        }

        private void AtletaUC_Loaded(object sender, RoutedEventArgs e)
        {
            var dict = new Dictionary<char, string>();
            dict.Add('M', "Uomo");
            dict.Add('F', "Donna");
            dict.Add('N', "Non definito");

            SexChooserComboBox.ItemsSource = dict;
        }
    }
}
