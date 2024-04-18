using System.ComponentModel.DataAnnotations;

namespace bulutbilisim.Model
{
    public class User_Tb
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public string pass { get; set; }
    }
}
