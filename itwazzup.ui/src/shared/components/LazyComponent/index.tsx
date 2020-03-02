/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable react/display-name */
/* eslint-disable @typescript-eslint/explicit-function-return-type */
import React, { Suspense, ReactElement } from 'react';
const LazyComponent = (Component: any) => (props: any): ReactElement => (
  <Suspense fallback={<></>}>
    <Component {...props} />
  </Suspense>
);
export default LazyComponent;
