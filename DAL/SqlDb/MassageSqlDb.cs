using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AbstractionsLayer;
using DAL.Context;
using ModelsLayer;


namespace DAL.SqlDb
{

    public class MassageSqlDb : IMessageData
    {
        private readonly TelegramContext _db;
        public MassageSqlDb()
        {
            _db = new TelegramContext(new DbContextOptions<TelegramContext>());
        }
        public MassageSqlDb(TelegramContext telegramContext)
        {
            _db = telegramContext;
        }

        public Message Add(Message messageData)
        {
            try
            {
                if (messageData != null)
                {
                    var result = _db.Messages.Add(messageData).Entity;
                    _db.SaveChanges();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public Message Edit(int messageId, Message messageData)
        {
            try
            {
                var currentMessage = GetById(messageId);

                if (currentMessage != null && messageData != null)
                {
                    currentMessage.Text = messageData.Text;
                    _db.SaveChanges();

                }
                return currentMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public IEnumerable<Message> Get()
        {
            try
            {
                return _db.Messages.Include(n => n.Receivers).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public IEnumerable<Message> Get(Func<Message, bool> predicate)
        {
            try
            {
                return Get().Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public Message GetById(int messageId)
        {
            try
            {
                return Get().FirstOrDefault(u => u.Id == messageId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public bool Remove(int messageId)
        {
            try
            {
                var currentMessage = GetById(messageId);

                if (currentMessage != null)
                {
                    _db.Messages.Remove(currentMessage);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }
    }
}
