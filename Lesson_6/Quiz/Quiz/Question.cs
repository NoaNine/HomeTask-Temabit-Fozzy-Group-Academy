using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Question
    {
        private string _question;
        private string _answer;
        private int _trueAnswer;
        public string Question1 { get { return _question; } }
        public string Answer { get { return _answer; } }
        public int TrueAnswer { get { return _trueAnswer; } }
        public Question(string question, string answer, int trueAnswer)
        {
            _question = question;
            _answer = answer;
            _trueAnswer = trueAnswer;
        }
    }
}
