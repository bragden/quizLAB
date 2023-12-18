using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace quizTimeBas
{
    /// <summary>
    /// Interaction logic for PlayQuiz.xaml
    /// </summary>
    public partial class PlayQuiz : Window
    {
        public Quiz myQuiz = new Quiz();
        List<Question> selectedQuestion = new List<Question>();
        List<string> SelectedCategory = new List<string>();
        public string ChosenGame;
        Question currentQuestion;
        int Score;
        int TotalQuestions;


        public PlayQuiz()
        {
            InitializeComponent();
            
           

        }


        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            //if (currentQuestion < DataHelper.questions.Count)
            //{
                Button selectedButton = (Button)sender;
                
                int selectedAnswers = int.Parse(selectedButton.Tag.ToString());

                if (selectedAnswers == currentQuestion.CorrectAnswer)
                {
                    Score++;
                    scoreText.Text = $"{Score}/ {TotalQuestions}";
                }
                else
                {
                    MessageBox.Show("Wrong answer");
                }
                double percentage = Percentage(Score, TotalQuestions);
                Procent.Text = $"{percentage:F1} %";
                NextQuestion();
            

        }
        public void NextQuestion()
        {

            // Get the next random question
            if (myQuiz.GetRandomQuestion(out currentQuestion ))

            // Check if we have not run out of questions
            {
                QuestionTextBlock.Text = currentQuestion.Statement;
                // QuizImage.Source = question.ImagePath; // Uncomment this if you have image paths for questions

                Ans1.Content = currentQuestion.Answers[0];
                Ans1.Tag = "0"; // Tag needs to be updated to match the index of the answer
                Ans2.Content = currentQuestion.Answers[1];
                Ans2.Tag = "1";
                Ans3.Content = currentQuestion.Answers[2];
                Ans3.Tag = "2";
                Ans4.Content = currentQuestion.Answers[3];
                Ans4.Tag = "3";
            }
            else
            {
                // No more questions
                MessageBox.Show($"Your result: {Score} / {TotalQuestions}");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                // Handle the end of the quiz
            }
        }


        private double Percentage(int correctAnswers, int totalQuestions)
        {
            if (totalQuestions == 0.0)
            {
                return 0.0;
            }

            return (double)correctAnswers / totalQuestions * 100;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TotalQuestions = DataHelper.questions.Count;
            NextQuestion();
        }


    }

}
