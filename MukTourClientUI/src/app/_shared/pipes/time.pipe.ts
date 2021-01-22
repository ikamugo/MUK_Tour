import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';
@Pipe({
  name: 'time'
})
export class TimePipe implements PipeTransform {

  transform(value: string): unknown {
    return moment(value, ['h:m a', 'H:m']).format('h:mm A');
  }

}
