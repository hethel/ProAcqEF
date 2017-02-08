using System.Windows;
using System.Data.Entity;


namespace ProAcqEF
{
    /// <summary>
    /// Interaktionslogik für ProcessDataView.xaml
    /// </summary>
    public partial class ProcessDataView : Window
    {

        private ProAcqModel _context = new ProAcqModel();

        public ProcessDataView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pD_EntityViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pD_EntityViewSource")));
            // Laden Sie Daten durch Festlegen der CollectionViewSource.Source-Eigenschaft:
            // pD_EntityViewSource.Source = [generische Datenquelle]
        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this._context.Dispose();
        }

        private void pD_EntityDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource pD_EntityViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pD_EntityViewSource")));

            _context.PD_Entities.Load();
            pD_EntityViewSource.Source = _context.PD_Entities.Local;

            pD_EntityDataGrid.Items.Refresh();

        }
    }
}
