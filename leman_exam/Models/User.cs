using Microsoft.AspNetCore.Identity;

namespace leman_exam.Models
{
    public class User:IdentityUser
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
        public string UserName {  get; set; }
        public string Email {  get; set; }
    }
}
