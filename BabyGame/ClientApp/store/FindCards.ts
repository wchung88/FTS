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
    voiceIndex: number;
    level: number;
    hasLevelChanged: boolean;
    selectedUserId: number;
    users: User[];
}

export interface UsersState {
    selectedUserId: number;
    users: User[];
}

export interface Card {
    title: string;
    imageUrl: string;
    cardId: number;
}

export interface User {
    name: string;
    userId: number;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.
// Use @typeName and isActionType for type detection that works even after serialization/deserialization.

interface ReceiveCardsAction { type: 'RECEIVE_CARDS', cards: Card[], currentCategory: String }
interface RequestCardsAction { type: 'REQUEST_CARDS' }
interface SelectCardAction { type: 'SELECTED_CARD', selectedCard: Card }
interface ClearCardsAction { type: 'CLEAR_CARD' }
interface ChangeVoiceAction { type: 'CHANGE_VOICE', selectedIndex: number }
interface ChangeLevelAction { type: 'CHANGE_LEVEL', level: number }
interface RetrieveUsersAction { type: 'RETRIEVE_USERS' }
interface ReceieveUsersAction { type: 'RECEIVE_USERS', users: User[] }
interface SelectUsersAction { type: 'SELECT_USER', userId: number }

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestCardsAction | ReceiveCardsAction | SelectCardAction | ClearCardsAction | ChangeVoiceAction | ChangeLevelAction | RetrieveUsersAction | ReceieveUsersAction | SelectUsersAction;


// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestCards: (category: String, level: number, userId: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        let fetchTask = fetch(`api/SampleData/Cards/${category}/${level}/${userId}`)
            .then(response => response.json() as Promise<Card[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_CARDS', cards: data, currentCategory: category });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_CARDS' });
    },
    cardClick: (card: Card, userId: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let desiredCard = getState().findCards.desiredCard;
        let urlPath = card.cardId == desiredCard.cardId ? "correct" : "incorrect";
        let fetchTask = fetch(`api/SampleData/Card/${desiredCard.cardId}/${urlPath}/${userId}`, {
            method: "post",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        }).then(() => dispatch({ type: 'SELECTED_CARD', selectedCard: card }));
        addTask(fetchTask);
    },
    clearCards: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        dispatch({ type: 'CLEAR_CARD' });
    },
    changeVoice: (selectedIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        dispatch({ type: 'CHANGE_VOICE', selectedIndex: selectedIndex });
    },
    changeLevel: (level: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        dispatch({ type: 'CHANGE_LEVEL', level: level });
    },
    requestUsers: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`api/SampleData/Users`)
            .then(response => response.json() as Promise<User[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_USERS', users: data });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'RETRIEVE_USERS' });
    },
    changeUser: (userId: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        dispatch({ type: 'SELECT_USER', userId: +userId });
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
                currentCategory: action.currentCategory,
                voiceIndex: state.voiceIndex,
                level: state.level,
                hasLevelChanged: false,
                users: state.users,
                selectedUserId: state.selectedUserId
            };
        case 'REQUEST_CARDS':
            return {
                cards: state.cards,
                desiredCard: state.desiredCard,
                selectedCard: state.selectedCard,
                needToSpeak: false,
                answered: false,
                currentCategory: state.currentCategory,
                voiceIndex: state.voiceIndex,
                level: state.level,
                hasLevelChanged: false,
                users: state.users,
                selectedUserId: state.selectedUserId
            };
        case 'SELECTED_CARD':
            return {
                cards: state.cards,
                desiredCard: state.desiredCard,
                selectedCard: action.selectedCard,
                needToSpeak: false,
                answered: true,
                currentCategory: state.currentCategory,
                voiceIndex: state.voiceIndex,
                level: state.level,
                hasLevelChanged: false,
                users: state.users,
                selectedUserId: state.selectedUserId
            };
        case 'CLEAR_CARD':
            return {
                cards: [],
                needToSpeak: false,
                desiredCard: state.desiredCard,
                selectedCard: state.selectedCard,
                answered: false,
                currentCategory: state.currentCategory,
                voiceIndex: state.voiceIndex,
                level: state.level,
                hasLevelChanged: false,
                users: state.users,
                selectedUserId: state.selectedUserId
            };
        case 'CHANGE_VOICE':
            return {
                cards: state.cards,
                needToSpeak: state.needToSpeak,
                desiredCard: state.desiredCard,
                selectedCard: state.selectedCard,
                answered: state.answered,
                currentCategory: state.currentCategory,
                voiceIndex: action.selectedIndex,
                level: state.level,
                hasLevelChanged: false,
                users: state.users,
                selectedUserId: state.selectedUserId
            }
        case 'CHANGE_LEVEL':
            return {
                cards: state.cards,
                needToSpeak: state.needToSpeak,
                desiredCard: state.desiredCard,
                selectedCard: state.selectedCard,
                answered: state.answered,
                currentCategory: state.currentCategory,
                voiceIndex: state.voiceIndex,
                level: action.level,
                hasLevelChanged: true,
                users: state.users,
                selectedUserId: state.selectedUserId
            }
        case 'RECEIVE_USERS':
            return {
                cards: state.cards,
                needToSpeak: state.needToSpeak,
                desiredCard: state.desiredCard,
                selectedCard: state.selectedCard,
                answered: state.answered,
                currentCategory: state.currentCategory,
                voiceIndex: state.voiceIndex,
                level: state.level,
                hasLevelChanged: state.hasLevelChanged,
                users: action.users,
                selectedUserId: state.selectedUserId
            };
        case 'RETRIEVE_USERS':
            return {
                cards: state.cards,
                needToSpeak: state.needToSpeak,
                desiredCard: state.desiredCard,
                selectedCard: state.selectedCard,
                answered: state.answered,
                currentCategory: state.currentCategory,
                voiceIndex: state.voiceIndex,
                level: state.level,
                hasLevelChanged: state.hasLevelChanged,
                users: state.users,
                selectedUserId: state.selectedUserId
            };
        case 'SELECT_USER':
            return {
                cards: state.cards,
                needToSpeak: state.needToSpeak,
                desiredCard: state.desiredCard,
                selectedCard: state.selectedCard,
                answered: state.answered,
                currentCategory: state.currentCategory,
                voiceIndex: state.voiceIndex,
                level: state.level,
                hasLevelChanged: state.hasLevelChanged,
                users: state.users,
                selectedUserId: action.userId
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    // For unrecognized actions (or in cases where actions have no effect), must return the existing state
    //  (or default initial state if none was supplied)
    return state || { cards: [], needToSpeak: false, desiredCard: null, selectedCard: null, answered: true, currentCategory: "", voiceIndex: 0, level: 1, hasLevelChanged: false, users: [], selectedUserId: 1 };
};
