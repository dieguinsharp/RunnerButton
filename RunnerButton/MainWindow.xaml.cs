using System;
using System.Collections.Generic;
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

namespace RunnerButton {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window {
        public MainWindow () {
            InitializeComponent();
            SetNewColumnPosition();
        }

        private int minLetters = 5;

        private int CurrentIndex = 0;
        private int LastIndex = 1;

        private void btnSendMessage_MouseMove (object sender,MouseEventArgs e) {
            if(txtMessage.Text.Length < minLetters) {
                SetNewColumnPosition();
            }
        }

        private void SetNewColumnPosition () {
            btnSendMessage.SetValue(Grid.ColumnProperty, GenerateNewGridColumnIndex());
        }

        private int GenerateNewGridColumnIndex () {
            int newIndex = 0;

            if(CurrentIndex == 0 && LastIndex == 1) {
                newIndex = 1;
            }

            if(CurrentIndex == 1 && LastIndex == 2) {
                newIndex = 0;
            }

            if(CurrentIndex == 1 && LastIndex == 0) {
                newIndex = 2;
            }

            if(CurrentIndex == 2 && LastIndex == 1) {
                newIndex = 1;
            }

            LastIndex = CurrentIndex;
            CurrentIndex = newIndex;

            return newIndex;
        }

        private void txtMessage_TextChanged (object sender,TextChangedEventArgs e) {

            LastIndex = 1;
            CurrentIndex = 0;

            if(txtMessage.Text.Length >= minLetters) {
                SetNewColumnPosition();
            }
        }
    }
}
