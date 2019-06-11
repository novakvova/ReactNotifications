using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shnaps.DAL.Entities
{
    [Table("tblUserProfiles")]
    public class UserProfile
    {
        [Key, ForeignKey("User")]
        public long Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public virtual DbUser User { get; set; }
    }
}
