using System.ComponentModel.DataAnnotations;

namespace PP.Module.QuoteManager.Contract.Entities
{
	public partial class Seed
    {
        [Required]
        [StringLength(50)]
        [Key]
        public string SeedKey { get; set; } = String.Empty;

        [StringLength(2000)]
        public required string Format { get; set; }

        public virtual ICollection<SeedSegment> SeedSegmentSeeds { get; set; } = [];
    }
}
