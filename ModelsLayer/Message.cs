using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string OwnerId { get; set; }
        public virtual List<MessageReceivers> Receivers { get; set; }
    }
}
