import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-nav-menu-item',
  templateUrl: './nav-menu-item.component.html',
  styleUrls: ['./nav-menu-item.component.css']
})
export class NavMenuItemComponent implements OnInit {
  @Input() slug: string;
  @Input() title: string;

  @Output() onNavMenuItemClicked: EventEmitter<string>;

  constructor() {
    this.onNavMenuItemClicked = new EventEmitter<string>();
  }

  ngOnInit() {
  }

  onMenuItemClick(): boolean {
    this.onNavMenuItemClicked.emit(this.slug);
    return false;
  }

}
