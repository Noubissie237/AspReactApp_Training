using System.ComponentModel.DataAnnotations;
using System.Text;
using System;
using System.Security.Cryptography;

namespace AspReactApp.Server.Models
{
    public class Person
    {
        public int PersonID { get; set; }      
        public string nom { get; set; }
        public string prenom {  get; set; }
        public int age { get; set; }
        public int numero { get; set; }
        private string _password;

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string password
        {
            get { return _password; }
            set
            {
                using (var sha256 = SHA256.Create())
                {
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                    _password = Convert.ToBase64String(hashedBytes);
                }  
            }
        }
    }
}
