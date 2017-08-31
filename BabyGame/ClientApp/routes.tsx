import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import FindCard from './components/FindCard';
import LearnCard from './components/LearnCard';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/findCard/:category?' component={FindCard} />
    <Route path='/learnCard' component={LearnCard} />
</Layout>;
