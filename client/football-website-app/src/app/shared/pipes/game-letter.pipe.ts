import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'gameLetter',
})
export class GameLetterPipe implements PipeTransform {
  transform(value: string, ...args: unknown[]): unknown {
    switch (value) {
      case 'W':
        return 'V';
      case 'D':
        return 'N';
      case 'L':
        return 'D';
      default:
        break;
    }
  }
}
