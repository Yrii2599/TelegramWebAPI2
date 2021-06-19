using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class MessageReceivers
    {
        [Key]
        public int Id { get; set; }
        public string ReceiverId { get; set; }
    }
}
