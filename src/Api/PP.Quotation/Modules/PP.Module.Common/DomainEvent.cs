﻿namespace PP.Module.Common
{
	public abstract class DomainEvent
	{
		protected DomainEvent()
		{
			DateOccurred = DateTimeOffset.UtcNow;
		}

		public bool IsPublished { get; set; }
		public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
	}
}
