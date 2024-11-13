import { Router } from '@angular/router';
import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-large-tablet',
  templateUrl: './large-tablet.component.html',
  styleUrls: ['./large-tablet.component.css'],
})
export class LargeTabletComponent implements OnInit {
  constructor(public data: DataService, private router: Router) {}
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  goToLocation(i: any) {
    this.router.navigate(['/location']);
  }
}
