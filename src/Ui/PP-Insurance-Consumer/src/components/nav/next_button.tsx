import { useSelector } from "react-redux";
import React from "react";
import { IWorkflowState } from "../../state/info/workflow-slice";
import { Button } from "devextreme-react";
const NextButton = () => {
  const worklfow = useSelector(
    (state: any) => state.workflow
  ) as IWorkflowState;

  if (worklfow.NextStep !== "") {
    return (
      <>
        <Button>Next</Button>
      </>
    );
  }

  return <></>;
};

export default NextButton;
