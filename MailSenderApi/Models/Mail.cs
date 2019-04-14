using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailSenderApi.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
