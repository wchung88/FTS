import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as FindCards from '../store/FindCards';
import debounce from 'debounce';

interface ICardActionsProps {
    cardClicked: (card: FindCards.Card, userId: number) => void;
}

type CardProps = FindCards.Card & { selectedUserId:number }
    & ICardActionsProps;

export class Card extends React.Component<CardProps, {}> {
    public render() {
        return <div className="card">
            <div className="card-body">
                <img className="card-image" src={this.props.imageUrl} onClick={debounce(() => { this.props.cardClicked(this.props, this.props.selectedUserId); }, 500)} />
            </div>
        </div>;
    }
}
