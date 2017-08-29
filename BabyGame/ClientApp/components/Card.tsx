import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as FindCards from '../store/FindCards';
import debounce from 'debounce';

interface ICardActionsProps {
    cardClicked: (card: FindCards.Card) => void;
}

type CardProps = FindCards.Card
    & ICardActionsProps;

export class Card extends React.Component<CardProps, {}> {
    public render() {
        return <div className="card">
            <div className="card-body">
                <h1 className="card-title">{this.props.title}</h1>
                <img className="card-image" src={this.props.imageUrl} onClick={debounce(() => {this.props.cardClicked(this.props);}, 500)} />
            </div>
        </div>;
    }
}
