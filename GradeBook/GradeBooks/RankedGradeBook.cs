using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5) 
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            
            var grade = Students.Select(y => y.AverageGrade).OrderByDescending(y => y).ToList();
            var thresholds = grade.Count / 5;
            var count = 0;
            var finalgrade = 5;

            foreach (var g in grade)
            {
                if (averageGrade >= g) break;

                count++;
                if (count >= thresholds)
                {
                    count -= thresholds;
                    finalgrade--;
                }
            }
            return finalgrade switch
            {
                5 => 'A',
                4 => 'B',
                3 => 'C',
                2 => 'D',
                _ => 'F'
            };
        }
    }
}
