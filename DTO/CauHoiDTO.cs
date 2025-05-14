using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CauHoiDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int CorrectAnswerId { get; set; }
        public int QuizId { get; set; }
    }
}
