namespace auth_api.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Email { get;  set; }
        public Boolean Enabled { get;  set; }
        public string First_name { get;  set; }
        public string Job_title { get;  set; }
        public string Last_name { get;  set; }
        public string Middle_name { get;  set; }
        public string Password { get;  set; }
        public string Telephone { get;  set; }
        public string Username { get;  set; }
        public string Profile_image_id { get;  set; }
        public string Language_id { get;  set; }
        public string Tenant_id { get;  set; }
        public int Legacy_id { get;  set; }
        public string Role { get;  set; }
        public Boolean First_access { get;  set; }
        public string Calendar_view { get;  set; }
    }
}
