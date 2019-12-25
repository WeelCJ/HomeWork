using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;

using OpenDilgShow;

namespace WpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            _Model = new RegexApp();
            this.DataContext = _Model;
        }
        private RegexApp _Model;
         

        private void OnLoad_EmailExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenTextsFile aDlg = new OpenTextsFile();
            if (aDlg.ShowDialog() == true) return;
            try
            {
                _Model.Load(aDlg.FileName, aDlg.CurrentEncoding);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OnLoad_EmailCanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnLoad_ImageExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            
            OpenFileDialog aDlg = new OpenFileDialog()
            {
                Filter = "Png (*.png)|*.png|Jpg (*.jpg)|*.jpg|所有文件 (*.*)|*.*"
            };
            if (aDlg.ShowDialog() != true) return;
            try
            {      
                _Model.Image_Dir = aDlg.FileName;
                //MessageBox.Show(aDlg.FileName);//
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OnLoad_ImagexCanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnSure_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("成功导入..");
        }

        private void OnSure_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                e.CanExecute = _Model != null &&_Model.IsSure ;
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void OnQuit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void OnQuit_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnMyLoad_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _Model.MyLoad();
        }

        private void OnMyLoad_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
