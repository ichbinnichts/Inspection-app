import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { InspectionApiService } from 'src/app/inspection-api.service';

@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.css']
})
export class ShowInspectionComponent {
  //Variables
  activateAddEditInspectionComponent: boolean = false;
  addModalTitle: string = '';
  inspection:any;

  inspectionList$!:Observable<any[]>;
  inspectionTypesList$!:Observable<any[]>;
  inspectionTypesList:any=[];

  //Map to display associate with foreign keys
  inspectionTypesMap:Map<number, string> = new Map();

  constructor(private service:InspectionApiService){

  }
  ngOnInit(): void {
    this.inspectionList$ = this.service.getInspectionList();
    this.inspectionTypesList$ = this.service.getInspectionTypeList();
    this.refreshInspectionTypesMap();
  }

  modalAdd(){
    this.inspection = {
      id:0,
      status:null,
      comments:null,
      inspectionTypeId:null
    }
    this.addModalTitle = 'Add Inspection';
    this.activateAddEditInspectionComponent = true;
  }
  modalClose(){
    this.activateAddEditInspectionComponent = false;
    this.inspectionList$ = this.service.getInspectionList();
  }

  refreshInspectionTypesMap(){
    this.service.getInspectionTypeList().subscribe(data => {
      this.inspectionTypesList = data;

      for(let i=0;i<data.length;i++){
        this.inspectionTypesMap.set(this.inspectionTypesList[i], 
          this.inspectionTypesList[i].inpectionName);
      }
    })
  }

}
