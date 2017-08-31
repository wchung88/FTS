import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as FindCards from '../store/FindCards';
import { Card } from './Card';
import { LevelSelector } from './LevelSelector'
import { UserSelector } from './UserSelector'

type FindCardProps =
    FindCards.FindCardsState
    & typeof FindCards.actionCreators
    & RouteComponentProps<{ category: string }>;

class FindCard extends React.Component<FindCardProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        this.props.requestCards(this.props.match.params.category, this.props.level, this.props.selectedUserId);
        this.props.requestUsers();
    }

    componentWillReceiveProps(nextProps: FindCardProps) {
        if (this.props.match.params.category !== nextProps.match.params.category || nextProps.hasLevelChanged === true) {
            this.props.requestCards(nextProps.match.params.category, nextProps.level, nextProps.selectedUserId);
        }
    }

    public render() {
        var itemToFind = '';
        var speechSynthesis = new SpeechSynthesisUtterance();
        // speechSynthesis.voice = window.speechSynthesis.getVoices()[this.props.voiceIndex];
        if (this.ShouldAskInitialQuestion()) {
            itemToFind = "Where's the " + this.props.desiredCard.title;
            speechSynthesis.text = itemToFind;
            window.speechSynthesis.speak(speechSynthesis);
        }

        if (this.props.answered === true && this.props.desiredCard && this.props.selectedCard) {
            if (this.props.desiredCard.title === this.props.selectedCard.title) {
                speechSynthesis.text = "Yes";
                window.speechSynthesis.speak(speechSynthesis);
                this.props.requestCards(this.props.match.params.category, this.props.level);
                return <div />;
            }
            else {
                itemToFind = "No, Where's the " + this.props.desiredCard.title;
                speechSynthesis.text = itemToFind;
                window.speechSynthesis.speak(speechSynthesis);
            }
        }

        return <div>
            <div className='container'>
                <p>{itemToFind}</p>
                <UserSelector changeUser={this.props.changeUser} selectedUserId={this.props.selectedUserId} users={this.props.users} />
                <LevelSelector changeLevel={this.props.changeLevel} selectedLevel={this.props.level} />
                <br />
                <div className='card-columns'>
                    {this.props.cards.map(card =>
                        <Card imageUrl={card.imageUrl} title={card.title} cardId={card.cardId} cardClicked={this.props.cardClick} selectedUserId={this.props.selectedUserId} />
                    )}
                </div>
            </div>
        </div>;
        // <VoiceSelector changeVoice={this.props.changeVoice} selectedIndex={this.props.voiceIndex} />
    }

    private ShouldAskInitialQuestion(): boolean {
        return this.props.desiredCard &&
            this.props.needToSpeak === true &&
            this.props.currentCategory === this.props.match.params.category &&
            this.props.hasLevelChanged === false;
    }
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.findCards, // Selects which state properties are merged into the component's props
    FindCards.actionCreators                 // Selects which action creators are merged into the component's props
)(FindCard) as typeof FindCard;