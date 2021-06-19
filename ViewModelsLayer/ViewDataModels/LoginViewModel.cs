using System.ComponentModel.DataAnnotations;


namespace ViewModelsLayer.ViewDataModels
{
    public class LoginViewModel
    {
      
        public string Name_Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
