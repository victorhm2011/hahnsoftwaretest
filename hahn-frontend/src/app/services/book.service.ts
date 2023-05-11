import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private apiUrl = `${environment.apiUrl}/books`;
  public bookList:Book[] = [
    {
      id: '1',
      title: "In Search of Lost Time",
      price: 30,
      author: "Marcel Proust",
      publishDate: new Date("1913-01-16")
    },
    {
      id: '2',
      title: "Ulysses",
      price: 100,
      author: "James Joyce",
      publishDate: new Date("1904-05-07")
    },
    {
      id: '3',
      title: "Don Quixote",
      price: 80,
      author: "Miguel de Cervantes",
      publishDate: new Date("1968-03-19")
    },
    {
      id: '4',
      title: "One Hundred Years of Solitude ",
      price: 200,
      author: "Gabriel Garcia Marquez",
      publishDate: new Date("1979-11-10")
    },
    {
      id: '5',
      title: "The Great Gatsby",
      price: 50,
      author: "F. Scott Fitzgerald",
      publishDate: new Date("1986-10-26")
    },
    {
      id: '6',
      title: "Moby Dick",
      price: 79,
      author: "Herman Melville",
      publishDate: new Date("1851-01-05")
    },
  ];

  constructor(private http: HttpClient) { }

  getAllBooks(): Book[] {
    return this.bookList;
  }

  getBookById(id: string): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/${id}`);
  }

  createBook(book: Book) {
    this.bookList.push(book);
  }

  updateBook(book: Book) {
    this.bookList = this.bookList.filter(books => books.id !== book.id);
    this.bookList.push(book);
  }

  deleteBook(id: string) {
    this.bookList = this.bookList.filter(books => books.id !== id);
  }
}
