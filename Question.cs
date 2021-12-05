using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace realestate
{
    public class Question
    {
        public int question_id { get; set; }
        public int chapter { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public string answer_1 { get; set; }
        public string answer_2 { get; set; }
        public string answer_3 { get; set; }
        public string answer_4 { get; set; }
        public int questions_right { get; set; }
        public int questions_tried { get; set; }
        public string whichScreen { get; set; }
    }
}
