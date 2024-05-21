import { Component } from '@angular/core';
import { authService } from './services/auth.service';
import { CommonService } from './services/common.service';
import { NzResizeEvent } from 'ng-zorro-antd/resizable';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.less'
})
export class AppComponent {
  title = 'template';

  constructor(public _authService: authService,
    public _commonService: CommonService) {

  }

  siderWidth = 180;
  id = -1;

  onSideResize({ width }: NzResizeEvent): void {
    cancelAnimationFrame(this.id);
    this.id = requestAnimationFrame(() => {
      this.siderWidth = width!;
    });
  }
}
