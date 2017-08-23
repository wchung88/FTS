import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as FindCards from '../store/FindCards';
import { Card } from './Card';

type FindCardProps =
    FindCards.FindCardsState
    & typeof FindCards.actionCreators
    & RouteComponentProps<{}>;

class FindCard extends React.Component<FindCardProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        console.log('calling 1');
        this.props.requestCards();
    }

    componentWillReceiveProps() {
        // This method runs when incoming props (e.g., route params) change
        // this.props.requestTiles();
        console.log('calling');
    }

    public render() {
        return <div>
            <h1>Find Card</h1>
            <p>This is a simple example of a React component.</p>
            { this.renderCards() }
        </div>;
    }

    private renderCards() {
        return <div className='container'>
            <div className='card-columns'>
                {this.props.cards.map(card =>
                    <Card title={card.title} />
                )}
            </div>
        </div>;
    }
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.findCards, // Selects which state properties are merged into the component's props
    FindCards.actionCreators                 // Selects which action creators are merged into the component's props
)(FindCard) as typeof FindCard;