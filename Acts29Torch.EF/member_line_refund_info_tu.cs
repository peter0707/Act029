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
    
    public partial class member_line_refund_info_tu
    {
        public long aid { get; set; }
        public long member_tu_aid { get; set; }
        public Nullable<long> tra_cashflow_atm_tu_aid { get; set; }
        public string refund_account_name { get; set; }
        public Nullable<long> refund_account_id { get; set; }
        public string refund_bank_name { get; set; }
        public string refund_bank_branches { get; set; }
        public Nullable<decimal> refund_money { get; set; }
        public int status { get; set; }
        public byte disable { get; set; }
        public byte if_bk_refund { get; set; }
        public string comments { get; set; }
        public string build_datetime { get; set; }
        public string last_mod_time { get; set; }
        public Nullable<int> last_mod_user_aid { get; set; }
    }
}
