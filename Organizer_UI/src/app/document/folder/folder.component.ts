import { Component, OnInit, EventEmitter, Output } from '@angular/core';

import { NestedTreeControl, FlatTreeControl } from '@angular/cdk/tree';
import {BehaviorSubject, of as observableOf, Observable} from 'rxjs';
import {MatTreeNestedDataSource} from '@angular/material/tree';

import * as _ from 'lodash';

import { Folder } from '../business/Folder';
import { FolderService } from '../business/folder.service';

import { Document } from '../business/Document';
import { DocumentService } from '../business/document.service';

@Component({
  selector: 'document-folder',
  templateUrl: './folder.component.html',
  styleUrls: ['./folder.component.css']
})
export class FolderComponent implements OnInit {
  
  /*definitions*/
  isShown = true;
  isDocumentsShown = true;

  folderService: FolderService;
  documentService: DocumentService;

  tree: NestedTreeControl<Folder>;
  dataSource: MatTreeNestedDataSource<Folder>;
  dataChange: BehaviorSubject<Folder[]> = new BehaviorSubject<Folder[]>([]);

  get data(): Folder[] { return this.dataChange.value; }

  @Output() emitDocuments = new EventEmitter<Document[]>();
  @Output() emitDocumentsShown = new EventEmitter<boolean>();
  @Output() emitFoldersShown = new EventEmitter<boolean>();
  /*endregion*/

  /*events*/
  //#region Folder
  openProcessMode(node){
    node.isOnProcess = true;
    this.dataChange.next(this.data);
  };

   addFolder(node){
    function getOnProcesses(child: Folder){
        return child.isOnProcess;
    }

    let list = _.filter(node.Children, getOnProcesses);

    if(list.length == 0)
    {
      let item = this.folderService.setChildFromParent(node);
      node.Children.push(item);

      this.dataChange.next(this.data);
    }

    this.tree.expand(node);
  };

  detailFolder(node)
  {

  }

  deleteFolder(node){

  };

  saveFolder(node)
  {

  };

  moveFolder(event){
    console.log('move', event.item.data);
  }

  recursiveLoop(list, callback)
  {
    _.map(list, function(i) {
      var recursive = function(item) {  
          item = callback(item);
          
        if (item.Children) 
          item.Children  = _.map(item.Children, recursive);
        
          return item;
      }
      
      return recursive(i);
    });
  };

  toggle(isSelected)
  {
    function run(item){
      console.log(item, isSelected);

      item.selected = isSelected;

      return item;
    }

    return run;
  }

  selectFolder(folder)
  {
    this.documentService.getDocumentsByFolderId(folder.Id)
      .subscribe((response) => {
          this.emitDocuments.emit(response);
      });

    this.recursiveLoop(this.data, this.toggle(false))
    folder.selected = true;

    this.tree.expand(folder);

    this.dataChange.next(this.data);
  }

  changeDocumentsShow(isShown)
  {
    this.isDocumentsShown = isShown;
    this.emitDocumentsShown.emit(isShown);
  }

  setShown(is)
  {
    this.isShown = is;
    this.emitFoldersShown.emit(is);
  }
  //#endregion

  /*helpers*/
  hasChild(_: number, node: Folder) {
    return node.Children != null && node.Children.length > 0;
  }

  onProcess(_: number, node: Folder) {
  return node.isOnProcess;
}
/*endregion*/

  constructor(folderService: FolderService, _documentService: DocumentService) {
    this.documentService = _documentService;

    folderService.getTree()
          .subscribe(
            (response) => { 
              this.dataSource = new MatTreeNestedDataSource();
              this.dataChange.next(response);

              this.dataChange.subscribe(data => {
                this.dataSource.data = null;
                this.dataSource.data = data;
              });
            });

    function GetChildren(node: Folder): Observable<Folder[]> { 
      return observableOf(node.Children);
    }

    this.tree = new NestedTreeControl<Folder>(GetChildren);
   }

  ngOnInit() {

  }

}
