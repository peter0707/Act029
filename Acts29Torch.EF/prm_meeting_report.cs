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
    
    public partial class prm_meeting_report
    {
        public long aid { get; set; }
        public Nullable<int> meeting_type { get; set; }
        public Nullable<byte> if_held { get; set; }
        public Nullable<int> prm_organization_privilege_aid { get; set; }
        public string meeting_location { get; set; }
        public Nullable<long> account_aid { get; set; }
        public string meeting_start_date { get; set; }
        public string meeting_start_date_time { get; set; }
        public string meeting_end_date { get; set; }
        public string meeting_end_date_time { get; set; }
        public string meeting_desc { get; set; }
        public string meeting_members { get; set; }
        public Nullable<long> acts29_church_aid { get; set; }
        public Nullable<byte> disable { get; set; }
        public string build_datetime { get; set; }
        public string last_mod_time { get; set; }
        public Nullable<int> last_mod_user_aid { get; set; }
    }
}
