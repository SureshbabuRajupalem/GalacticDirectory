import { Component, OnInit, ViewChild  } from '@angular/core';
import { Observable } from 'rxjs';
import { GDService } from '../services/gd.service';
import { People } from '../models/People';
import { MatPaginator} from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'People-root',
  templateUrl: './People.component.html',
  styleUrls: ['./People.component.css']
})
export class PeopleComponent implements OnInit {
  title = 'People';
  people$: Observable<People[]>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  constructor(private gdService: GDService) {

  }
  displayedColumns: string[] = ['People_ID', 'Name', 'Height', 'Mass', 'Skin_color', 'Eye_color', 'Gender','Url'];
 
  ngOnInit() {  
    this.loadPeople();
  }
  loadPeople() {
    this.people$ = this.gdService.getPeopleDetails();
   // console.log(this.people$);
    const dataSource = this.people$
  }

  delete(Id) {
    const ans = confirm('Do you want to delete blog post with id: ' + Id);
    if (ans) {
      this.gdService.deletePeopleById(Id).subscribe((data) => {
        this.loadPeople();
      });
    }
  }
}
