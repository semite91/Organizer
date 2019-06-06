import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';

import { Document } from '../business/Document';
import { DocumentService } from '../business/document.service';

@Component({
  selector: 'document-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {
  @Input("data") data: Document;

  isDisplay()
  {
    return this.data.Id != undefined && this.data.Id != 0;
  }

  constructor() { }

  ngOnInit() {
    this.data = new Document();
  }
}
