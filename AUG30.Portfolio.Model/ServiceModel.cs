using System.ComponentModel.DataAnnotations;

namespace AUG30.Portfolio.Model
{
    public class ServiceModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
    }
}
