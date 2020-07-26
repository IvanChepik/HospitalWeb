import { Router } from '@angular/router';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { NbAuthService } from '@nebular/auth';
import { takeUntil } from 'rxjs/operators';
import { User } from 'src/app/@core/interfaces/common/users';
import { UserStore } from 'src/app/@core/stores/user.store';

@Component({
  selector: 'app-main-window',
  templateUrl: './mainwindow.component.html',
  styleUrls: ['./mainwindow.component.less'],
})
export class MainWindowComponent implements OnInit, OnDestroy {
  isAuthenticated: Observable<boolean>;
  user: User;
  private destroy$: Subject<void> = new Subject<void>();

  constructor(
    private router: Router,
    private authService: NbAuthService,
    private userStore: UserStore
  ) {}

  ngOnInit() {
    //this.isAuthenticated = this.authService.isAuthenticated();

    this.authService.isAuthenticated().subscribe(authenticated => {
      if (authenticated){
        this.router.navigate(["patients"]);
      }
    })

    // this.userStore
    //   .onUserStateChange()
    //   .pipe(takeUntil(this.destroy$))
    //   .subscribe((user: User) => {
    //     this.user = user;
    //     console.log(user);
    //   });
  }

  goToRegistration() {
    this.router.navigate(['auth/register']);
  }

  goToLogin() {
    this.router.navigate(['auth/login']);
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
