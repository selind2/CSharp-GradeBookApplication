using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            List<double> studentsAverages = new List<double>();

            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            foreach(var item in Students)
            {
                studentsAverages.Add(item.AverageGrade);
            }

            studentsAverages.Sort();

            if (averageGrade >= studentsAverages[(studentsAverages.Count / 5) - 1])
            {
                return 'A';
            }
            if (averageGrade >= studentsAverages[(studentsAverages.Count * 2 / 5) - 1])
            {
                return 'B';
            }
            if (averageGrade >= studentsAverages[(studentsAverages.Count * 3 / 5) - 1])
            {
                return 'C';
            }
            if (averageGrade >= studentsAverages[(studentsAverages.Count * 4 / 5) - 1])
            {
                return 'D';
            }

                return 'F';
        }

    }
}
