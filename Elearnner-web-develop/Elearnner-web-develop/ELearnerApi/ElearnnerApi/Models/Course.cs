using System;
using System.Collections.Generic;

#nullable disable

namespace ELearnerApi.Models
{
    public partial class Course
    {
        public Course()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public string Kind { get; set; }
        public double? Discount { get; set; }
        public DateTime? Duration { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public override string ToString()
        {
            return Name;
        }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
