import {AfterViewInit, Directive, ElementRef, Input, OnDestroy} from '@angular/core';
import {NgControl} from '@angular/forms';
import {takeUntil} from 'rxjs/operators';
import {Subject} from 'rxjs/Subject';

@Directive({ selector: '[appShowErrorMessage]' })
export class ShowErrorMessageDirective implements AfterViewInit, OnDestroy {
  @Input() appShowErrorMessage: NgControl;
  destroy$ = new Subject();
  constructor(private element: ElementRef) {}

  ngAfterViewInit() {
    this.appShowErrorMessage.statusChanges.pipe(takeUntil(this.destroy$)).subscribe(state => {
      if (state === 'INVALID') {
        this.element.nativeElement.innerText =
          this._showErrorMessage(Object.keys(this.appShowErrorMessage.errors)[0]);
      } else {
        this.element.nativeElement.innerText = '';
      }
    });
  }

  ngOnDestroy() {
    this.destroy$.next('');
    this.destroy$.unsubscribe();
  }

  private _showErrorMessage(prop: string) {
    switch (prop) {
      case 'required':
        return '必填欄位';
      case 'pattern':
        return '格式錯誤';
    }
  }
}
