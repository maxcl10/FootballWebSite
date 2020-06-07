import { Component, Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'teamName',
})
export class TeamNamePipe implements PipeTransform {
  public transform(value, args?) {
    if (value == null || value === undefined) {
      return '';
    }

    return this.is_numeric(value[value.length - 1])
      ? value
      : value.slice(0, -1);
  }

  is_numeric(str: string) {
    return /^\d+$/.test(str);
  }
}
