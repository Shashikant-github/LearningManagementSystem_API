using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserAPI.Models
{
    public class UserModel
    {
        #region Properties
        [JsonIgnore]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string EmailID { get; set; }
        public bool IsAdmin { get; set; }
        #endregion
    }
}
