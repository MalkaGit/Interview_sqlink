using System;
using System.Collections.Generic;
using System.Text;

namespace sqlink.Common.Model
{
    public enum eReportActionType
    {
        create,
        get_all,
        update,
        delete,
        bulk_update,
        bulk_delete
    }

    public enum eReportEntityType
    {
        vehicle
    }
    
    public enum eReportIntervalType
    {
        hour,
        day ,
        week,
        month,
        year
    }
}
