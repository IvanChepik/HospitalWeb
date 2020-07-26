import { MainWindowModule } from './mainwindow/mainwindow.module';
import { NgModule } from '@angular/core';
import { PagesRoutingModule } from './pages-routing.module';
import { CommonModule } from '@angular/common';


@NgModule({
    imports: [PagesRoutingModule, MainWindowModule, CommonModule],
    exports: [],
    declarations: [],
    providers: [],
})
export class PagesModule { }
