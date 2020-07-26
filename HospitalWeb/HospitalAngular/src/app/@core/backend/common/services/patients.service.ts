import { environment } from './../../../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Patient } from 'src/app/@core/models/patients';
import { PatientDataRequest } from 'src/app/@core/models/patientDataRequest';

@Injectable()
export class PatientsService 
{
    apiController = environment.apiUrl + "/patients"

    constructor(private http: HttpClient) { }

    public getPatients(): Observable<Patient[]> {
        return this.http.get<Patient[]>(`${this.apiController}/`);
    }

    public addPatient(patient: Patient): Observable<Patient> {
        return this.http.post<Patient>(`${this.apiController}`, patient)
    }

    public getPatientInfo(patientId: number): Observable<Patient>{
        return this.http.get<Patient>(`${this.apiController}/${patientId}`);
    }

    
}
