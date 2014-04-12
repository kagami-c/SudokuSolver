using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudokuSolver
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadControls();
        }

        List<TextBox> textboxs = new List<TextBox>();
        Number[,] container = new Number[9, 9];

        private void LoadControls()
        {
            for (int i = 0; i < 19; i++)
            {
                MainField.RowDefinitions.Add(new RowDefinition());
                MainField.ColumnDefinitions.Add(new ColumnDefinition());
            }
            MainField.RowDefinitions.Add(new RowDefinition());

            // there is a offset in i & j
            for (int i = 1; i < 19; i++, i++)
            {
                for (int j = 1; j < 19; j++, j++)
                {
                    TextBox textBox = new TextBox();
                    MainField.Children.Add(textBox);
                    textBox.SetValue(Grid.RowProperty, i);
                    textBox.SetValue(Grid.ColumnProperty, j);
                    textBox.Height = 25;
                    textBox.Width = 25;
                    textBox.HorizontalAlignment = HorizontalAlignment.Center;
                    textBox.VerticalAlignment = VerticalAlignment.Center;
                    textBox.TextAlignment = TextAlignment.Center;
                    textboxs.Add(textBox);
                }
            }
        }

        public void startButton_Click(object sender, RoutedEventArgs e)
        {
            int i = 0, j = 0;
            foreach (TextBox text in textboxs)
            {
                if (text.Text.Length == 0)
                {
                    container[i, j] = new Number();
                    container[i, j].Value = 0;
                    container[i, j].IsReadOnly = false;
                }
                else
                {
                    container[i, j] = new Number();
                    container[i, j].Value = Convert.ToInt32(text.Text);
                    container[i, j].IsReadOnly = true;
                }
                j++;
                if (j == 9)
                {
                    j = 0;
                    i++;
                }
            }

            // Start the solution
            MainSolution.Start(container);

            // display the result
            i = 0;
            j = 0;
            foreach (TextBox text in textboxs)
            {
                text.Text = container[i, j].Value.ToString();
                j++;
                if (j == 9)
                {
                    j = 0;
                    i++;
                }
            }
        }

        public void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请在相应位置内填写数独题目，然后单击Start开始运行解题程序。\n注意空白区域请不要填写任何数字。","Help");
        }

        public void clearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox textBox in textboxs)
            {
                textBox.Clear();
            }
        }
    }
}
