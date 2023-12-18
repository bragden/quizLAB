using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace quizTimeBas
{
    public class Quiz
    {
        
        private string _title = string.Empty;
        public string Title => _title;
  
        //public List<Question> MyQuestion{ get; set; }




        public bool GetRandomQuestion(out Question randomQuestion)
        {
            if (DataHelper.questions.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, DataHelper.questions.Count);
                 randomQuestion = DataHelper.questions[randomIndex];
                DataHelper.questions.Remove(randomQuestion);
                return true;
            }
            else
            {
                randomQuestion = null;
                //new MessageBox( "Congratulations, you answered all questions correct! Press STOP QUIZ to return to Main Menu",  0);
                return false;
            }
            //throw new NotImplementedException("A random Question needs to be returned here!");
        }



        public void AddQuestion(string statement, int correctAnswer, params string[] answers)
        {
            var question = new Question(statement, correctAnswer, answers);
            DataHelper.questions.Add(question);
        }

        //public void RemoveQuestion(int index)
        //{
        //    if (index >= 0 && index < _questions.Count)
        //        _questions.RemoveAt(index);
        //}




    }
}
