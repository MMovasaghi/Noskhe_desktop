using System;
using System.Collections.Generic;

namespace noskhe_drugstore_app.Models
{
    public class TextMessage
    {
        public int TextMessageId { get; set; }
        public DateTime Date { get; set; }
        public string VerificationCode { get; set; }
        public bool HasBeenLocked { get; set; }
        public int NumberOfAttempts { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}