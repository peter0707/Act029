﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Acts29TorchEntities : DbContext
    {
        public Acts29TorchEntities()
            : base("name=Acts29TorchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> account { get; set; }
        public virtual DbSet<account_line_apply_change_info> account_line_apply_change_info { get; set; }
        public virtual DbSet<account_line_group_privilege> account_line_group_privilege { get; set; }
        public virtual DbSet<account_line_prm_roles> account_line_prm_roles { get; set; }
        public virtual DbSet<account_session_security> account_session_security { get; set; }
        public virtual DbSet<act_apply_info> act_apply_info { get; set; }
        public virtual DbSet<act_apply_line_answer> act_apply_line_answer { get; set; }
        public virtual DbSet<act_apply_line_ticket> act_apply_line_ticket { get; set; }
        public virtual DbSet<act_event_form> act_event_form { get; set; }
        public virtual DbSet<act_event_info> act_event_info { get; set; }
        public virtual DbSet<act_event_info_line_client_id> act_event_info_line_client_id { get; set; }
        public virtual DbSet<act_event_info_line_images> act_event_info_line_images { get; set; }
        public virtual DbSet<act_event_line_ticket> act_event_line_ticket { get; set; }
        public virtual DbSet<act_event_q_option> act_event_q_option { get; set; }
        public virtual DbSet<act_event_question> act_event_question { get; set; }
        public virtual DbSet<act_staff_info> act_staff_info { get; set; }
        public virtual DbSet<acts29_church> acts29_church { get; set; }
        public virtual DbSet<acts29_church_line_donation_account_info> acts29_church_line_donation_account_info { get; set; }
        public virtual DbSet<acts29_church_line_page_website_group> acts29_church_line_page_website_group { get; set; }
        public virtual DbSet<acts29_church_line_servicetime> acts29_church_line_servicetime { get; set; }
        public virtual DbSet<cos_course_info_line_elect_requirement_tu> cos_course_info_line_elect_requirement_tu { get; set; }
        public virtual DbSet<cos_course_info_tu> cos_course_info_tu { get; set; }
        public virtual DbSet<cos_course_offered_line_progress_tu> cos_course_offered_line_progress_tu { get; set; }
        public virtual DbSet<cos_course_offered_semester_tu> cos_course_offered_semester_tu { get; set; }
        public virtual DbSet<cos_faculty_info_tu> cos_faculty_info_tu { get; set; }
        public virtual DbSet<cos_home_images_tu> cos_home_images_tu { get; set; }
        public virtual DbSet<cos_lesson_info> cos_lesson_info { get; set; }
        public virtual DbSet<cos_lesson_line_progress> cos_lesson_line_progress { get; set; }
        public virtual DbSet<cos_semester_info_tu> cos_semester_info_tu { get; set; }
        public virtual DbSet<cos_staff_info> cos_staff_info { get; set; }
        public virtual DbSet<css_style> css_style { get; set; }
        public virtual DbSet<d_option> d_option { get; set; }
        public virtual DbSet<d_select> d_select { get; set; }
        public virtual DbSet<group_privilege> group_privilege { get; set; }
        public virtual DbSet<group_privilege_line> group_privilege_line { get; set; }
        public virtual DbSet<location_info> location_info { get; set; }
        public virtual DbSet<location_line_booking> location_line_booking { get; set; }
        public virtual DbSet<location_line_booking_datetime> location_line_booking_datetime { get; set; }
        public virtual DbSet<location_line_organization_booking> location_line_organization_booking { get; set; }
        public virtual DbSet<location_line_servicetime> location_line_servicetime { get; set; }
        public virtual DbSet<log_action> log_action { get; set; }
        public virtual DbSet<log_error> log_error { get; set; }
        public virtual DbSet<member> member { get; set; }
        public virtual DbSet<member_acts29_church> member_acts29_church { get; set; }
        public virtual DbSet<member_end_user_tu> member_end_user_tu { get; set; }
        public virtual DbSet<member_line_cos_elect> member_line_cos_elect { get; set; }
        public virtual DbSet<member_line_cos_lesson_info> member_line_cos_lesson_info { get; set; }
        public virtual DbSet<member_line_images> member_line_images { get; set; }
        public virtual DbSet<member_line_notification_tu> member_line_notification_tu { get; set; }
        public virtual DbSet<member_line_prm_info> member_line_prm_info { get; set; }
        public virtual DbSet<member_line_prm_new_friend_info> member_line_prm_new_friend_info { get; set; }
        public virtual DbSet<member_line_prm_organiztion_audit> member_line_prm_organiztion_audit { get; set; }
        public virtual DbSet<member_line_refund_info_tu> member_line_refund_info_tu { get; set; }
        public virtual DbSet<member_type> member_type { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<news_line_reference> news_line_reference { get; set; }
        public virtual DbSet<notification> notification { get; set; }
        public virtual DbSet<page> page { get; set; }
        public virtual DbSet<page_website_group> page_website_group { get; set; }
        public virtual DbSet<page_website_group_end_user> page_website_group_end_user { get; set; }
        public virtual DbSet<prm_meeting_report> prm_meeting_report { get; set; }
        public virtual DbSet<prm_meeting_report_line_reply> prm_meeting_report_line_reply { get; set; }
        public virtual DbSet<prm_meeting_report_line_require> prm_meeting_report_line_require { get; set; }
        public virtual DbSet<prm_organization_privilege> prm_organization_privilege { get; set; }
        public virtual DbSet<prm_temp_recursive_privlilege> prm_temp_recursive_privlilege { get; set; }
        public virtual DbSet<schedule_recurrence> schedule_recurrence { get; set; }
        public virtual DbSet<temp_member_line_prm_info> temp_member_line_prm_info { get; set; }
        public virtual DbSet<tra_cashflow_atm> tra_cashflow_atm { get; set; }
        public virtual DbSet<tra_cashflow_atm_line_act_apply_info> tra_cashflow_atm_line_act_apply_info { get; set; }
        public virtual DbSet<tra_cashflow_atm_line_refund_info> tra_cashflow_atm_line_refund_info { get; set; }
        public virtual DbSet<tra_cashflow_atm_tu> tra_cashflow_atm_tu { get; set; }
        public virtual DbSet<tra_cashflow_atm_tu_line_member_cos_info> tra_cashflow_atm_tu_line_member_cos_info { get; set; }
    }
}
