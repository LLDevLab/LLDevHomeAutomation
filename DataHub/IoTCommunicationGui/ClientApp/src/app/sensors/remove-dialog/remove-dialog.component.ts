import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-remove-dialog',
  templateUrl: './remove-dialog.component.html',
  styleUrls: ['./remove-dialog.component.css']
})
export class RemoveDialogComponent {

  elementName: string;

  constructor(@Inject(MAT_DIALOG_DATA) data: any)
  {
    this.elementName = data.elementName;
  }
}
