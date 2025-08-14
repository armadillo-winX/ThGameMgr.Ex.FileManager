using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ThGameMgr.Ex.FileManager
{
    /// <summary>
    /// FileManagerWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class FileManagerWindow : Window
    {
        public FileManagerWindow()
        {
            InitializeComponent();
        }

        private string? _gameFilePath;

        private readonly static Dictionary<string, string> _gameNameDictionary = new()
        {
            { "Th06", "東方紅魔郷" },
            { "Th07", "東方妖々夢" },
            { "Th08", "東方永夜抄" },
            { "Th09", "東方花映塚" },
            { "Th10", "東方風神録" },
            { "Th11", "東方地霊殿" },
            { "Th12", "東方星蓮船" },
            { "Th13", "東方神霊廟" },
            { "Th14", "東方輝針城" },
            { "Th15", "東方紺珠伝" },
            { "Th16", "東方天空璋" },
            { "Th17", "東方鬼形獣" },
            { "Th18", "東方虹龍洞" }
        };

        public string GameId
        {
            set
            {
                string gameName = _gameNameDictionary[value];
                this.Title = $"{gameName} - ファイルマネージャ";
            }
        }

        public string GameFilePath
        {
            get
            {
                return _gameFilePath ?? string.Empty;
            }

            set
            {
                GetFiles(value);
                _gameFilePath = value;
            }
        }

        private void GetFiles(string gameFilePath)
        {
            FilesListBox.Items.Clear();
            try
            {
                if (!string.IsNullOrEmpty(gameFilePath) && File.Exists(gameFilePath))
                {
                    string? gameDirectory = Path.GetDirectoryName(gameFilePath);
                    if (!string.IsNullOrEmpty(gameDirectory))
                    {
                        GameDirectoryPathBox.Text = gameDirectory;
                        string[] files = Directory.GetFiles(gameDirectory, "*", SearchOption.TopDirectoryOnly);
                        foreach (string file in files)
                        {
                            FilesListBox.Items.Add(Path.GetFileName(file));
                        }
                    }
                }
            }
            catch (Exception)
            {
                FilesListBox.Items.Add("エラー: ファイルの読み取りに失敗");
                FilesListBox.IsEnabled = false;
            }
        }

        private void CloseMenuItemClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AboutMenuItemClick(object sender, RoutedEventArgs e)
        {
            Program program = new();
            string pluginName = program.Name;
            string pluginVersion = program.Version;
            string pluginDeveloper = program.Developer;

            string message = $"{pluginName}\nver{pluginVersion}\nby {pluginDeveloper}";
            MessageBox.Show(this, message, "バージョン情報",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddExistedFileMenuItemClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Title = "ファイルを追加",
                Filter = "すべてのファイル|*.*",
                Multiselect = true
            };

            string? targetDirectory = Path.GetDirectoryName(this.GameFilePath);

            if (Directory.Exists(targetDirectory))
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        File.Copy(file, Path.Combine(targetDirectory, Path.GetFileName(file)), true);
                    }
                }

                GetFiles(this.GameFilePath);
            }
            else
            {
                MessageBox.Show(this, "ゲームディレクトリが見つかりません。", "エラー",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
