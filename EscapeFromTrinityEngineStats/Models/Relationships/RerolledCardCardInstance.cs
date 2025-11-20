using EscapeFromTrinityEngineStats.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.Relationships
{
    public class RerolledCardCardInstance
    {
        public int CardChoiceRecordId { get; set; }
        public int CardInstanceId { get; set; }
        public virtual CardInstance CardInstance { get; set; }
    }
}
