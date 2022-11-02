using System;
using System.Collections.Generic;

#nullable disable

namespace ELearnerApi.Models
{
    public partial class Receipt
    {
        public int Id { get; set; }
        public int NumberCard { get; set; }
        public int? UserId { get; set; }
        public DateTime? DayBilling { get; set; }
        public int? CourseId { get; set; }
        public string Status { get; set; }

        public virtual Course Course { get; set; }
        public virtual Accounts User { get; set; }
    }
}
