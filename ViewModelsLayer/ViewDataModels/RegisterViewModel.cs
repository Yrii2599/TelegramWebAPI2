using System.ComponentModel.DataAnnotations;


namespace ViewModelsLayer.ViewDataModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
