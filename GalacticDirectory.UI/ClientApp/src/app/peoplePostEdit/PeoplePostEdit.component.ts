import { Component, OnInit, ViewChild  } from '@angular/core';
import { Observable } from 'rxjs';
import { GDService } from '../services/gd.service';
import { People } from '../Models/People';
import { MatPaginator} from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'peoplePostEdit-root',
  templateUrl: './peoplePostEdit.component.html',
  styleUrls: []
})
export class PeoplePostEditComponent implements OnInit {
  title = 'Edit/Update';
  people$: Observable<People[]>;

  constructor(private gdService: GDService) {

  }
  displayedColumns: string[] = [];
 
  ngOnInit() {  
 
  }

}
