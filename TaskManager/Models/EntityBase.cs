

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
    }
}
