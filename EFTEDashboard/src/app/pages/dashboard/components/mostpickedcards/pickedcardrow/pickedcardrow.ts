import { CardPickRateDto } from '@/interfaces/outputDtos/card-pick-rate-dto';
import { Component, Input, input } from '@angular/core';

@Component({
  selector: 'app-pickedcardrow',
  imports: [],
  templateUrl: './pickedcardrow.html',
  styleUrl: './pickedcardrow.scss'
})
export class Pickedcardrow {
    @Input()
    cardPickRateDto!: CardPickRateDto;
}
