using KayitRehberi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        // One to Many İlişkide Customer'ın birden fazla Ticari faliyeti olacağını temsil eden property
        public ICollection<CommercialActivity> commercialActivities { get; set; }
    }
}
