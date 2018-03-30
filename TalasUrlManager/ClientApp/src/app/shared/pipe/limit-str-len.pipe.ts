import {Pipe, PipeTransform} from '@angular/core';

@Pipe({ name: 'limitStrLen' })
export class LimitStrLenPipe implements PipeTransform {

  transform(value: string, length: number): string {
    let result = value;
    if (value.length > length)
      result = value.substring(0, length).concat('...');
    return result;
  }
}
