import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup} from '@angular/forms';
import { Model } from './dashboard.model';
import { ApiService } from '../shared/api.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  formValue !: FormGroup;
  modelObj:Model =new Model();
  songData!:any;
  showAdd!:boolean;
  showUpdate!:boolean;
  invalidRating: boolean | undefined;
  checkRate:any;
  searchSong:string="";

  constructor(private formbuilder: FormBuilder,
    private api : ApiService,private toastr: ToastrService) { }
    checkfalse=false;

  ngOnInit(): void {
    this.formValue=this.formbuilder.group({
      songName:[''],
      artistName:[''],
      rating:[''],
      categoryId:[''],
      songUrl:[''],
      isFavourite:['']
    })
    this.getAllSongs();
  }

  Search()
{
   if(this.searchSong ==""){
     this.toastr.success("Search results.")
       return;
   }
   else{
   this.api.searchSongs(this.searchSong).subscribe(res=>{
     this.songData=res;

   })
   }
}
  clickAddSong(){
    this.formValue.reset();
    this.showAdd=true;
    this.showUpdate=false;
  }
  postSongDetails(){
    this.modelObj.songName=this.formValue.value.songName;
    this.modelObj.artistName=this.formValue.value.artistName;
    this.modelObj.songUrl=this.formValue.value.songUrl;
    this.modelObj.rating=+this.formValue.value.rating;
    this.modelObj.isFavourite=this.formValue.value.isFavourite?this.formValue.value.isFavourite:false;
    this.modelObj.categoryId=+this.formValue.value.categoryId;
    
    this.checkRate = Number(this.modelObj.rating);
    if(this.checkRate < 1 || this.checkRate > 5 )
    {
      this.invalidRating = true;
      this.toastr.warning("You can only rate the song from 1 to 5")
    }
    else{
    this.api.postSong(this.modelObj)
    .subscribe(res=>{
      console.log(res);
      this.toastr.success("Song added successfully!")
      let ref=document.getElementById('cancel')
      ref?.click();
      this.formValue.reset();
      this.getAllSongs();

    },
    err=>{
      this.toastr.error("Something went wrong.")
    })
  }
  }
  getAllSongs(){
    this.api.getSongs()
    .subscribe(res=>{
      this.songData=res;
    })
  }
  
  deleteSong(row:any){
    this.api.deleteSongs(row.id)
    .subscribe(res=>{
      this.toastr.success("Song deleted.");
      this.getAllSongs();
    })
  }
  onEdit(row:any){
    this.showAdd=false;
    this.showUpdate=true;
    this.modelObj.id=row.id;
    this.formValue.controls['songName'].setValue(row.songName);
    this.formValue.controls['artistName'].setValue(row.artistName);
    this.formValue.controls['songUrl'].setValue(row.songUrl);
    this.formValue.controls['rating'].setValue(row.rating);
    this.formValue.controls['isFavourite'].setValue(row.isFavourite);
    this.formValue.controls['categoryId'].setValue(row.categoryId);
  }
  updateSongDetails(){
    this.modelObj.songName=this.formValue.value.songName;
    this.modelObj.artistName=this.formValue.value.artistName;
    this.modelObj.songUrl=this.formValue.value.songUrl;
    this.modelObj.rating=+this.formValue.value.rating;
    this.modelObj.isFavourite=this.checkfalse;
    this.modelObj.categoryId=+this.formValue.value.categoryId;

    this.checkRate = Number(this.modelObj.rating);
    if(this.checkRate < 1 || this.checkRate > 5 )
    {
      this.invalidRating = true;
      this.toastr.warning("You can only rate the song from 1 to 5")
    }
    else{
    this.api.updateSongs(this.modelObj, this.modelObj.id)
    .subscribe(res=>{
      this.toastr.success("Updated successfully!");
      let ref=document.getElementById('cancel')
      ref?.click();
      this.formValue.reset();
      this.getAllSongs();
    })
  }
}
}
