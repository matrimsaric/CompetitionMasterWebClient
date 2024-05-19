import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json' , 
        'withCredentials': 'true'
    })  
};


@Injectable({
  providedIn: 'root'
})
export class SingleUserService {

    constructor(private _http: HttpClient) {

    }

    public getUserFromCode(codeToUse: string):  Observable<any>
    {
        // TODO need to get from settings
        var url = `http://localhost:5168/PrimeGetUser/GetUserFromCode/${codeToUse}`;
        let retObj = this._http.get(url);
        return retObj;
    }

    public getUserFromTag(tagToUse: string):  Observable<any>
    {
        // TODO need to get from settings
        var url = `http://localhost:5168/PrimeGetUser/GetUserFromTag/${tagToUse}`;
        let retObj = this._http.get(url);
        return retObj;
    }

    // public getRulesData(in_chapter: string, in_major: number, in_minor: number, in_image: string): Observable<any>
    // {
        
    //     var imgStr = "empty";
    //     if(in_image && in_image.length > 0){
    //         in_chapter = in_image;
    //     }
    //     // TODO Need to take this from settings
    //     var url = `http://localhost:64338/api/RulesLibrary/${in_chapter}/${in_major}/${in_minor}`;

    //     return this._http.get(url);

    // }

   




    

    

}
