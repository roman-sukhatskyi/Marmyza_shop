using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace MarmyzaShop.Models.Base
{
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DefaultDateTimeValue("Now")]
        public DateTime? CreatedOn { get; set; }

        [DefaultDateTimeValue("Now")]
        public DateTime? ModifiedOn { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
