import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as FindCards from '../store/FindCards';

type CardProps = FindCards.Card;

export class Card extends React.Component<CardProps, {}> {
    public render() {
        return <div className="card">
            <div className="card-body">
                <h4 className="card-title">{this.props.title}</h4>
                <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
            </div>
        </div>;
    }
}
