import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  public names: Array<string> = new Array<string>('asd', 'bsd', 'csd');

  constructor() { }

  ngOnInit() {
  }

  addNames(name: HTMLInputElement, anothername: HTMLInputElement) {
    this.names.push(name.value);
    this.names.push(anothername.value);
    name.value = '';
    anothername.value = '';
  }

  getSortedNames(): Array<string> {
    return this.names.sort();
  }

  OnListItemSelected() {
    alert("SUPERB");
  }

}
