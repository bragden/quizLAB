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

namespace quizTimeBas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataHelper.LoadJSON();

        }




        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PlayQuiz playQuiz = new PlayQuiz();
            playQuiz.Show();
        }

        private void CreateQuizButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            CreateQuiz createQuiz = new CreateQuiz();
            createQuiz.Show();
        }

    }
}
