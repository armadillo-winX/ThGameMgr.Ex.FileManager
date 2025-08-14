using System.Windows;

namespace ThGameMgr.Ex.FileManager
{
    /// <summary>
    /// NewFileDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class NewFileDialog : Window
    {
        public NewFileDialog()
        {
            InitializeComponent();
        }

        public string? NewFileName { get; set; }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            if (NewFileNameBox.Text.Length > 0)
            {
                this.NewFileName = NewFileNameBox.Text;
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show(this, "ファイル名を入力してください。", "新規ファイルの追加",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
