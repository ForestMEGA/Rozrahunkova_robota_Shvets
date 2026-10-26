using System;
using System.Windows;

namespace Rozrahunkova_robota_Shvets
{
    public partial class MainWindow : Window
    {
        private QueueList myQueue;

        public MainWindow()
        {
            InitializeComponent();
            myQueue = new QueueList();
            UpdateUI();
        }

        private void EnqueueButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputTextBox.Text, out int value))
            {
                myQueue.Enqueue(value);
                InputTextBox.Clear();
                UpdateUI();
                InputTextBox.Focus();
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректне ціле число.", "Помилка введення", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DequeueButton_Click(object sender, RoutedEventArgs e)
        {
            if (myQueue.IsEmpty())
            {
                MessageBox.Show("Черга вже порожня!", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            myQueue.Dequeue();
            UpdateUI();
        }

        private void UpdateUI()
        {
            QueueDisplayTextBox.Text = myQueue.ToString();
            QueueReverseDisplayTextBox.Text = myQueue.ToReverseString();

            CountTextBlock.Text = myQueue.Count.ToString();

            int? peekValue = myQueue.Peek();
            PeekTextBlock.Text = peekValue.HasValue ? peekValue.Value.ToString() : "немає";

            NegativeCountTextBlock.Text = myQueue.CountNegative().ToString();
        }
    }
}
