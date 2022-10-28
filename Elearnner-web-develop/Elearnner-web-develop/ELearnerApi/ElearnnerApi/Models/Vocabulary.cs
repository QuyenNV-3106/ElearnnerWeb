using System;
using System.Collections.Generic;

#nullable disable

namespace ElearnerApi.Models
{
    public partial class Vocabulary
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string English { get; set; }
        public string Vietnamese { get; set; }

        public virtual Account User { get; set; }
    }
}
