import { Component, effect, signal } from '@angular/core';
import { LoaderService } from '../../../core/services/loader.service';

@Component({
  selector: 'lb-spinner',
  imports: [],
  templateUrl: './spinner.component.html'
})
export class SpinnerComponent {
  loading = signal(false);
  constructor(private loader: LoaderService) {
    effect(() => {
      this.loader.loading$.subscribe(value => this.loading.set(value));
    });
  }
}
