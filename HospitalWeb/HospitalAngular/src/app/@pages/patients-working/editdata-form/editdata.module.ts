import { ReactiveFormsModule } from '@angular/forms';
import { ThemeModule } from './../../../@theme/theme.module';
import { NgModule } from '@angular/core';
import { EditDataComponent } from './editdata-form.component';

@NgModule({
    imports: [ThemeModule, ReactiveFormsModule],
    exports: [],
    declarations: [EditDataComponent],
    providers: [],
})
export class EditDataModule {}