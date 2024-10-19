import { useSelector } from "react-redux";
import { IQuoteInfo } from "../state/info/quote-slice";
const QuoteInfo = () => {
  const occupationCode = useSelector((state: any) => state.quote) as IQuoteInfo;

  return (
    <>
      <div className="lg:col-start-3 lg:row-end-1">
        <h2 className="sr-only">Summary</h2>
        <div className="rounded-lg bg-gray-50 shadow-sm ring-1 ring-gray-900/5">
          <dl className="flex flex-wrap">
            <div className="flex-auto pl-6 pt-6">
              <dt className="font-semibold leading-6 text-gray-900">
                Quote Reference
              </dt>
              <dd className="mt-1 text-base leading-6 text-gray-900">
                {occupationCode.QuoteRef}
              </dd>

              <dt className="font-semibold leading-6 text-gray-900">
                Your Occupation
              </dt>
              <dd className="mt-1 text-base leading-6 text-gray-900">
                {occupationCode.OuccaptionTitle} (
                {occupationCode.OccupationCode})
              </dd>
            </div>
          </dl>
        </div>
      </div>
    </>
  );
};

export default QuoteInfo;
