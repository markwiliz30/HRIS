using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
   public class PendingItem
    {
        public int EMPID { get; set; }
        public string PENDING_TYPE { get; set; }

        public string PENDING_STATUS { get; set; }  

        public string PENDING_DATE { get; set; }
        public string PENDING_NAME { get; set; }

        public string PENDING_POSITION { get; set; }
    }
}
