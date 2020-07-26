import { environment } from './../../../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Patient } from 'src/app/@core/models/patients';
import { PatientDataRequest } from 'src/app/@core/models/patientDataRequest';

@Injectable()
export class DateService 
{

    public calculateAge(dateBirth: Date): number {
    
        var birth = new Date(dateBirth)
        return Math.abs((new Date(Date.now() - birth.getTime())).getUTCFullYear() - 1970);
    }

 
}
