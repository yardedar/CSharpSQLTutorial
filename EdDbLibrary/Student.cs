using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSQLTutorial
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StateCode { get; set; }
        public int? SAT { get; set; }
        public decimal GPA { get; set; }
        public int? MajorId { get; set; }

        public override string ToString()
        {
            return $"{this.Id} | {this.FirstName} {this.LastName} | {this.StateCode}" + $" | {(this.SAT != null ? this.SAT : "Null")} | {this.GPA}";

        }
    }
}
