import * as React from 'react';
import { NavLink, Link } from 'react-router-dom';
import { UserSelector } from './UserSelector'

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className='main-nav'>
                <div className='navbar navbar-inverse'>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink exact to={ '/' } activeClassName='active'>
                                <span className='glyphicon glyphicon-home'></span> Home
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={ '/findCard/General' } activeClassName='active'>
                                <span className='glyphicon glyphicon-education'></span> Find Card Game
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/findCard/Numeric'} activeClassName='active'>
                                <span className='glyphicon glyphicon-education'></span> Find Number Game
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/findCard/Letter'} activeClassName='active'>
                                <span className='glyphicon glyphicon-education'></span> Find Letter Game
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/learnCard'} activeClassName='active'>
                                <span className='glyphicon glyphicon-education'></span> Learning Cards
                            </NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>;
    }
}
