import { Tag } from './tag';

export class Tutorial {
    id:string;
    title:string;
    tutorialUrl:string;
    iconUrl:string;
    description:string;
    tags:Tag[];
    UserId:string;

    constructor(){
        this.tags = new Array() as Array<Tag>;
    }
}
