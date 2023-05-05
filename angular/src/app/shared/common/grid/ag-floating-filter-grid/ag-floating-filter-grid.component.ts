import { Component } from '@angular/core';
import { IFloatingFilterComp, IFloatingFilterParams } from 'ag-grid-community';
import { AgPromise } from 'ag-grid-community/dist/lib/utils';

@Component({
    selector: 'app-ag-floating-filter-grid',
    templateUrl: './ag-floating-filter-grid.component.html',
    styleUrls: ['./ag-floating-filter-grid.component.less']
})
export class AgFloatingFilterGridComponent implements IFloatingFilterComp {

    params: IFloatingFilterParams;
    currentValue: string = '';

    constructor() { }
    afterGuiAttached?(): void {
        throw new Error('Method not implemented.');
    }
    getGui(): HTMLElement {
        throw new Error('Method not implemented.');
    }
    destroy?(): void {
        throw new Error('Method not implemented.');
    }
    init?(params: IFloatingFilterParams<any, any, any>): void | AgPromise<void> {
        throw new Error('Method not implemented.');
    }

    ngOnInit(): void {
    }

    agInit(params: IFloatingFilterParams): void {
        this.params = params;
      }

      onParentModelChanged(parentModel: any) {
        // When the filter is empty we will receive a null value here
        if (!parentModel) {
          this.currentValue = null;
        } else {
          this.currentValue = parentModel;
        }
      }

      onInputBoxChanged() {
        if (!!!this.currentValue) {
          // Remove the filter
          this.params.parentFilterInstance((instance: any) => {
            instance
              .getFrameworkComponentInstance()
              .myMethodForTakingValueFromFloatingFilter(null);
          });
          return;
        }

        this.params.parentFilterInstance((instance: any) => {
          instance
            .getFrameworkComponentInstance()
            .myMethodForTakingValueFromFloatingFilter(this.currentValue);
        });
      }
}
