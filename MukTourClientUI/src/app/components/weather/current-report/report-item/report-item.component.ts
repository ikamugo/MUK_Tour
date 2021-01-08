import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-report-item',
  templateUrl: './report-item.component.html',
  styleUrls: ['./report-item.component.scss']
})
export class ReportItemComponent implements OnInit {

  @Input() icon: string;
  @Input() label: string;
  @Input() value: any;
  @Input() unit: any;
  constructor() { }

  ngOnInit(): void {
  }

}
