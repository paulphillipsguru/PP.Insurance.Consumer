namespace PP.Module.QuoteManager.Quotes.Commands
{
    public class StartQuoteCommand : IRequest<StartQuoteCommandResponse>
    {
        public required string SeedCode { get; set; }
    }
}
