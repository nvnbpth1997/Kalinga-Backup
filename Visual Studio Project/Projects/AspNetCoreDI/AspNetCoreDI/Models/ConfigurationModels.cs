namespace AspNetCoreDI.Models
{


    public class Rootobject
    {
        public Logging Logging { get; set; }
        public string SomeKey { get; set; }
        public SMTP SMTP { get; set; }
        public string AllowedHosts { get; set; }
        public SQL SQL { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
    }

    public class SMTP
    {
        public int Port { get; set; }
        public string domain { get; set; }
    }

    public class SQL
    {
        public string ConnectionString { get; set; }
        public string ConnectionString1 { get; set; }
    }


}
