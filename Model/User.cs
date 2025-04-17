using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace auth_api.Model
{
    [Table ("tbl_user")]
    public class User
    {
        [Key]
        public string id { get; private set; }
        public string? email { get; private set; }
        public Boolean enabled { get; private set; }
        public string? first_name { get; private set; }
        public string? job_title { get; private set; }
        public string? last_name {  get; private set; }
        public string? middle_name {  get; private set; }
        public string password {  get; private set; }
        public string? telephone { get; private set; }
        public string? username {  get; private set; }
        public string? profile_image_id {  get; private set; }
        public string? language_id { get; private set; }
        public string? tenant_id {  get; private set; }
        public int? legacy_id {  get; private set; }
        public string? role {  get; private set; }
        public Boolean?  first_access {  get; private set; }
        public string? calendar_view {  get; private set; }

        public User() { }
        public User(string id, string email, bool enabled, string first_name, string job_title, string last_name, string middle_name, string password, string telephone, string username, string profile_image_id, string language_id, string tenant_id, int legacy_id, string role, bool first_access, string calendar_view)
        {
            this.id = id;
            this.email = email;
            this.enabled = enabled;
            this.first_name = first_name;
            this.job_title = job_title;
            this.last_name = last_name;
            this.middle_name = middle_name;
            this.password = password;
            this.telephone = telephone;
            this.username = username;
            this.profile_image_id = profile_image_id;
            this.language_id = language_id;
            this.tenant_id = tenant_id;
            this.legacy_id = legacy_id;
            this.role = role;
            this.first_access = first_access;
            this.calendar_view = calendar_view;
        }

    }
}
