using System.ComponentModel.DataAnnotations;

namespace leman_exam.ViewModel
{
    public class RegisterVm
    {
       
        [MinLength(3)]
        [MaxLength(25)]
        public string Name {  get; set; }
       
        [MinLength(3)]
        [MaxLength(25)]
        public string Surname {  get; set; }
        [DataType(DataType.EmailAddress)]
       
        [MinLength(3)]
        [MaxLength(25)]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword {  get; set; }

    }
}
