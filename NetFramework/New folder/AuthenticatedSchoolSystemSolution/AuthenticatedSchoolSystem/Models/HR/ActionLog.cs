using System;

namespace AuthenticatedSchoolSystem.Models.HR
{
    public class ActionLog
    {
        public string ID { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string HttpMethod { get; set; }
        public string UrlHelper { get; set; }
        public DateTime ActionDate { get; set; }
    }
}