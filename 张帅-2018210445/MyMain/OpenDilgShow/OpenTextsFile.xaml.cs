using Microsoft.Win32;using System.IO;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace OpenDilgShow
{
    /// <summary>
    /// OpenTextFileDialog.xaml 的交互逻辑
    /// </summary>
    public partial class OpenTextsFile : Window
    {
        public OpenTextsFile()
        {
            InitializeComponent();
            _Model = new Model();
            this.DataContext = _Model;
        }
        private Model _Model;

        public string FileName => _Model.FileName;
        public Encoding CurrentEncoding => _Model.CurrentEncoding;
        public bool T =true;

        private void OnLoad_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog()
            {
                Filter = "文本文件 (*.txt)|*.txt|Xml文件 (*.xml)|*.xml|所有文件 (*.*)|*.*"
            };
            if (aDlg.ShowDialog() != true) return;
            try
            {
                _Model.FileName = aDlg.FileName;
                string[] aLines = File.ReadAllLines(_Model.FileName,_Model.CurrentEncoding);
                string s = String.Join(" ", aLines);
                _Model.Preview = s;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnLoad_CanEcuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;    
        }

        private void OnSure_Executed(object sender, ExecutedRoutedEventArgs e)
        {
             T = true;
            this.Close();
        }

        private void OnSure_CanEcute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }

    class Model : INotifyPropertyChanged
    {
        public string FileName
        {
            get => _FileName;
            set { if (_FileName == value) return; _FileName = value; OnPropertyChanged(nameof(FileName)); }
        }
        private string _FileName;

        public string Preview
        {
            get => _Preview;
            set { if (_Preview == value) return; _Preview = value; OnPropertyChanged(nameof(Preview)); }
        }
        private string _Preview;

        public Encoding CurrentEncoding
        {
            get => _CurrentEncoding;
            set { if (_CurrentEncoding == value) return; _CurrentEncoding = value; OnPropertyChanged(nameof(CurrentEncoding)); }
        }
        private Encoding _CurrentEncoding=Encoding.Default;

        public Encoding[] Encodings => _Encodings;
        private static Encoding[] _Encodings = new Encoding[]
        {
            Encoding.Default, Encoding.UTF7, Encoding.UTF8, Encoding.UTF32, Encoding.ASCII, Encoding.BigEndianUnicode, Encoding.Unicode
        };
        
        private void OnPropertyChanged(string aPropertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
