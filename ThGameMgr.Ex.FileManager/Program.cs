using System.Windows;
using ThGameMgr.Ex.Plugin;

namespace ThGameMgr.Ex.FileManager
{
    public partial class Program : SelectedGamePluginBase
    {
        public override string Name => "�����ǐ��� EX �t�@�C���}�l�[�W��";

        public override string Version => "1.0";

        public override string Developer => "�쉹䝔�/�����ǐ����J����";

        public override string Description => "�Q�[���̃C���X�g�[���t�H���_���̃t�@�C�����Ǘ����܂��B";

        public override string CommandName => "�t�@�C���}�l�[�W��";

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
