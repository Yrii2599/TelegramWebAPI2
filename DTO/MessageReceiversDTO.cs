using System.ComponentModel.DataAnnotations;

namespace ModelsLayer
{
    public class MessageReceiversDTO
    {  
        public string ReceiverId { get; set; }

        public static implicit operator MessageReceiversDTO(MessageReceivers messageReceivers)
        {
            return new MessageReceiversDTO { ReceiverId=messageReceivers.ReceiverId };
        } 
        public static implicit operator MessageReceivers(MessageReceiversDTO messageReceivers)
        {
            return new MessageReceivers { ReceiverId=messageReceivers.ReceiverId };
        }
    }
}
