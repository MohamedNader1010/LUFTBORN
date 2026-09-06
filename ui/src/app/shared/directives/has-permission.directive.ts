import { Directive, Input, TemplateRef, ViewContainerRef, effect } from '@angular/core';
import { AccessService } from '../../core/services/access-service.service';

@Directive({ selector: '[hasPermission]', standalone: true })
export class HasPermissionDirective {
  private permission = '';

  constructor(
    private templateRef: TemplateRef<unknown>,
    private viewContainer: ViewContainerRef,
    private accessService: AccessService
  ) {
    effect(() => {
      this.viewContainer.clear();
      if (this.accessService.hasPermission(this.permission)) {
        this.viewContainer.createEmbeddedView(this.templateRef);
      }
    });
  }

  @Input() set hasPermission(value: string) {
    this.permission = value;
  }
}