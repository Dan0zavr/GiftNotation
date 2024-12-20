using GiftNotation.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

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
                //string text = textBox.selection.text;
                //if (Url.iswellformeduristring * text, urikind.absolute))
                //{
                //    //преобразование текста в ссылку
                //    var hyperlink = new hyperlink(new run(text))
                //    {
                //        navigateuri = new uri(text);
                //    };

                //    textBox.document.blocks.clear();
                //    textBox.document.blocks.add(new paragraph(hyperlink));
                //}


            }
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is RichTextBox richTextBox)
            {
                TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                string text = textRange.Text.Trim();

                // Обновляем привязанное свойство Uri
                var viewModel = DataContext as AddGiftViewModel;
                if (viewModel != null)
                {
                    viewModel.Url = text;
                }
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


