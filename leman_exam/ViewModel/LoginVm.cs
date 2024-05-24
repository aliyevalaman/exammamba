using System.ComponentModel.DataAnnotations;

namespace leman_exam.ViewModel
{
    public class LoginVm
    {

        public string EmailorUsername { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }    
    }
}
