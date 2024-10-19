import { QuotRefModel } from "./models/quoteRef-model";

export default class ServiceQuote {
  GenerateNewQuote = async (): Promise<QuotRefModel> => {
    var url = import.meta.env.VITE_QUESTION_HOST + "Quote/Start/DEFAULT_QUOTE";
    var fetchResult = await fetch(url);
    var responseResult = await fetchResult.json();
    return responseResult;
  };
}
