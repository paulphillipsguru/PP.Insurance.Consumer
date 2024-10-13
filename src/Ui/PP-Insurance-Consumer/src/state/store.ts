import { configureStore } from "@reduxjs/toolkit";
import quoteReducer from "./info/quote-slice";

export const store = configureStore({
  reducer: {
    quote: quoteReducer,
  },
});
