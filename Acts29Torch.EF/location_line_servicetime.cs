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
    
    public partial class location_line_servicetime
    {
        public int aid { get; set; }
        public Nullable<int> location_aid { get; set; }
        public Nullable<byte> week_type { get; set; }
        public string service_start_time { get; set; }
        public string service_end_time { get; set; }
        public Nullable<byte> disable { get; set; }
        public string build_datetime { get; set; }
        public string last_mod_time { get; set; }
        public Nullable<long> last_mod_user_aid { get; set; }
        public Nullable<long> acts29_church_aid { get; set; }
    }
}
