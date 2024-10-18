import { configureStore } from "@reduxjs/toolkit";
import quoteReducer from "./info/quote-slice";
import workflowReducer from "./info/workflow-slice";
export const store = configureStore({
  reducer: {
    quote: quoteReducer,
    workflow: workflowReducer,
  },
});
