using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime CloseDateTime { get; set; }
        public int NeedPosition { get; set; }
        public int Money { get; set; } = 0;
        public int ManangerId { get; set; }
        public int CarTypeId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int CarPositionId { get; set; }
    }
}
