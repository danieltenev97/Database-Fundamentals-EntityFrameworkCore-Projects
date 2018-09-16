using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAndAttribuesValidationDemo
{
   public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public int Age { get; set; }
        [Xor(nameof(LessonId))]
        public int? CourseId { get; set; }

        public int? LessonId { get; set; }
        
        
        
    }
}
