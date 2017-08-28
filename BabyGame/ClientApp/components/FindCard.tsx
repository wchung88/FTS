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
        this.props.requestCards();
    }

    componentWillUnmount() {
        this.props.clearCards();
    }

    public render() {
        var itemToFind = '';

        if (this.props.desiredCard && this.props.spoken) {
            itemToFind = "Where's the " + this.props.desiredCard.title;
            window.speechSynthesis.speak(new SpeechSynthesisUtterance(itemToFind));
        }

        if (this.props.answered === true && this.props.desiredCard && this.props.selectedCard) {
            if (this.props.desiredCard.title === this.props.selectedCard.title) {
                window.speechSynthesis.speak(new SpeechSynthesisUtterance('Yes'));
                this.props.requestCards();
                return <div />;
            }
            else {
                itemToFind = "Where's the " + this.props.desiredCard.title;
                window.speechSynthesis.speak(new SpeechSynthesisUtterance('No'));
                window.speechSynthesis.speak(new SpeechSynthesisUtterance(itemToFind));
            }
        }

        return <div>
            <div className='container'>
                <p>{itemToFind}</p>
                <div className='card-columns'>
                    {this.props.cards.map(card =>
                        <Card imageUrl={card.imageUrl} title={card.title} cardClicked={this.props.cardClick} />
                    )}
                </div>
            </div>
        </div>;
    }
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.findCards, // Selects which state properties are merged into the component's props
    FindCards.actionCreators                 // Selects which action creators are merged into the component's props
)(FindCard) as typeof FindCard;