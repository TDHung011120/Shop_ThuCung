namespace Shop_ThuCung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TagContent")]
    public partial class TagContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ContentID { get; set; }

        [Required]
        [StringLength(50)]
        public string TagID { get; set; }
    }
}
