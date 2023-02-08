using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace InviUpdate
{
    public partial class MainWindow : Window
    {
        public Visibility UpdateEnd;
        public string UpdateStep;
        private Thread _updateThread;
        public MainWindow()
        {
            InitializeComponent();
            UpdateEnd = Visibility.Hidden;
            _updateThread = new Thread(() => Update());
            _updateThread.Start();
        }
        public void Update()
        {
            UpdateStep = "Проверка версии";
            var lastVersion = Utils.UpdaterUtility.GetLastBuilds();
            if(lastVersion == null)
                AbortUpdater();

            UpdateStep = "Загрузка версии";
            Utils.UpdaterUtility.DownloadLastVersion(lastVersion);
            UpdateStep = "Распаковака архива";
            Utils.UpdaterUtility.ZipExtract(lastVersion);
            UpdateStep = "Замена файлов";
            Utils.UpdaterUtility.MoveFiles();
            UpdateStep = "Удаление временных файлов";
            Utils.UpdaterUtility.RemoverBuferFies();
            UpdateEnd = Visibility.Visible;
            UpdateStep = "Готово";
            AbortUpdater();
        }
        private void AbortUpdater() 
        {
            var mainDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            var mainFiles = mainDir.GetFiles().ToList();
            var mainApp = mainFiles.SingleOrDefault(f => f.Name == "Invi.exe");
            if(mainApp != null)
            if (mainApp.Exists) 
            {
                Process.Start(mainApp.FullName);
                Application.Current.Shutdown();
            }
            else UpdateStep = "Исполняемый файл не найден";
        }
    }
}
