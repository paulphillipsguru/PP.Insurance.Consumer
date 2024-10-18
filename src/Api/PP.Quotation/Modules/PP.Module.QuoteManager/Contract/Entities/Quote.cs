using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Module.QuoteManager.Contract.Entities
{
    public partial class Quote
    {
        [Required]
        [StringLength(255)]
        [Key]
        public string QuoteRef { get; set; } = String.Empty;

        public DateTime DateCreated { get; set; }
    }
}
