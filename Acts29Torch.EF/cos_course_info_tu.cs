//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Acts29Torch.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class cos_course_info_tu
    {
        public long aid { get; set; }
        public string course_id { get; set; }
        public string course_name { get; set; }
        public Nullable<byte> if_semester_in { get; set; }
        public Nullable<byte> if_obligatory { get; set; }
        public Nullable<byte> if_primary { get; set; }
        public Nullable<int> credit { get; set; }
        public Nullable<decimal> course_time { get; set; }
        public string course_time_desc { get; set; }
        public string course_desc { get; set; }
        public string completion_desc { get; set; }
        public string coures_cap_desc { get; set; }
        public Nullable<int> faculty_info_aid { get; set; }
        public string backend_comments { get; set; }
        public Nullable<byte> disable { get; set; }
        public string build_datetime { get; set; }
        public string last_mod_time { get; set; }
        public Nullable<int> last_mod_user_aid { get; set; }
        public Nullable<long> acts29_church_aid { get; set; }
    }
}
