using System.ComponentModel.DataAnnotations;

namespace PP.Module.QuoteManager.Contract.Entities;

public partial class SeedSegment
{
	[Required]
	[Key]
	public int Id { get; set; }

	[StringLength(50)]
	public string SeedKey { get; set; } = String.Empty;

	public virtual Seed SeedSegmentSeed { get; set; } = null!;

	[StringLength(50)]
	public string SeekCode { get; set; } = String.Empty;

	public int Threshold { get; set; }

	public int SeedValue { get; set; }
}
