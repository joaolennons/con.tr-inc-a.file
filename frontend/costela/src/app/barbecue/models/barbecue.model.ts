import { Participant } from './participant.model';

export class Barbecue {
    id: string;
    date: Date;
    updateDate: Date;
    description: string;
    totalParticipants: number;
    totalAmount: number;
    totalRaised: number;
    participants: Array<Participant>;

    constructor() {

    }
}
