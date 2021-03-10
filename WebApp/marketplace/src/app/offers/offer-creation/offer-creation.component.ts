import {Component, Input, OnInit} from '@angular/core';
import {FormGroup} from '@angular/forms';

@Component({
  selector: 'app-offer-creation',
  templateUrl: './offer-creation.component.html',
  styleUrls: ['./offer-creation.component.scss']
})
export class OfferCreationComponent implements OnInit {

  offerForm: FormGroup;

  @Input()
  categories: string[];

  constructor() { }

  ngOnInit(): void {
  }

  offerSubmit() {
    // TODO: implement submit logic
  }
}
