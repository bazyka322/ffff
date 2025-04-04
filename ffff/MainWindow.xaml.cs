using System;
using System.Windows;
using System.Windows.Controls;

namespace ExamScoreCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем баллы за каждое задание
                int task1Score = GetValidatedScore(task1Box.Text, 10);
                int task2Score = GetValidatedScore(task2Box.Text, 50);
                int task3Score = GetValidatedScore(task3Box.Text, 30);
                int task4Score = GetValidatedScore(task4Box.Text, 10);

                // Рассчитываем общую сумму
                int totalScore = task1Score + task2Score + task3Score + task4Score;

                // Определяем оценку
                string grade = CalculateGrade(totalScore);

                // Выводим результат
                resultText.Text = $"Общая сумма баллов: {totalScore} из 100";
                gradeText.Text = $"Оценка: {grade}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int GetValidatedScore(string input, int maxScore)
        {
            if (!int.TryParse(input, out int score))
            {
                throw new ArgumentException("Пожалуйста, введите числовые значения для всех заданий.");
            }

            if (score < 0 || score > maxScore)
            {
                throw new ArgumentException($"Баллы за задание должны быть от 0 до {maxScore}.");
            }

            return score;
        }

        public static string CalculateGrade(int totalScore)
        {
            if (totalScore >= 70 && totalScore <= 100)
                return "5 (отлично)";
            else if (totalScore >= 40 && totalScore <= 69)
                return "4 (хорошо)";
            else if (totalScore >= 20 && totalScore <= 39)
                return "3 (удовлетворительно)";
            else if (totalScore >= 0 && totalScore <= 19)
                return "2 (неудовлетворительно)";
            else
                throw new ArgumentException("Общая сумма баллов должна быть от 0 до 100.");
        }
    }
}