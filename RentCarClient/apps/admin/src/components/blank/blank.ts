import { NgClass, Location, DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, ViewEncapsulation, input, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { EntityModel } from '../../models/entity.model';

@Component({
  selector: 'app-blank',
  imports: [
    NgClass,
    RouterLink,
    DatePipe,
  ],
  templateUrl: './blank.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export default class Blank {
  readonly pageTitle = input.required<string>();
  readonly pageDescription = input<string>('');
  readonly pageIcon = input.required<string>();
  readonly showStatus = input<boolean>(false);
  readonly status = input<boolean>(true);
  readonly showBackButton = input<boolean>(true);
  readonly showEditButton = input<boolean>(false);
  readonly editButtonUrl = input<string>('');
  readonly audit = input<EntityModel>();
  readonly showAudit = input<boolean>(false);

  readonly #location = inject(Location);

  back() {
    this.#location.back();
  }
}
