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

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int id = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTodoButton_Click(object sender, RoutedEventArgs e)
        {
            string todoText = TodoInput.Text;
            if (!string.IsNullOrEmpty(todoText))
            {
                CheckBox todoItemCheckbox = new CheckBox { Name = $"itemCheckboxID_{id}", Margin = new Thickness(2.5) };
                TextBlock todoItemText = new TextBlock { Name = $"itemTextID_{id}", Text = $"{todoText}", TextWrapping = TextWrapping.Wrap };
                todoItemCheckbox.Checked += new RoutedEventHandler(CheckboxChecked);
                todoItemCheckbox.Unchecked += new RoutedEventHandler(CheckboxUnchecked);
                todoItemCheckbox.Content = todoItemText;
                TodoList.Children.Add(todoItemCheckbox);
                TodoInput.Clear();
                id++;
            }
        }

        private void CheckboxChecked(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            TextBlock itemText = (TextBlock)checkbox.Content;
            itemText.TextDecorations = TextDecorations.Strikethrough;
            itemText.Opacity = 0.5;
        }

        private void CheckboxUnchecked(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            TextBlock itemText = (TextBlock)checkbox.Content;
            itemText.TextDecorations = null;
            itemText.Opacity = 1;
        }
    }
}