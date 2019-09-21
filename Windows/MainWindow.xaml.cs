using ProjectAtleti.Objects;
using ProjectAtleti.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjectAtleti
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string m_FilterText;
        public event PropertyChangedEventHandler PropertyChanged;
        public string FilterText
        {
            get { return m_FilterText; }
            set
            {
                m_FilterText = value;
                NotifyPropertyChanged(nameof(FilterText));
            }
        }
        protected void NotifyPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AtletiListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.FilterText = string.Empty;
            this.RefreshList();
        }
        private void RefreshList()
        {
            using (new WaitCursor())
            {
                ObservableCollection<AtletaEntity> listaAtleti = new ObservableCollection<AtletaEntity>(new AtletaService().GetAll());
                this.lvAtleti.ItemsSource = listaAtleti;
            }
        }
        internal void ModifyAtleta()
        {
            var selectedItem = this.lvAtleti.SelectedItem;

            if(selectedItem != null)
            {
                this.AddAtletaButton.Visibility = this.DeleteAtletaButton.Visibility = this.ModifyAtletaButton.Visibility = this.ListViewTabItem.Visibility = this.FilterTextBox.Visibility = this.FiltroLabel.Visibility = Visibility.Collapsed;
                this.CloseButton.Visibility = this.SaveButton.Visibility = this.atletaUserControl.Visibility = Visibility.Visible;

                this.AtletaTabItem.IsSelected = true;
                this.TabControl.UpdateLayout();
                this.atletaUserControl.DataContext = selectedItem as AtletaEntity;
            }
        }
        internal void DeleteAtleta()
        {
            var selectedItem = this.lvAtleti.SelectedItem;

            if (selectedItem != null)
            {
                if (new AtletaService().Delete(selectedItem as AtletaEntity) == 0)
                {
                    MessageBox.Show("Cancellato");
                    this.RefreshList();
                }
                else
                    MessageBox.Show("Errore verificatosi durante la cancellazione!");

            }
        }
        internal void AddAtleta()
        {
            this.AddAtletaButton.Visibility = this.DeleteAtletaButton.Visibility = this.ModifyAtletaButton.Visibility = this.ListViewTabItem.Visibility = this.FilterTextBox.Visibility = this.FiltroLabel.Visibility = Visibility.Collapsed;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.atletaUserControl.Visibility = Visibility.Visible;

            this.AtletaTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            atletaUserControl.DataContext = new AtletaEntity();
        }
        internal void Save()
        {
            this.atletaUserControl.Save();
        }
        internal void CloseUC()
        {
            this.AddAtletaButton.Visibility = this.DeleteAtletaButton.Visibility = this.ModifyAtletaButton.Visibility = this.ListViewTabItem.Visibility = this.FilterTextBox.Visibility = this.FiltroLabel.Visibility = Visibility.Visible;
            this.CloseButton.Visibility = this.SaveButton.Visibility = this.atletaUserControl.Visibility = Visibility.Collapsed;

            this.ListViewTabItem.IsSelected = true;
            this.TabControl.UpdateLayout();

            atletaUserControl.DataContext = new AtletaEntity();
            RefreshList();
        }
    }
}
