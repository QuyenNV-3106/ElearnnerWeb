using System;
using System.Collections.Generic;

#nullable disable

namespace ELearnerApi.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImgUrl { get; set; }
        public string Kind { get; set; }
        public string MeetUrl { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
