import { Injectable } from '@angular/core';
import { Validator } from 'fluentvalidation-ts';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class ValidationService extends Validator<Book>{

  constructor() {
    super();

    this.ruleFor('title').notEmpty().withMessage('Is required');
    this.ruleFor('price').greaterThanOrEqualTo(0).withMessage('Please enter a non-negative number');
    this.ruleFor('author').notEmpty().withMessage('Is required');
    this.ruleFor('publishDate').notNull().withMessage('Is required');
  }
}
