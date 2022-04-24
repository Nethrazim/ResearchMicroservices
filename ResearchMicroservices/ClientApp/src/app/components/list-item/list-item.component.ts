import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.css']
})
export class ListItemComponent implements OnInit {
  @Input() name: string;
  @Output() ItemSelectedEmitter: EventEmitter<string>;

  constructor() {
    this.ItemSelectedEmitter = new EventEmitter();
  }

  ngOnInit() {
  }

  onSelect() {
    this.ItemSelectedEmitter.emit(this.name);
  }
}
