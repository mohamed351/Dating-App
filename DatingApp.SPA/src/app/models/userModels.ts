

    export interface PhotoModel {
        id: number;
        url: string;
        description: string;
        addedTime: Date;
        isMain: boolean;
    }

    export interface UserModel {
        id: number;
        userName: string;
        phone: string;
        email: string;
        isDeleted: boolean;
        gender: number;
        created: Date;
        lastTimeActive: Date;
        age: number;
        introduction: string;
        city: string;
        country: string;
        photoUrl: string;
        knownAs?: any;
        photos: PhotoModel[];
    }

