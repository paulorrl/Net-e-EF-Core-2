﻿using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Email Email { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}