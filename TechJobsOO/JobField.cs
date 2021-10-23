using System;
using System.Collections.Generic;
using System.Text;

namespace TechJobsOO
{
    public abstract class JobField
    {
        public int Id { get; }
        public string Value { get; set; }
        protected static int nextId = 1;

        protected JobField()
        {
            Id = nextId;
            nextId++;
        }

        protected JobField(string value) : this()
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
