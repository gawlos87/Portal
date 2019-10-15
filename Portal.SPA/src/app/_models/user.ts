import { Photo } from './photo';

export interface User {
    // Podstawowe informacje
    id: number;
    username: string;
    gender: string;
    age: number;
    created: string;
    lastActive: string;
    city: string;
    country: string;
    // Info
    growth: string;
    eyeColor: string;
    hairColor: string;
    martialStatus: string;
    education: string;
    profession: string;
    children: string;
    languages: string;
    // O mnie
    motto: string;
    description: string;
    personality: string;
    lookinFor: string;
    // Pasje zainteresowania
    interests: string;
    freeTime: string;
    sport: string;
    movies: string;
    music: string;
    // Preferencje
    iLike: string;
    iDoNotLike: string;
    makesMeLaugh: string;
    itFeelsBestIn: string;
    friendWouldDectiptionMe: string;
    // Zdjęcia
    photos: Photo[];
    photoUrl: string;
}