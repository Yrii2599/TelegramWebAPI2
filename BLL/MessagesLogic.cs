using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using DAL.DataManager;
using DTO;
using Microsoft.AspNetCore.Identity;
using ModelsLayer;


namespace BLL
{
    public class MessagesLogic
    {
        private readonly DataManager _dataManager;
        private readonly IIdentity _identity;
        private readonly UserManager<User> _userManager;

        public MessagesLogic(IIdentity identity, UserManager<User> userManager)
        {
            _dataManager = new DataManager();
            _identity = identity;
            _userManager = userManager;
        }

        public bool CreateMessage(string text, params string[] usersId)
        {
            try
            {
                if (_identity != null && !string.IsNullOrEmpty(text))
                {
                    var currentUser = _userManager.Users.ToList().FirstOrDefault(user => user.UserName == _identity.Name);
                    if (currentUser != null)
                    {
                        var receivers = new List<MessageReceivers>();
                        foreach (var name in usersId)
                        {
                            receivers.Add(new MessageReceivers() { ReceiverId = name });
                        }

                        return _dataManager.Messages.Add(new Message() { OwnerId = currentUser.Id, Text = text, Receivers = receivers }) != null;
                    }
                }

                return false;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public IEnumerable<MessageDTO> ReadAllMessage()
        {
            try
            {
                if (_identity != null)
                {
                    var currentUser = _userManager.Users.ToList().FirstOrDefault(user => user.UserName == _identity.Name);
                    if (currentUser != null)
                    {
                        var currentMessages = _dataManager.Messages.Get();
                        if (IsAdmin(currentUser))
                        {
                            var resultDTO = new List<MessageDTO>();
                            foreach (var message in currentMessages)
                            {
                                resultDTO.Add(message);
                            }
                            return resultDTO;
                        }
                    }
                }
                return new List<MessageDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public IEnumerable<MessageDTO> ReadAllOwnMessages()
        {
            try
            {
                if (_identity != null)
                {
                    var currentUser = _userManager.Users.ToList().FirstOrDefault(user => user.UserName == _identity.Name);
                    if (currentUser != null)
                    {
                        var currentMessages = _dataManager.Messages.Get(m => m.OwnerId == currentUser.Id);
                        var resultDTO = new List<MessageDTO>();
                        foreach (var message in currentMessages)
                        {
                            resultDTO.Add(message);
                        }
                        return resultDTO;
                    }
                }

                return new List<MessageDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public IEnumerable<MessageDTO> ReadAllInUserMessages(string userId)
        {
            try
            {
                if (_identity != null)
                {
                    var currentUser = _userManager.Users.ToList().FirstOrDefault(u => u.UserName == _identity.Name);
                    if (currentUser != null)
                    {
                        if (IsAdmin(currentUser))
                        {
                            var currentMessages = _dataManager.Messages.Get(m => m.OwnerId == userId);
                            var resultDTO = new List<MessageDTO>();
                            foreach (var message in currentMessages)
                            {
                                resultDTO.Add(message);
                            }

                            return resultDTO;
                        }
                    }
                }

                return new List<MessageDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public MessageDTO ReadMessage(int messageId)
        {
            try
            {
                if (_identity != null)
                {
                    var currentUser = _userManager.Users.ToList().FirstOrDefault(user => user.UserName == _identity.Name);
                    if (currentUser != null)
                    {
                        var currentMessage = _dataManager.Messages.GetById(messageId);
                        if (currentMessage != null && (currentMessage.OwnerId == currentUser.Id || currentMessage.Receivers.Any(r => r.ReceiverId == currentUser.Id) || IsAdmin(currentUser)))
                        {
                            return currentMessage;
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public bool EditMessage(int messageId, string text, params string[] usersId)
        {
            try
            {
                if (_identity != null && !string.IsNullOrEmpty(text))
                {
                    var currentUser = _userManager.Users.ToList().FirstOrDefault(user => user.UserName == _identity.Name);
                    if (currentUser != null)
                    {
                        var currentMessage = _dataManager.Messages.GetById(messageId);
                        if (currentMessage != null && (currentMessage.OwnerId == currentUser.Id || IsAdmin(currentUser)))
                        {
                            var receivers = new List<MessageReceivers>();
                            foreach (var name in usersId)
                            {
                                receivers.Add(new MessageReceivers() { ReceiverId = name });
                            }
                            return _dataManager.Messages.Edit(messageId, new Message() { OwnerId = currentMessage.OwnerId, Receivers = receivers, Text = text }) != null;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        public bool RemoveMessage(int messageId)
        {
            try
            {
                if (_identity != null)
                {
                    var currentUser = _userManager.Users.ToList().FirstOrDefault(user => user.UserName == _identity.Name);
                    if (currentUser != null)
                    {
                        var currentMessage = _dataManager.Messages.GetById(messageId);
                        if (currentMessage != null && (currentMessage.OwnerId == currentUser.Id || IsAdmin(currentUser)))
                        {
                            return _dataManager.Messages.Remove(messageId);
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

        private bool IsAdmin(User user)
        {
            try
            {
                return _userManager.IsInRoleAsync(user, "Administrator").Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }
    }
}
