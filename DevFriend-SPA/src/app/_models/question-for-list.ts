import { Tag } from './tag';

export class QuestionForList {
    id:string;
    heading:string;
    tags:Tag[]=[];
    userId:string; 
    description:string;
    createdDate:Date;
    resolved:boolean;

    
}
