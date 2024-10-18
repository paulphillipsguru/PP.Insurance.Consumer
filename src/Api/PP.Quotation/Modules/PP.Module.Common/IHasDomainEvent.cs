namespace PP.Module.Common
{
	public interface IHasDomainEvent
	{
		public List<DomainEvent> DomainEvents { get; }
	}
}
