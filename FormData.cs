using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace realestate
{
    public class FormData
    {
        public int CorrectAnswer { get; set; }
        public int UserAnswer { get; set; }
        public int question_id { get; set; }
        public int questions_right { get; set; }
        public int questions_tried { get; set; }
        public string whichScreen { get; set; }

    }
}
