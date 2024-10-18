using System.Text.RegularExpressions;

namespace PP.Module.QuoteManager.Core;
public class PolicyNumberGenerator
{
	private Dictionary<string, int> sequenceCounters = new Dictionary<string, int>();
	private readonly Dictionary<string, int> sequenceThresholds = new Dictionary<string, int>();
	private readonly string format;

	public PolicyNumberGenerator(string formula, Dictionary<string, int> thresholds,ref Dictionary<string,int> sequence)
	{
		format = formula;
		sequenceCounters = sequence;
		sequenceThresholds = thresholds;

		
	}

	public string GeneratePolicyNumber()
	{
		string result = format;

		// Replace date placeholders with the current date
		result = result.Replace("@YYYY", DateTime.Now.ToString("yyyy"))
					   .Replace("@MM", DateTime.Now.ToString("MM"))
					   .Replace("@DD", DateTime.Now.ToString("dd"));

		// Handle SEQ counters dynamically
		result = ReplaceSequenceCounters(result);

		return result.Replace("[", "").Replace("]", "");
	}

	public string GetConcatenatedValuesInBrackets()
	{
		string result = format;

		// Replace date placeholders with the current date
		result = result.Replace("@YYYY", DateTime.Now.ToString("yyyy"))
					   .Replace("@MM", DateTime.Now.ToString("MM"))
					   .Replace("@DD", DateTime.Now.ToString("dd"));

		// Use a regex to find and extract content within square brackets []
		string concatenatedValues = string.Empty;
		var matches = Regex.Matches(result, @"\[(.*?)\]");

		foreach (Match match in matches)
		{
			string content = match.Groups[1].Value; // Extract the content inside []

			// Remove any SEQ placeholders (e.g., #SEQ1, #SEQ2)
			content = Regex.Replace(content, @"#SEQ\d+", string.Empty);

			// Concatenate the remaining content
			concatenatedValues += content;
		}

		return concatenatedValues;
	}

	private string ReplaceSequenceCounters(string input)
	{
		// Find all sequence placeholders dynamically (e.g., #SEQ1, #SEQ2, #SEQ3, ...)
		var seqMatches = Regex.Matches(input, @"#SEQ(\d+)");
		IncrementCounters(seqMatches);
		// Iterate through each SEQ placeholder found in the format
		foreach (Match match in seqMatches)
		{
			string seqKey = match.Value; // e.g., #SEQ1

			if (!sequenceCounters.ContainsKey(seqKey))
				continue;

			// Replace the placeholder with the current counter value
			input = input.Replace(seqKey, sequenceCounters[seqKey].ToString());
		}

		
		

		return input;
	}

	private void IncrementCounters(MatchCollection seqMatches)
	{
		// Process each sequence number from the last to the first
		for (int i = seqMatches.Count - 1; i >= 0; i--)
		{
			string seqKey = seqMatches[i].Value;

			// Increment the sequence counter
			sequenceCounters[seqKey]++;

			// Check if the counter has reached its threshold
			if (sequenceCounters[seqKey] > sequenceThresholds[seqKey])
			{
				// Reset the current counter and move up to the previous one
				sequenceCounters[seqKey] = 1;

				// Continue incrementing the previous sequence in the loop
				// If the previous one needs to increment, the loop will handle it
			}
			else
			{
				// If we incremented a sequence without reaching the threshold, break
				break;
			}
		}
	}
}
