import { Component, Injector, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'app-pcstore',
  templateUrl: './pcstore.component.html',
  styleUrls: ['./pcstore.component.less']
})
export class PcStoreComponent extends AppComponentBase implements OnInit {
  rowdata;
  constructor(
    injector: Injector,
  ) {
    super(injector)
  }

  ngOnInit() {
  }

}
