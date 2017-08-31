import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as FindCards from '../store/FindCards';

interface IUserSelectorActionsProps {
    changeUser: (userId: string) => void;
}

type UserSelectorProps = FindCards.UsersState & IUserSelectorActionsProps;

export class UserSelector extends React.Component<UserSelectorProps, {}> {
    public render() {

        if (this.props.users) {
            return <div className="User-selector">
                User Selector:
                <select className="selectpicker" onChange={(event) => this.props.changeUser(event.target.value)}>
                    {this.props.users.map(user =>
                        <option value={user.userId} selected={this.props.selectedUserId === user.userId}>{user.name}</option>
                    )}
                </select>
            </div>;
        }

        return <div />;
    }
}
