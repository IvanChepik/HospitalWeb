import { ReactiveFormsModule } from '@angular/forms';
import { ComponentsModule } from './../../../@components/components.module';
import { ThemeModule } from './../../../@theme/theme.module';
import { NgModule } from '@angular/core';
import { SaveAddPattientComponent } from './save-or-addpat.component';
import { NbListModule, NbDatepickerModule } from '@nebular/theme';
import { NbDateFnsDateModule } from '@nebular/date-fns';

@NgModule({
    imports: [ThemeModule, 
        NbDatepickerModule, 
        ComponentsModule, 
        ReactiveFormsModule, 
        NbDateFnsDateModule],
    exports: [],
    declarations: [SaveAddPattientComponent],
    providers: [],
})
export class SaveOrAddModule {}