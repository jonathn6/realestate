using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace realestate
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestions(int Chapter);
        Question GetNextQuestion(int Chapter, int id);
        Question GetSpecificQuestion(int Chapter, int id);
    }
}
