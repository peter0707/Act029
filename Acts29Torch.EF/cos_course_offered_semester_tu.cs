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
    
    public partial class cos_course_offered_semester_tu
    {
        public long aid { get; set; }
        public Nullable<long> course_info_aid { get; set; }
        public Nullable<int> semester_aid { get; set; }
        public Nullable<int> course_limit { get; set; }
        public Nullable<int> course_limitL { get; set; }
        public Nullable<int> course_fee { get; set; }
        public string course_offered_classname { get; set; }
        public string course_elect_start_date { get; set; }
        public string course_elect_start_time { get; set; }
        public string course_elect_end_date { get; set; }
        public string course_elect_end_time { get; set; }
        public Nullable<int> course_payfee_valid_hr { get; set; }
        public string course_payfee_valid_date_time { get; set; }
        public string course_time_desc { get; set; }
        public Nullable<int> location_aid { get; set; }
        public Nullable<long> course_teacher_aid { get; set; }
        public Nullable<long> course_assistant_aid { get; set; }
        public Nullable<long> schedule_aid { get; set; }
        public string backend_comments { get; set; }
        public Nullable<byte> if_hidden_teacher { get; set; }
        public string course_teacher_desc { get; set; }
        public Nullable<byte> disable { get; set; }
        public string build_datetime { get; set; }
        public string last_mod_time { get; set; }
        public Nullable<int> last_mod_user_aid { get; set; }
        public Nullable<long> acts29_church_aid { get; set; }
    }
}
