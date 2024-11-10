using System.Windows;
using ThGameMgr.Ex.Plugin;

namespace ThGameMgr.Ex.FileManager
{
    public partial class Program : SelectedGamePluginBase
    {
        public override string Name => "東方管制塔 EX ファイルマネージャ";

        public override string Version => "1.0";

        public override string Developer => "珠音茉白/東方管制塔開発部";

        public override string Description => "ゲームのインストールフォルダ内のファイルを管理します。";

        public override string CommandName => "ファイルマネージャ";

        public Window? MainWindow { get; set; }

        public override void Main(string gameId, string gameFile)
        {
            FileManagerWindow fileManagerWindow = new()
            {
                GameId = gameId,
                GameFilePath = gameFile
            };

            if (this.MainWindow != null) fileManagerWindow.Owner = this.MainWindow;

            fileManagerWindow.ShowDialog();
        }
    }
}
