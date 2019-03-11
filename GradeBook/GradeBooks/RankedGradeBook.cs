using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
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
            studentsAverages.Reverse();

            if (averageGrade >= studentsAverages[(int)Math.Ceiling((double)studentsAverages.Count / 5) - 1])
            {
                return 'A';
            }
            if (averageGrade >= studentsAverages[(int)Math.Ceiling((double)studentsAverages.Count * 2 / 5) - 1])
            {
                return 'B';
            }
            if (averageGrade >= studentsAverages[(int)Math.Ceiling((double)studentsAverages.Count * 3 / 5) - 1])
            {
                return 'C';
            }
            if (averageGrade >= studentsAverages[(int)Math.Ceiling((double)studentsAverages.Count * 4 / 5) - 1])
            {
                return 'D';
            }

                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)

            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)

            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

    }
}
