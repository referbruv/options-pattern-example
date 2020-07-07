namespace ReaderOptionsApp.Models
{
    public class SmtpOptions
    {
        public const string SectionName = "Smtp";
        public int Port { get; set; }
        public string From { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSsl { get; set; }
    }
}