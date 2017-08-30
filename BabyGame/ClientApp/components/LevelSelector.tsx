import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';

interface ILevelSelectorActionsProps {
    changeLevel: (level: number) => void;
}

type LevelSelectorProps = ILevelSelectorActionsProps & {selectedLevel: number};

export class LevelSelector extends React.Component<LevelSelectorProps, {}> {
    public render() {
        return <div className="level-selector">
            Level Selector: 
            <select className="selectpicker" onChange={(event) => this.props.changeLevel(event.target.selectedIndex+1)}>
                <option value="1" selected={this.props.selectedLevel === 1}>Level 1</option>
                <option value="2" selected={this.props.selectedLevel === 2}>Level 2</option>
            </select>
        </div>;
    }
}
