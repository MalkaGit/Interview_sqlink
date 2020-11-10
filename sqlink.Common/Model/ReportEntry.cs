using System;
using System.Collections.Generic;
using System.Text;

namespace sqlink.Common.Model
{
    public class ReportEntry
    {
        public DateTime DateCreated {get; set;}

        public eReportActionType ReportActionType { get; set; }

        public eReportEntityType ReportEntityType { get; set; }

        public long? EntityId { get; set; }

        public string RequestBody { get; set; }

    }
}
