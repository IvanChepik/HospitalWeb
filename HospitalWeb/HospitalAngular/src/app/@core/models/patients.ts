export class Patient {

  public patientId: number;
  public dateDischarge: Date;
  public isChoosen: boolean;

  constructor(
    public caseHistoryNumber: string,
    public firstname: string,
    public lastname: string,
    public patronymic: string,
    public diagnosis: string,
    public dateOfHospital: Date,
    public dateOfOITR: Date,
    public dateBirth: Date,
    public isMale: boolean
  ) {
    
  }

}
