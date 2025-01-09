﻿namespace PTM.BAL.Utilities.Common
{
    public class MailSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseSSL { get; set; }
        public bool UseStartTls { get; set; }
    }
}