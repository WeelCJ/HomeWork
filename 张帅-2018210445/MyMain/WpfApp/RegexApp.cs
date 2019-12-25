using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows;
using OpenDilgShow;
using System.Text;

namespace WpfApp
{
    class RegexApp : INotifyPropertyChanged
    {
        public void Load(string aFileName,Encoding en)
        {
            string aLines = File.ReadAllText(aFileName, en);
            string s = String.Join(" ", aLines);
            Email_Texts = aLines;
            Email_Dir = aFileName;
        }
        public void MyLoad()
        {
            if (!string.IsNullOrWhiteSpace(Email_Dir))
            {
                string aLines = File.ReadAllText(Email_Dir);
                Email_Texts = aLines;
            }
            else
            {
                MessageBox.Show("地址不能为空");
            }
        }
        public string Email_Texts{get { return _Email_Texts; }set{ if (_Email_Texts == value) return; _Email_Texts = value; OnPropertyChanged(nameof(Email_Texts));}}
        private string _Email_Texts;

        public string Image_Dir { get { return _Image_Dir; } set { if (_Image_Dir == value) return; _Image_Dir = value; OnPropertyChanged(nameof(Image_Dir)); } }
        private string _Image_Dir;

        public string Email_Dir { get { return _Email_Dir; } set { if (_Email_Dir == value) return; _Email_Dir = value; OnPropertyChanged(nameof(Email_Dir)); } }
        private string _Email_Dir;

        public bool IsSure => !string.IsNullOrWhiteSpace(Email_Texts)&& !string.IsNullOrWhiteSpace(Image_Dir);
       //ublic bool AgainFilter {get { return !string.IsNullOrWhiteSpace(Pattern)&& !string.IsNullOrWhiteSpace(Pattern_again)&& !string.IsNullOrWhiteSpace(SourceTexts);}}//
        

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}



