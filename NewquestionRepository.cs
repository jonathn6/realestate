using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace realestate
{
    public class NewquestionRepository : INewquestionRepository
    {
        private readonly IDbConnection _conn;
        public NewquestionRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public void SaveQuestions(Question question)
        {
            var quote = "\"";
            var SQL = "INSERT INTO realestate.questions (chapter, question, correct_answer, answer_1, answer_2, answer_3, answer_4) VALUES (";
            SQL += quote + question.chapter + quote + ",";
            SQL += quote + question.question + quote + ",";
            SQL += quote + question.correct_answer + quote + ",";
            SQL += quote + question.answer_1 + quote + ",";
            SQL += quote + question.answer_2 + quote + ",";
            SQL += quote + question.answer_3 + quote + ",";
            SQL += quote + question.answer_4 + quote + ")";

            _conn.Execute(SQL);
        }
    }
}
