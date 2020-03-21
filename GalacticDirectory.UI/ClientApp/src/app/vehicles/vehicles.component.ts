import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { GDService } from '../services/gd.service';
import { People } from '../models/People';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'vehicles-root',
  templateUrl: './vehicles.component.html',
  styleUrls: []
})
export class vehiclesComponent implements OnInit {
  title = 'Vehicles';
  people$: Observable<People[]>;
  constructor(private gdService: GDService) {

  }
  displayedColumns: string[] = [];

  ngOnInit() {
    this.loadVehicles();
  }
  loadVehicles() {
 // 
  }

  delete(Id) {
    const ans = confirm('Do you want to delete blog post with id: ' + Id);
   
    }
  }

