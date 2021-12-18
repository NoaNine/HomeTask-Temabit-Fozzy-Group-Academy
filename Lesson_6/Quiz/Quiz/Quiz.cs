using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Quiz
    {
        private List<Question> _quiz = new List<Question>();
        private void AddQuiz(string question, string answer, int trueAnswer)
        {
            Question cellQuestion = new Question(question, answer, trueAnswer);
            _quiz.Add(cellQuestion);
        }
        public void FillQuiz()
        {
            AddQuiz("Каким цветом сейчас небо?",
                "Варианты ответов: 1) Синее; 2) Белое; 3) Черное; 4) Оранжевое;", 
                1);
            AddQuiz("Какого цвета футболку вы одевали в прошлый раз?",
                "Варианты ответов: 1) Белая; 2) Красная; 3) Черная; 4) Рубашка;",
                2);
            AddQuiz("Сколько студентов в нашей группе?",
                "Варианты ответов: 1) 6; 2) 30; 3) 28; 4) 23;",
                4);
        }
        private int _count = 0;
        public void Print() // цикл для вывода вопросов и ответов, а так же ответа пользоватеря, 
            //дальше иф который проверяет введенный ответ пользователя на правдивость, счетчик на количество правильных ответов
        {
            Console.WriteLine("Викторина, вам необходимо выбирать цифру правильного ответа");
            int answerUser;
            foreach (Question i in _quiz)
            {
                Console.WriteLine(i.Question1);
                Console.WriteLine(i.Answer);
                answerUser = Convert.ToInt32(Console.ReadLine());
                if (answerUser == i.TrueAnswer)
                    _count++;
            }
            Console.WriteLine("Вы ответили на " + _count + " вопросов правильно");
        }
    }
}
