import BreadCumb from "./components/nav/bread-nav";
import OccupationSearch from "./components/occupation-search";
import QuoteInfo from "./components/quote-info";
import NextButton from "./components/nav/next_button";
import React from "react";
function App() {
  return (
    <>
      <div className="container mx-auto  h-screen m-10">
        <BreadCumb />

        <div className="mx-auto w-full max-w-7xl grow lg:flex xl:px-2 m-10">
          {/* Left sidebar & main wrapper */}
          <div className="flex-1 xl:flex">
            <div className="px-4 py-6 sm:px-6 lg:pl-8 xl:flex-1 xl:pl-6">
              <OccupationSearch />
            </div>
          </div>

          <div className="shrink-0 border-t border-gray-200 px-4 py-6 sm:px-6 lg:w-96 lg:border-l lg:border-t-0 lg:pr-8 xl:pr-6">
            {/* Right column area */}
            <QuoteInfo />
          </div>
        </div>
        <div className="mx-auto w-full max-w-7xl grow lg:flex xl:px-2 m-10">
          <NextButton />
        </div>
      </div>
    </>
  );
}

export default App;
