import { fetch, addTask } from 'domain-task';
import { Reducer, Action } from 'redux';
import { AppThunkAction } from './';
import debounce from 'debounce';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface FindCardsState {
    needToSpeak: boolean;
    cards: Card[];
    desiredCard: Card;
    selectedCard: Card;
    answered: boolean;
    currentCategory: String;
}

export interface Card {
    title: string;
    imageUrl: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.
// Use @typeName and isActionType for type detection that works even after serialization/deserialization.

interface ReceiveCardsAction { type: 'RECEIVE_CARDS', cards: Card[], currentCategory: String }
interface RequestCardsAction { type: 'REQUEST_CARDS' }
interface SelectCardAction { type: 'SELECTED_CARD', selectedCard: Card }
interface ClearCardsAction { type: 'CLEAR_CARD' }

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestCardsAction | ReceiveCardsAction | SelectCardAction | ClearCardsAction;


// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestCards: (category: String): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        let fetchTask = fetch(`api/SampleData/Cards/${category}`)
            .then(response => response.json() as Promise<Card[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_CARDS', cards: data, currentCategory: category });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_CARDS' });
    },
    cardClick: (card: Card): AppThunkAction<KnownAction> => (dispatch, getState) => {
        dispatch({ type: 'SELECTED_CARD', selectedCard: card });
    },
    clearCards: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        dispatch({ type: 'CLEAR_CARD' });
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

export const reducer: Reducer<FindCardsState> = (state: FindCardsState, action: KnownAction) => {
    switch (action.type) {
        case 'RECEIVE_CARDS':
            return {
                cards: action.cards,
                needToSpeak: true,
                desiredCard: action.cards[Math.floor(Math.random() * action.cards.length)],
                selectedCard: state.selectedCard,
                answered: state.answered,
                currentCategory: action.currentCategory
            };
        case 'REQUEST_CARDS':
            return {
                cards: state.cards,
                desiredCard: state.desiredCard,
                selectedCard: state.selectedCard,
                needToSpeak: false,
                answered: false,
                currentCategory: state.currentCategory
            };
        case 'SELECTED_CARD':
            return {
                cards: state.cards,
                desiredCard: state.desiredCard,
                selectedCard: action.selectedCard,
                needToSpeak: false,
                answered: true,
                currentCategory: state.currentCategory
            };
        case 'CLEAR_CARD':
            return { cards: [], needToSpeak: false, desiredCard: state.desiredCard, selectedCard: state.selectedCard, answered: false, currentCategory: state.currentCategory };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    // For unrecognized actions (or in cases where actions have no effect), must return the existing state
    //  (or default initial state if none was supplied)
    return state || { cards: [], needToSpeak: false, desiredCard: null, selectedCard: null, answered: true, currentCategory: "" };
};
