import { Injectable, OnDestroy } from "@angular/core";
import { Subject } from "rxjs";

@Injectable()
export class Destroyable implements OnDestroy {

  protected _destroyed$ = new Subject();


  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
