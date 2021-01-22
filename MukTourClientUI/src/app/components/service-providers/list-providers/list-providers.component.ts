import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceProvidersService } from 'src/app/_shared/services/service-providers.service';

@Component({
  selector: 'app-list-providers',
  templateUrl: './list-providers.component.html',
  styleUrls: ['./list-providers.component.scss'],
})
export class ListProvidersComponent implements OnInit {
  categories$: Observable<string[]>;

  constructor(private providersService: ServiceProvidersService) {}

  ngOnInit(): void {
    this.categories$ = this.providersService.listCategories();
  }
}
