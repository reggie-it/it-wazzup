/* eslint-disable @typescript-eslint/explicit-function-return-type */
import { Route, Switch } from 'react-router-dom';
import React, { ReactElement } from 'react';
import LazyLoad from './shared/components/LazyComponent';
import Menu from './components/menu/menu.component';

const Campaign = React.lazy(() =>
  import('./components/campaign/campaign.component')
);
const Home = React.lazy(() => import('./components/home/home.component'));
const CampaignItems = React.lazy(() => import('./components/campaignItems/campaignItems/campaignItems.component'));

export enum RouteType {
  Root = '/',
  Home = '/home',
  Campaign = '/campaign',
  CampaignItems = '/campaignItems'
}

const Routes = (): ReactElement => {
  return (
    <>
      <Menu />
      <Switch>
        <Route exact path={RouteType.Root} component={LazyLoad(CampaignItems)} />
        {/* <Route exact path={RouteType.Root} component={LazyLoad(Home)} /> */}
        <Route exact path={RouteType.Campaign} component={LazyLoad(Campaign)} />
      </Switch>
    </>
  );
};

export default Routes;
