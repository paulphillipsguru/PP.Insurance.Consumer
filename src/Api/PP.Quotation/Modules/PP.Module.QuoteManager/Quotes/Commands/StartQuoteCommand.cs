namespace PP.Module.QuoteManager.Quotes.Commands
{
    public class StartQuoteCommand : IRequest<string>
    {
        public required string SeedCode { get; set; }
    }
}
