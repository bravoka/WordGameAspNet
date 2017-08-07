import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
	name: 'capitalization'
})
export class CapitalizationPipe implements PipeTransform {
	transform(value: any) {
		return value[0].toUpperCase() + value.slice(1);
	}
}