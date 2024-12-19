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
using System.Windows.Shapes;
using System.Globalization;

namespace GiftNotation.Views
{
    /// <summary>
    /// Логика взаимодействия для AddGifts.xaml
    /// </summary>
    public partial class AddGifts : Window
    {
        public AddGifts()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void RichTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as RichTextBox;
            if (textBox != null)
            {
                //string text = textBox.Selection.Text;
                //if (Uri.IsWellFormedUriString * text, UriKind.Absolute))
                //{
                //    //Преобразование текста в ссылку
                //    var hyperlink = new Hyperlink(new Run(text))
                //    {
                //        NavigateUri = new Uri(text);
                //    };

                //    textBox.Document.Blocks.Clear();
                //    textBox.Document.Blocks.Add(new Paragraph(hyperlink));
                //}


            }
        }

        private void RichTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = string.Empty;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }

}
   

