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

namespace quizTimeBas
{
    /// <summary>
    /// Interaction logic for CreateQuiz.xaml
    /// </summary>
    public partial class CreateQuiz : Window
    {
        public CreateQuiz()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string[] answers = {EditAns1.Text, EditAns2.Text, EditAns3.Text, EditAns4.Text};
            RadioButton[] correctAnswer = { Button0, Button1, Button2, Button3 };
            int correctIndex = int.Parse((string)correctAnswer.First(x=> (bool)x.IsChecked).Tag);
            Question newQuestion = new Question(EditQuestion.Text, correctIndex, answers);
            DataHelper.questions.Add(newQuestion);
            DataHelper.SaveJSON();
            EditAns1.Clear();
            EditAns2.Clear();
            EditAns3.Clear();
            EditAns4.Clear();
            EditQuestion.Clear();
            foreach (var item in correctAnswer)
            {
                item.IsChecked = false;
            }
        }
    }
}
