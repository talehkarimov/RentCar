import { NgClass } from '@angular/common';
import { ChangeDetectionStrategy, Component, ViewEncapsulation, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BreadcrumbService } from 'apps/admin/src/services/breadcrumb';

@Component({
  selector: 'app-breadcrumb',
  imports: [
    NgClass,
    RouterLink
  ],
  templateUrl: './breadcrumb.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export default class Breadcrumb {
  readonly breadCrumb = inject(BreadcrumbService);
}
