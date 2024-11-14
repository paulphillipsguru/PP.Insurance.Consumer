import { useSelector } from "react-redux";

import { Autocomplete } from "devextreme-react/autocomplete";
import CustomStore from "devextreme/data/custom_store";
import { useDispatch } from "react-redux";
import { updateQuote, IQuoteInfo } from "../state/info/quote-slice";
import { updateWorkflow, IWorkflowState } from "../state/info/workflow-slice";
const occupationSearchStore = new CustomStore({
  key: "code",
  useDefaultSearch: true,
  load: (loadOptions) => {
    return fetch(
      import.meta.env.VITE_QUESTION_HOST +
        "Occupation/?Filter=" +
        JSON.stringify(loadOptions["filter"])
    )
      .then((response) => response.json())
      .then((data) => ({
        data: data.occupationRecords,
      }))
      .catch(() => {
        throw new Error("Data Loading Error");
      });
  },
});
const OccupationSearch = () => {
  const dispatch = useDispatch();
  const quote = useSelector((state: any) => state.quote) as IQuoteInfo;
  const workflow = useSelector(
    (state: any) => state.workflow
  ) as IWorkflowState;
  return (
    <>
      <Autocomplete
        className="m-10 overflow-hidden rounded-lg bg-white shadow h-20"
        placeholder="Your Occupation"
        defaultValue={quote.OuccaptionTitle}
        dataSource={occupationSearchStore}
        onItemClick={(e: any) => {
          dispatch(updateQuote(e.itemData));
          var wFlow = { ...workflow, NextStep: "asasdasd" };

          dispatch(updateWorkflow(wFlow));
        }}
        valueExpr="name"
      />
    </>
  );
};

export default OccupationSearch;
