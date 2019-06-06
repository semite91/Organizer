import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';


import { Document } from '../business/Document';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {

  constructor(private httpClient: HttpClient) {

  }

  getDocumentById(Id: number): Observable<Document> {  
    return this.httpClient.get<Document>('http://localhost:15858/api/document/get/' + Id);
  }

  getDocumentsByFolderId(folderId): Observable<Document[]> {  
    return this.httpClient.get<Document[]>('http://localhost:15858/api/document/getDocumentsByFolderId?folderid=' + folderId);
  }
}
