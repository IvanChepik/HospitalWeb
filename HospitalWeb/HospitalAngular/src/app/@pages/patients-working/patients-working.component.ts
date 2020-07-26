import { Component, OnDestroy, OnInit } from '@angular/core';
import { takeWhile } from 'rxjs/operators';
import { NbTokenService } from '@nebular/auth';
import { NbMenuItem } from '@nebular/theme';
import { InitUserService } from 'src/app/@theme/services/init-user.service';


@Component({
  selector: 'ngx-list-manager',
  styleUrls: ['patients-working.component.scss'],
  template: `
    <ngx-one-column-layout>
      <router-outlet></router-outlet>
    </ngx-one-column-layout>
  `,
})
export class PatientsWorkingComponent implements OnDestroy, OnInit {

  menu: NbMenuItem[];
  alive: boolean = true;

  constructor(
    private tokenService: NbTokenService,
    protected initUserService: InitUserService,
  ) {
   // this.initMenu();

    this.tokenService.tokenChange()
      .pipe(takeWhile(() => this.alive))
      .subscribe(() => {
        //this.initMenu();
      });
  }
  ngOnInit(): void {
     
  }

//   initMenu() {
//     this.pagesMenu.getMenu()
//       .pipe(takeWhile(() => this.alive))
//       .subscribe(menu => {
//         this.menu = menu;
//       });
//   }

  ngOnDestroy(): void {
    this.alive = false;
  }
}
