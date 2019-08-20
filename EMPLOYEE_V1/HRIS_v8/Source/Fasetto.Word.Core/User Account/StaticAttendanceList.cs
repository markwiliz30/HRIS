﻿

using System.Collections.ObjectModel;

namespace Fasetto.Word.Core
{
    public class StaticAttendanceList
    {
        public static ObservableCollection<AttendanceItem> staticAttendanceList = new ObservableCollection<AttendanceItem>();
    }

    public class StaticPendingList
    {
        public static ObservableCollection<PendingItem> staticPendingList = new ObservableCollection<PendingItem>();
    }

    public class StaticApprovalList
    {
        public static ObservableCollection<PendingItem> staticApprovalList = new ObservableCollection<PendingItem>();
    }

    public class StaticApprovalItem
    {
        public static PendingItem staticApprovalModalItem = new PendingItem();
    }
}
