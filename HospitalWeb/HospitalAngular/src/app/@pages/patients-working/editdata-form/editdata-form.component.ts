import { Patient } from 'src/app/@core/models/patients';
import { PatientsService } from './../../../@core/backend/common/services/patients.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Form } from '@angular/forms';
import { DateService } from 'src/app/@core/backend/common/services/date.service';

@Component({
    selector: 'app-editdata',
    templateUrl: './editdata-form.component.html',
    styleUrls: ['./editdata-form.component.less']
})

export class EditDataComponent implements OnInit {

    patientId: number;
    patient: Patient;
    currentfullname: string
    currentage: number;
    summaryForm: Form;

    constructor(private route:ActivatedRoute, 
        private patientsService: PatientsService,
        private dateService: DateService) { }

    ngOnInit() { 
        this.route.params.subscribe(data => {
            this.patientId = parseInt(data.patientId);
            this.getPatientInfo();
          });
    }

    private getPatientInfo(){
        this.patientsService.getPatientInfo(this.patientId).subscribe(data => {
            this.patient = data;
            console.log(this.patient);
            this.currentfullname = this.patient.lastname + ' ' + this.patient.firstname + ' ' + this.patient.patronymic;
            this.currentage = this.dateService.calculateAge(this.patient.dateBirth);
        });
    }




    private defineSummaryForm(){

    }


}