using System;
namespace TechJobsOO
{
    public class PositionType : JobField
    {
        public PositionType(string value) : base(value)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is PositionType type &&
                   Id == type.Id &&
                   Value == type.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Value);
        }
    }
}
