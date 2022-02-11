export class Model{
    id:number=0;
    songName:string='';
    artistName:string='';
    songUrl:string='';
    categoryId:number=0;
    rating:number=0;
    isFavourite:boolean=false;
    createdAt:Date=new Date();
    modifiedAt:Date=new Date();
}