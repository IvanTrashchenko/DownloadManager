import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { NgScrollbarModule } from 'ngx-scrollbar';
import { NgxMatDatetimePickerModule } from '@angular-material-components/datetime-picker';
import { NGX_MAT_MOMENT_DATE_ADAPTER_OPTIONS, NgxMatMomentModule } from '@angular-material-components/moment-adapter';

const modules: any[] = [
  CommonModule,
  MatMenuModule,
  MatIconModule,
  MatToolbarModule,
  MatCardModule,
  MatInputModule,
  MatSelectModule,
  MatButtonModule,
  MatFormFieldModule,
  MatTableModule,
  MatDatepickerModule,
  MatNativeDateModule,
  NgScrollbarModule,
  NgxMatDatetimePickerModule,
  NgxMatMomentModule,
]

@NgModule({
  declarations: [],
  imports: [
    ...modules
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' },
    {
        provide: MAT_DATE_FORMATS, useValue: {
            parse: {
                dateInput: 'dd/MM/yyyy HH:mm:ss.SSS'
            },
            display: {
                dateInput: 'dd/MM/yyyy HH:mm:ss.SSS',
                monthYearLabel: 'MMM YYYY',
                dateA11yLabel: 'LL',
                monthYearA11yLabel: 'MMMM YYYY',
            }
        }
    },
  ],
  exports: [
    ...modules
  ]
})
export class MaterialModule { }
