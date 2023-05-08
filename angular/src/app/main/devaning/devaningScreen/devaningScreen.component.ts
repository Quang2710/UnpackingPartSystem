import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-devaningScreen',
  templateUrl: './devaningScreen.component.html',
  styleUrls: ['./devaningScreen.component.less']
})
export class DevaningScreenComponent implements OnInit {

  process: number = 5;

  constructor() { }

  ngOnInit() {
    this.fornumbersRange();
  }

  fornumbersRange() {
    let numRange: number[] = [];
    for (let i = 1; i <= 5; i++) {
      numRange.push(i);
    }
    return numRange;
  }


}
