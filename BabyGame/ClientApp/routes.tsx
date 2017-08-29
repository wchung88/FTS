import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import FindCard from './components/FindCard';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/findCard/:category?' component={FindCard} />
</Layout>;
