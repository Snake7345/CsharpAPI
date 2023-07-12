using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class RolePermission
    {
        [Key]
        [Required]
        public Guid IdRolePermission { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        [Required]
        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
