using KayitRehberi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Domain.Entities
{
    public class CommercialActivity :BaseEntity
    {

        public string ServiceName { get; set; }
        public float  ServiceCharge { get; set; }
        public DateTime ServiceDate { get; set; }

        // One to Many İlişkisinin kurulması için gerekli Navigation Property
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
