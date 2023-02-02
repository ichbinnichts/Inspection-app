import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { InspectionApiService } from 'src/app/inspection-api.service';

@Component({
  selector: 'app-add-edit-inspection',
  templateUrl: './add-edit-inspection.component.html',
  styleUrls: ['./add-edit-inspection.component.css']
})
export class AddEditInspectionComponent {
  inspectionList$!:Observable<any[]>;
  statusList$!:Observable<any[]>;
  inspectionTypesList$!: Observable<any[]>;


  constructor(private service:InspectionApiService){

  }
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    
  }
  @Input() inspection:any;
  id: number = 0;
  status: string = "";
  comments: string = "";
  inspectionTypeId!: number;

}
