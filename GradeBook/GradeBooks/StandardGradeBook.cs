using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    internal class StandardGradeBook:BaseGradeBook
    {
        public string Name { get; set; }
        public StandardGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Standard;
        }
    }
}
