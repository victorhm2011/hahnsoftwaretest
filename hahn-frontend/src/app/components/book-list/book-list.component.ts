import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';
import { BookConstants } from 'src/assets/constants/book.constants';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSort } from '@angular/material/sort';
import { BookFormComponent } from '../book-form/book-form.component';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {

  public dataSource = new MatTableDataSource<Book>();
  public paginator!: MatPaginator;
  public bookConstants = BookConstants;
  public id!: string;

  public columns = [
    {
      columnDef: 'title',
      header: BookConstants.TITLE,
      cell: (element: Book) => `${element.title}`,
    },
    {
      columnDef: 'author',
      header: BookConstants.AUTHOR,
      cell: (element: Book) => `${element.author}`,
    },
    {
      columnDef: 'price',
      header: BookConstants.PRICE,
      cell: (element: Book) => `${element.price}`,
    },
    {
      columnDef: 'publishDate',
      header: BookConstants.PUBLISHDATE,
      cell: (element: Book) => `${element.publishDate}`,
    }
  ];

  public displayedColumns = this.columns.map(c => c.columnDef);

  constructor(public bookService: BookService, private dialog: MatDialog, private changeDetectorRefs: ChangeDetectorRef,
    public router: Router, private route: ActivatedRoute) { }

  @ViewChild(MatSort) set matSort(ms: MatSort) {
    this.dataSource.sort = ms;
  }

  @ViewChild(MatPaginator) set matPaginator(mp: MatPaginator) {
    this.paginator = mp;
    this.setDataSourceAttributes();
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') as string;
    this.getBooks();
  }

  setDataSourceAttributes() {
    this.dataSource.paginator = this.paginator;
  }

  public getBooks(): void {
    this.bookService.getAllBooks()
    .subscribe(books => {
      this.dataSource = new MatTableDataSource<Book>(books);
      this.changeDetectorRefs.detectChanges();
    });
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public showBook(book: Book): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    const dialogRef = this.dialog.open(BookFormComponent, {
      disableClose: true,
      autoFocus: true,
      data: {
        book: book
      }
    } );
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.ngOnInit();
      }
    });
  }

  public addBook() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    const dialogRef = this.dialog.open(BookFormComponent, {
      disableClose: true,
      autoFocus: true,
    } );
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.ngOnInit();
      }
    });
  }
}
