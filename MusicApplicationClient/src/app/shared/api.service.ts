import { Injectable } from '@angular/core';
import{HttpClient}from '@angular/common/http'
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl="https://localhost:5001/api/Songs";
  constructor(private http:HttpClient) { }

  postSong(data:any){
    return this.http.post<any>(this.baseUrl,data)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
  getSongs(){
    return this.http.get<any>(this.baseUrl)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
  updateSongs(data:any, id:number){
    return this.http.put<any>(this.baseUrl+"/"+id, data)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
  deleteSongs(id:number){
    return this.http.delete<any>(this.baseUrl+"/"+id)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
  searchSongs(search:string){
    let url= this.baseUrl+"/search?SongName="+search
    return this.http.get<any>(url)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
}
