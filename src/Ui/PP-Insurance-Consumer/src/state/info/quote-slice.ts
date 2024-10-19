import { createSlice } from "@reduxjs/toolkit";
import ServiceQuote from "../../services/quote/quote-service";

export interface IQuoteInfo {
  QuoteRef: string;
  OccupationCode: string;
  OuccaptionTitle: string;
}

let initQuoteInfoState: IQuoteInfo = {
  QuoteRef: "",
  OccupationCode: "",
  OuccaptionTitle: "",
};

var serviceQuote = new ServiceQuote();
var quote = sessionStorage.getItem("Quote");

if (quote === null) {
  var newQuoteRef = await serviceQuote.GenerateNewQuote();
  initQuoteInfoState.QuoteRef = newQuoteRef.quoteRef;
  sessionStorage.setItem("Quote", JSON.stringify(initQuoteInfoState));
} else {
  initQuoteInfoState = JSON.parse(quote);
}

const quoteSlice = createSlice({
  name: "quote",
  initialState: initQuoteInfoState,
  reducers: {
    updateQuote(state, occupation) {
      var result = {
        ...state,
        OccupationCode: occupation.payload.code,
        OuccaptionTitle: occupation.payload.name,
      };
      sessionStorage.setItem("Quote", JSON.stringify(result));
      return result;
    },
  },
});

export const { updateQuote } = quoteSlice.actions;

export default quoteSlice.reducer;
