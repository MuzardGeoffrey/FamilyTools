import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpHelperService {

  private readonly http = inject(HttpClient);

  public get<T>(url : string, params : string = "") : T | void {
    let result;
    if(this.http){
      this.http.get<T>(`${url}/${params}`).subscribe({
        next : response => {return response},
        error : error => console.error(error)  
      })
    }

    return result;
  }

  public post<T>(url : string, body : T) : T | void {
    let result;
    if(this.http){
      this.http.post<T>(url, body).subscribe({
        next : response => {return response},
        error : error => console.error(error)  
      })
    }

    return result;
  }

    public put<T>(url : string, body : T, params : string = "") : T | void {
    let result;
    if(this.http){
      this.http.put<T>(`${url}/${params}`, body).subscribe({
        next : response => {return response},
        error : error => console.error(error)  
      })
    }

    return result;
  }

  public delete(url : string, params : string = ""){
    let result;
    if(this.http){
      this.http.delete(`${url}/${params}`).subscribe({
        next : response => {return response},
        error : error => console.error(error)  
      })
    }

    return result;
  }
}
