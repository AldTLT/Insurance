import { IAuthorization } from './iauth';

export interface IAuthorizationState{
    auth: IAuthorization;
}

export const initialsAuthState: IAuthorizationState = {
    auth: null
};