import { DOUBLE_PATTERN } from './../../../@auth/components/constants';
import { PatientsService } from './../../../@core/backend/common/services/patients.service';
import { Patient } from './../../../@core/models/patients';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DateService } from 'src/app/@core/backend/common/services/date.service';

@Component({
    selector: 'app-save-or-add',
    templateUrl: 'save-or-addpat.component.html',
    styleUrls: ['./save-or-addpat.component.less']
})

export class SaveAddPattientComponent implements OnInit {

    patients: Patient[];

    patientForm: FormGroup;
    choosenPatient: Patient;

    isFormLoading = false;
    isPatientsLoading = false;

    constructor(private patientsService: PatientsService, 
        private router: Router,
        private dateService: DateService) { }

    get caseHistoryNumber() { return this.patientForm.get('caseHistoryNumber'); }
    get firstName() { return this.patientForm.get('firstName'); }
    get lastName() { return this.patientForm.get('lastName'); }
    get patronymic() { return this.patientForm.get('patronymic'); }
    get diagnosis() { return this.patientForm.get('diagnosis'); }
    get sex() { return this.patientForm.get('sex'); }
    
    get dateHospital() { return this.patientForm.get('dateHospital'); }
    get dateOITR() { return this.patientForm.get('dateOITR'); }
    get birthDate() { return this.patientForm.get('birthDate'); }


    ngOnInit() { 
        this.getPatients();
        this.definePatientForm();
    }

    onAddPatient(){

        this.isFormLoading = true;

        const newPatient = new Patient(
            this.patientForm.controls.caseHistoryNumber.value,
            this.patientForm.controls.firstName.value,
            this.patientForm.controls.lastName.value,
            this.patientForm.controls.patronymic.value,
            this.patientForm.controls.diagnosis.value,
            this.patientForm.controls.dateHospital.value,
            this.patientForm.controls.dateOITR.value, 
            this.patientForm.controls.birthDate.value, 
            this.patientForm.controls.sex.value.toLowerCase() == 'true'
        )

        this.patientsService.addPatient(newPatient).subscribe(data => {
            this.isFormLoading = false;
            this.getPatients();
        })
    }

    private getPatients(){
        this.isPatientsLoading = true;
        this.patientsService.getPatients().subscribe(data => {
            this.patients = data;
            this.isPatientsLoading = false;
        })
    }

    onPatientSelect(patient: Patient){
        if (this.choosenPatient)
        {
            this.choosenPatient.isChoosen = false;
        }
        this.choosenPatient = patient;
        this.choosenPatient.isChoosen = true;
    }

    private definePatientForm(){
        
        this.patientForm = new FormGroup({
            "caseHistoryNumber": new FormControl("", Validators.required),
            "lastName": new FormControl("", Validators.required),
            "firstName": new FormControl("", Validators.required),
            "patronymic": new FormControl("", Validators.required),
            "dateHospital": new FormControl(new Date(), Validators.required),
            "dateOITR": new FormControl(new Date(), Validators.required),
            "birthDate": new FormControl(new Date(), Validators.required),
            "sex": new FormControl("", Validators.required),
            "diagnosis": new FormControl("", Validators.required),
          });
    }

    onLoadPatient(){
        this.router.navigate(['patients/edit/'+this.choosenPatient.patientId]);
    }

}