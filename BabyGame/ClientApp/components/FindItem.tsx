import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as FindItemStore from '../store/FindItem';
import * as WeatherForecasts from '../store/WeatherForecasts';

type FindItemProps =
    FindItemStore.FindItemState
    & typeof FindItemStore.actionCreators
    & RouteComponentProps<{}>;

class FindItem extends React.Component<FindItemProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        this.props.requestTiles();
    }

    componentWillReceiveProps() {
        // This method runs when incoming props (e.g., route params) change
        // this.props.requestTiles();
        console.log('calling');
    }

    public render() {
        return <div>
            <h1>Find Item</h1>

            <p>This is a simple example of a React component.</p>

            { this.renderTiles() }
        </div>;
    }

    private renderTiles() {
        return <div className='container'>
            {this.props.tiles.map(tile =>
                <span className='title'>{tile.title}</span>
            )}
        </div>;
    }
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.counter, // Selects which state properties are merged into the component's props
    FindItemStore.actionCreators                 // Selects which action creators are merged into the component's props
)(FindItem) as typeof FindItem;