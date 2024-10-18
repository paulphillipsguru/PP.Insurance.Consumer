import { createSlice } from "@reduxjs/toolkit";
export interface IWorkflowState {
  PreviousStep: string;
  CurrentStep: string;
  NextStep: string;
}

const initWorkflowState: IWorkflowState = {
  PreviousStep: "",
  CurrentStep: "Selection",
  NextStep: "",
};

const workflowSlice = createSlice({
  name: "workflow",
  initialState: initWorkflowState,
  reducers: {
    updateWorkflow(state, worfklow) {
      return {
        ...state,
        PreviousStep: worfklow.payload.PreviousStep,
        CurrentStep: worfklow.payload.CurrentStep,
        NextStep: worfklow.payload.NextStep,
      };
    },
  },
});

export const { updateWorkflow } = workflowSlice.actions;

export default workflowSlice.reducer;
