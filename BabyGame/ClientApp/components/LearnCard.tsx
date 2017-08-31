import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as LearnCards from '../store/LearnCards';
import { Card } from './Card';
import { LevelSelector } from './LevelSelector'

type LearnCardProps =
    LearnCards.LearnCardsState
    & typeof LearnCards.actionCreators
    & RouteComponentProps<{}>;

class LearnCard extends React.Component<LearnCardProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        this.props.requestLearningCard({ cardId: 0, imageUrl: '', title: '' });
    }

    public render() {
        if (this.props.card) {
            var speechSynthesis = new SpeechSynthesisUtterance();
            speechSynthesis.text = this.props.card.title;
            window.speechSynthesis.speak(speechSynthesis);
            return <div>
                <div className='container'>
                    <div className='card-columns'>
                        <Card imageUrl={this.props.card.imageUrl} title={this.props.card.title} cardId={this.props.card.cardId} cardClicked={this.props.requestLearningCard} selectedUserId={1} />
                    </div>
                </div>
            </div>;
        }

        return <div />;
        // <VoiceSelector changeVoice={this.props.changeVoice} selectedIndex={this.props.voiceIndex} />
    }
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.learnCards, // Selects which state properties are merged into the component's props
    LearnCards.actionCreators                 // Selects which action creators are merged into the component's props
)(LearnCard) as typeof LearnCard;