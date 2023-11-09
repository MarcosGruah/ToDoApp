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
                CheckBox todoItemCheckbox = new CheckBox { Name = $"itemCheckboxID_{id}", Margin = new Thickness(2.5), VerticalAlignment = VerticalAlignment.Center };
                TextBlock todoItemText = new TextBlock { Name = $"itemTextID_{id}", Text = $"{todoText}", TextWrapping = TextWrapping.Wrap };

                Button todoItemRemove = new Button
                {
                    Content = "❌",
                    Margin = new Thickness(2.5),
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Red,
                    Background = Brushes.Transparent,
                    BorderBrush = Brushes.Transparent,
                    Padding = new Thickness(0)
                };
                todoItemRemove.Click += RemoveButton_Click;

                todoItemCheckbox.Checked += new RoutedEventHandler(CheckboxChecked);
                todoItemCheckbox.Unchecked += new RoutedEventHandler(CheckboxUnchecked);
                todoItemCheckbox.Content = todoItemText;

                Grid todoItemGrid = new Grid();
                todoItemGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                todoItemGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

                todoItemGrid.Children.Add(todoItemRemove);
                todoItemGrid.Children.Add(todoItemCheckbox);

                Grid.SetColumn(todoItemRemove, 0);
                Grid.SetColumn(todoItemCheckbox, 1);

                TodoList.Children.Insert(0, todoItemGrid);
                TodoInput.Clear();
                id++;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button? removeButton = sender as Button;
            if (removeButton != null)
            {
                Grid? todoItemGrid = removeButton.Parent as Grid;
                if (todoItemGrid != null)
                {
                    TodoList.Children.Remove(todoItemGrid);
                }
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