import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';
import { BookConstants } from 'src/assets/constants/book.constants';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.scss']
})
export class BookFormComponent implements OnInit {

  public form!: FormGroup;
  public minDate: Date;
  public maxDate: String | null;
  public book!: Book;
  public bookConstants = BookConstants;

  constructor(@Inject(MAT_DIALOG_DATA) public data: {book: Book}, public dialog: MatDialog, public dialogRef: MatDialogRef<BookFormComponent>, private datePipe: DatePipe,
    public bookService: BookService, private _snackBar: MatSnackBar, private route: ActivatedRoute, private validator: ValidationService) { 
      
    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 110, 0, 1);
    this.maxDate = this.datePipe.transform((new Date), 'MM/dd/yyyy');
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      id: new FormControl(null, [Validators.maxLength(500)]),
      title: new FormControl(null, [Validators.required, Validators.maxLength(500)]),
      author: new FormControl(null, [Validators.required, Validators.maxLength(500)]),
      price: new FormControl(null, [Validators.required, Validators.min(0)]),
      publishDate: new FormControl(null, [Validators.required]),
    });
    this.setBook();
    console.log(this.form.value);
  }

  public setBook(): void {
    this.form.patchValue({
      id: this.data.book.id,
      title: this.data.book.title,
      author: this.data.book.author,
      price: this.data.book.price,
      publishDate: this.data.book.publishDate,
    })
  }
  
  public close() {
    this.dialogRef.close();
  }

  public save() {
    this.book = this.form.value;
    console.log(this.book);
    if(this.book.id !== undefined){
      this.bookService.updateBook(this.book);
      this.openSnackBar(this.bookConstants.UPDATE, this.bookConstants.CONTINUE);
    } else {
      this.book.id = "100001";
      this.bookService.createBook(this.book);
      this.openSnackBar(this.bookConstants.ADD, this.bookConstants.CONTINUE);
    }
    this.dialogRef.close(this.book);
    
  }

  public delete() {
    console.log(this.data.book.id);
    this.bookService.deleteBook(this.data.book.id);
    this.dialogRef.close(this.data.book);
  }

  public hasError = (controlName:string, errorName:string) =>{
    return this.form.controls[controlName].hasError(errorName);
  }

  public openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }
}
