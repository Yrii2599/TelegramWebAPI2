using ModelsLayer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class MessageDTO
    {
        
        public int Id { get; set; }
        public string Text { get; set; }
        public string OwnerId { get; set; }
        public virtual List<MessageReceiversDTO> Receivers { get; set; }

        public static implicit operator MessageDTO(Message message)
        {
            var resieversDTO = new List<MessageReceiversDTO>();
            foreach (var resiever in message.Receivers)
            {
                resieversDTO.Add(resiever);

            }
            return new MessageDTO { Id = message.Id, Text=message.Text, OwnerId=message.OwnerId, Receivers=resieversDTO };
        }
        public static implicit operator Message(MessageDTO message)
        {
            var resievers = new List<MessageReceivers>();
            foreach (var resiever in message.Receivers)
            {
                resievers.Add(resiever);

            }
            return new Message { Id = message.Id, Text=message.Text, OwnerId=message.OwnerId, Receivers=resievers };
        }
      
    }
}
