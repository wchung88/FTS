import { fetch, addTask } from 'domain-task';
import { Reducer, Action } from 'redux';
import { AppThunkAction } from './';
import debounce from 'debounce';
import { Card } from './FindCards';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface LearnCardsState {
    card: Card;
    selectedUserId: number;
    users: User[];
}

export interface User {
    name: string;
    userId: number;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.
// Use @typeName and isActionType for type detection that works even after serialization/deserialization.

interface ReceiveLearningCardAction { type: 'RECEIVE_LEARNING_CARD', card: Card }
interface RequestLearningCardAction { type: 'REQUEST_LEARNING_CARD' }
interface RequestLearningUsersAction { type: 'REQUEST_LEARNING_USERS' }
interface ReceiveLearningUsersAction { type: 'RECEIVE_LEARNING_USERS', users: User[] }
interface SelectLearningUserAction { type: 'SELECT_LEARNING_USER', userId: number }


// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = ReceiveLearningCardAction | RequestLearningCardAction | RequestLearningUsersAction | ReceiveLearningUsersAction | SelectLearningUserAction


// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestLearningCard: (currentCard: Card, userId: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`api/SampleData/LearningCards/${currentCard.cardId}/${userId}`)
            .then(response => response.json() as Promise<Card>)
            .then(data => {
                dispatch({ type: 'RECEIVE_LEARNING_CARD', card: data });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_LEARNING_CARD' });
    },
    requestUsers: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`api/SampleData/Users`)
            .then(response => response.json() as Promise<User[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_LEARNING_USERS', users: data });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_LEARNING_USERS' });
    },
    changeUser: (userId: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`api/SampleData/LearningCards/0/${userId}`)
            .then(response => response.json() as Promise<Card>)
            .then(data => {
                dispatch({ type: 'RECEIVE_LEARNING_CARD', card: data });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'SELECT_LEARNING_USER', userId: +userId });
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

export const reducer: Reducer<LearnCardsState> = (state: LearnCardsState, action: KnownAction) => {
    switch (action.type) {
        case 'RECEIVE_LEARNING_CARD':
            return {
                card: action.card,
                selectedUserId: state.selectedUserId,
                users: state.users
            };
        case 'REQUEST_LEARNING_CARD':
            return {
                card: state.card,
                selectedUserId: state.selectedUserId,
                users: state.users
            };
        case 'REQUEST_LEARNING_USERS':
            return {
                card: state.card,
                selectedUserId: state.selectedUserId,
                users: state.users
            };
        case 'RECEIVE_LEARNING_USERS':
            return {
                card: state.card,
                selectedUserId: state.selectedUserId,
                users: action.users
            };
        case 'SELECT_LEARNING_USER':
            return {
                card: state.card,
                selectedUserId: action.userId,
                users: state.users
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    // For unrecognized actions (or in cases where actions have no effect), must return the existing state
    //  (or default initial state if none was supplied)
    return state || { card: null, selectedUserId: 1, users: [] };
};
