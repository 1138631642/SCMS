using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Model
{
    public class CarPositions
    {
        public int Id { get; set; }
        public int NeedPosition { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public string CarType { get; set; }
    }
}
