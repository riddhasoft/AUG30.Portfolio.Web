using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AUG30.Portfolio.Web.Models
{
    public class ProfileModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Description("Professional Summary")]
        public string Summary { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? WebSite { get; set; }

    }
}
