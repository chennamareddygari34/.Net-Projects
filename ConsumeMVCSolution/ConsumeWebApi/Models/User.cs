using System.ComponentModel.DataAnnotations;

namespace ConsumeMVCApp.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] Key { get; set; }



    }
}
