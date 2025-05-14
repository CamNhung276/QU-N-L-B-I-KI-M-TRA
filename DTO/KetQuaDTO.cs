using System;

namespace DTO
{
    public class KetQuaDTO
    {
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public decimal Score { get; set; }
        public DateTime DateTaken { get; set; }
        public string StudentName { get; set; }
        public string QuizTitle { get; set; }
        public string SubjectName { get; set; }
    }
}
