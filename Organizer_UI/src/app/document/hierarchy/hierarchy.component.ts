import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';

import { Document } from '../business/Document';
import { DocumentService } from '../business/document.service';

@Component({
  selector: 'document-hierarchy',
  templateUrl: './hierarchy.component.html',
  styleUrls: ['./hierarchy.component.css'],
  animations: [
    trigger('notebook', [
      state('open', style({ transform: 'rotate(0)', opacity: 0 })),
      state('close', style({ transform: 'rotate(-360deg)', opacity: 1 })),
      transition('close => open', animate('2000ms ease-out')),
      transition('open => close', animate('2000ms ease-in'))
    ])]
})

export class HierarchyComponent implements OnInit {
  /*search*/
  headerContentStyle = { 'display': 'block' };
  
  searchInput = '';
  isSearchBoxShown = false;
  @ViewChild("searchInputEle") searchInputEle: ElementRef;
  
  isNotebookEnabled = 'open';

  isFoldersShown = true;

  documentService: DocumentService;

  isDocumentsShown = true;
  documents: Document[];  
  document: Document;

  isFileShown = true;

    //#region Events
     triggerSearchBox(){
      this.isSearchBoxShown = !this.isSearchBoxShown;

      if(this.isSearchBoxShown)
        this.headerContentStyle = { 'display': 'block' };
      else
        this.headerContentStyle = { 'display': 'none' };

      this.searchInputEle.nativeElement.focus();
    }

    search(event) {
      if((event == undefined ? true : event.keyCode == 13) && this.searchInput.length >= 3) {
        //search
      }
      else if (event.keyCode == 27)
      this.isSearchBoxShown = false;
    }

    openOCR(){

    }

    openGallery(){
      
    }
    //#endregion

    selectDocument(document)
    {
      this.documentService.getDocumentById(document.Id)
        .subscribe(
          (response) => { 
            this.document = response;
          });
    }

    getDocuments(documents: Document[])
    {
      this.documents = documents;
    }

    setDocumentsShown(is: boolean)
    {
      this.isDocumentsShown = is;
    }

    setFoldersShown(is: boolean)
    {
      this.isFoldersShown = is;
    }

    constructor(_documentService: DocumentService) {
      this.documentService = _documentService;
    }
  
    ngOnInit() {

    }
  

}
