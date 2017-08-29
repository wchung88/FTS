import * as React from 'react';
import { NavMenu } from './NavMenu';

export class Layout extends React.Component<{}, {}> {
    public render() {
        return <div className='container-fluid'>
            <div className='row'>
                <div className=''>
                    <NavMenu />
                </div>
                <div className=''>
                    { this.props.children }
                </div>
            </div>
        </div>;
    }
}
