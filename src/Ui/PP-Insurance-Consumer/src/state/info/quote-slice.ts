import { createSlice } from "@reduxjs/toolkit";
export interface IQuoteInfo {
  OccupationCode: string;
  OuccaptionTitle: string;
}

const initQuoteInfoState: IQuoteInfo = {
  OccupationCode: "",
  OuccaptionTitle: "",
};

const quoteSlice = createSlice({
  name: "quote",
  initialState: initQuoteInfoState,
  reducers: {
    updateQuote(state, occupation) {
      return {
        ...state,
        OccupationCode: occupation.payload.code,
        OuccaptionTitle: occupation.payload.name,
      };
    },
  },
});

export const { updateQuote } = quoteSlice.actions;

export default quoteSlice.reducer;
