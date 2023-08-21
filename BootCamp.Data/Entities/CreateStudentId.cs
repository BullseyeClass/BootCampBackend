using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Entities
{
    public class CreateStudentId
    {
        public static string GenerateStudentId(Trainee trainee)
        {
            string yy = DateTime.Now.Year.ToString().Substring(2);
            string mm = DateTime.Now.Month.ToString("D2");
            string dd = DateTime.Now.Day.ToString("D2");
            int letters = Math.Min(3, trainee.FirstName.Length);
            int numbersCount = Math.Max(0, trainee.PhoneNumbers.FirstOrDefault().Number.Length - 5);
            string first3Letters = trainee.FirstName.Substring(0, letters).ToUpper();
            string phoneNumber = trainee.PhoneNumbers.FirstOrDefault().Number.Substring(numbersCount);
            string studentId = $"{yy}{mm}{dd}-{first3Letters}-{phoneNumber}";

            return studentId;
        }
    }
}
