import { ChangeDetectionStrategy, Component, ViewEncapsulation, inject, OnInit } from '@angular/core';
import { BreadcrumbService } from '../../services/breadcrumb';

@Component({
  imports: [],
  templateUrl: './dashboard.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export default class Dashboard implements OnInit {
  readonly #breadCrumb = inject(BreadcrumbService);
  ngOnInit(): void {
    this.#breadCrumb.setDashboard();
  }
}
