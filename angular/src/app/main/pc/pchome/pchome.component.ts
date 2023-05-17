import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
  selector: 'app-pchome',
  templateUrl: './pchome.component.html',
  styleUrls: ['./pchome.component.less']
})
export class PcHomeComponent extends AppComponentBase implements OnInit {
  rowdata;
  constructor(
    injector: Injector,
  ) {
    super(injector)
  }
  ngOnInit() {
  }

}
