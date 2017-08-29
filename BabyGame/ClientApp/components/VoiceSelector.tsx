import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';

interface IVoiceSelectorActionsProps {
    changeVoice: (selectedIndex: number) => void;
}

type VoiceSelectorProps = IVoiceSelectorActionsProps & {selectedIndex: number};

export class VoiceSelector extends React.Component<VoiceSelectorProps, {}> {
    public render() {
        var voices = window.speechSynthesis.getVoices();

        return <div className="voice-selector">
            <select className="selectpicker" onChange={(event) => this.props.changeVoice(event.target.selectedIndex)}>
                {voices.map((voice, index) =>
                    <option value={index} selected={this.props.selectedIndex === index}>{voice.name}</option>
                )}
            </select>
        </div>;
    }
}
