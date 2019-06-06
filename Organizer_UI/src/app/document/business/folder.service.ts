import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { Folder } from '../business/Folder';

@Injectable({
  providedIn: 'root'
})
export class FolderService {
  
  constructor(private httpClient: HttpClient) {

  }

  getChilds(ID: number): Observable<Folder[]> {  
    return this.httpClient.get<Folder[]>('http://localhost:15858/api/folder/get/' + ID);
  }

  getListByLevel(level: number): Observable<Folder[]>{
    return this.httpClient.get<Folder[]>('http://localhost:15858/api/folder/GetListByLevel?level=' + level);
  }

  getTree(): Observable<Folder[]>{
    return this.httpClient.get<Folder[]>('http://localhost:15858/api/folder/GetTree');
  }


  setChildFromParent(parent: Folder)
  {
    let child = new Folder();
    child.Name = parent.Name + " Çocuğu";
    child.ParentId = parent.Id;
    child.ChildIds = "";
    child.Children = [];
    child.Status = 1;

    return child;
  }

}
