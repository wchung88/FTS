import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import FindLetter from './components/FindLetter';
import FindCard from './components/FindCard';
import FindNumber from './components/FindNumber';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/findCard' component={FindCard} />
    <Route path='/findNumber' component={FindNumber} />
    <Route path='/findLetter' component={FindLetter} />
</Layout>;
