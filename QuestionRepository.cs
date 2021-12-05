using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace realestate
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IDbConnection _conn;
        public QuestionRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Question GetNextQuestion(int id)
        {
            try
            {
                var SQL = "SELECT * FROM realestate.questions WHERE question_id > " + id + " ORDER BY question_id LIMIT 1";
                return _conn.QuerySingle<Question>(SQL);
            } 
            catch
            {
                var returnObject = new Question();
                returnObject.whichScreen = "F";
                return returnObject;
            }
        }

        public IEnumerable<Question> GetQuestions(int Chapter)
        {
            if (Chapter == 0)
            {
                return _conn.Query<Question>("SELECT * FROM realestate.questions");
            } else
            {
                var SQL = "SELECT * FROM realestate.questions WHERE chapter = " + Chapter;
                return _conn.Query<Question>(SQL);
            }
        }

        public Question GetSpecificQuestion(int id)
        {
            var SQL = "SELECT * FROM realestate.questions WHERE question_id = " + id;
            return _conn.QuerySingle<Question>(SQL);
        }
    }
}
