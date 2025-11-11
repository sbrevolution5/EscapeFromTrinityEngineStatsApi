import { Component } from '@angular/core';
import { Menu } from "primeng/menu";
import { CardPickRateDto } from "../../../../interfaces/outputDtos/card-pick-rate-dto";
import { Pickedcardrow } from './pickedcardrow/pickedcardrow';
@Component({
  selector: 'app-mostpickedcards',
  imports: [Pickedcardrow],
  templateUrl: './mostpickedcards.html',
  styleUrl: './mostpickedcards.scss'
})
export class Mostpickedcards {

}
