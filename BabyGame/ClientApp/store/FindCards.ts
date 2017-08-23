import { fetch, addTask } from 'domain-task';
import { Reducer, Action } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface FindCardsState {
    cards: Card[];
}

export interface Card {
    title: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.
// Use @typeName and isActionType for type detection that works even after serialization/deserialization.

interface ReceiveCardsAction { type: 'RECEIVE_CARDS', cards: Card[] }
interface IncrementCountAction { type: 'INCREMENT_COUNT' }


// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = IncrementCountAction | ReceiveCardsAction;


// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestCards: (): AppThunkAction<ReceiveCardsAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        let fetchTask = fetch(`api/SampleData/Cards`)
            .then(response => response.json() as Promise<Card[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_CARDS', cards: data });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

export const reducer: Reducer<FindCardsState> = (state: FindCardsState, action: KnownAction) => {
    switch (action.type) {
        case 'RECEIVE_CARDS':
            return {
                cards: action.cards
            };
        case 'INCREMENT_COUNT':
            return { cards: state.cards };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    // For unrecognized actions (or in cases where actions have no effect), must return the existing state
    //  (or default initial state if none was supplied)
    return state || { cards: [] };
};
