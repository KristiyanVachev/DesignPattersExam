﻿using System;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        public const int MaxStudentMarksCount = 20;

        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, IMark mark)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            //var newMark = new Mark(this.Subject, mark);
            //var newMark = Engine.SchoolFactory.CreateaMark(tchis.Subject, mark);
            var newMark = mark;

            student.Marks.Add(newMark);
        }
    }
}
