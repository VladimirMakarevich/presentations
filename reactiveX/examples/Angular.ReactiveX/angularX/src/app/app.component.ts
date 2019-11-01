import { Component, OnInit } from '@angular/core';
import { combineAll, concatAll, debounceTime, delay, distinctUntilChanged, map, mapTo, mergeAll, switchMap, take } from 'rxjs/operators';
import { combineLatest, concat, interval, merge, Observable, of, Subject, timer, zip } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public results: any;
  public searchTerm = new Subject<string>();

  public baseUrl: string = 'https://api.cdnjs.com/libraries';
  public queryUrl: string = '?search=';

  constructor(private http: HttpClient) {
    this.search(this.searchTerm)
      .subscribe(results => {
        this.results = results.results;
      });
  }

  public search(terms: Observable<string>): Observable<any> {
    return terms.pipe(
      debounceTime(400),
      distinctUntilChanged(),
      switchMap(term => this.searchEntries(term)));
  }

  public searchEntries(term) {
    return this.http
      .get(this.baseUrl + this.queryUrl + term)
      .pipe(map(response => response));
  }

  public ngOnInit(): void {
    // console.log('combineAll >>>>>>>>> ');
    // this.combineAll();

    // console.log('combineLatest >>>>>>>>> ');
    // this.combineLatest();

    // console.log('concat >>>>>>>>> ');
    // this.concat();

    // console.log('concatAll >>>>>>>>> ');
    // this.concatAll();

    // console.log('merge >>>>>>>>> ');
    // this.merge();

    console.log('mergeAll >>>>>>>>> ');
    this.mergeAll();

    // console.log('zip >>>>>>>>> ');
    // this.zip();
  }

  public zip(): void {
    const sourceOne = of('Hello');
    const sourceTwo = of('World!');
    const sourceThree = of('Goodbye');
    const sourceFour = of('World!');

    const example = zip(
      sourceOne,
      sourceTwo.pipe(delay(1000)),
      sourceThree.pipe(delay(2000)),
      sourceFour.pipe(delay(3000))
    );

    example.subscribe(val => {
      debugger;
      console.log(val);
    });
  }

  public mergeAll(): void {
    const myPromise = val =>
      new Promise(resolve => setTimeout(
        () => resolve(`Result: ${val}`),
        2000)
      );

    const source = of(1, 2, 3);

    const example = source.pipe(
      map(val => myPromise(val)),
      mergeAll()
    );

    example.subscribe(val => console.log(val));
  }

  public merge(): void {
    const first = interval(2500);
    const second = interval(2000);
    const third = interval(1500);
    const fourth = interval(1000);

    const example = merge(
      first.pipe(mapTo('1!')),
      second.pipe(mapTo('2!')),
      third.pipe(mapTo('3!')),
      fourth.pipe(mapTo('4!'))
    );

    example.subscribe(val => console.log(val));
  }

  public concatAll(): void {
    const source = interval(1000);
    const example = source.pipe(
      map(val => of(val + 10)),
      concatAll()
    );

    example.subscribe(val =>
      console.log('Example with Basic Observable:', val)
    );
  }

  public concat(): void {
    concat(
      of(1, 2, 3),
      of(4, 5, 6),
      of(7, 8, 9)
    ).subscribe(console.log);
  }

  public combineAll(): void {
    const source = interval(1000).pipe(take(2));

    const example = source.pipe(
      map(val =>
        interval(1000).pipe(
          map(i => `Result (${val}): ${i}`),
          take(5)
        )
      )
    );
    example.pipe(combineAll()).subscribe(console.log);
  }

  public combineLatest(): void {
    const timerOne$ = timer(1000, 4000);
    const timerTwo$ = timer(2000, 4000);
    const timerThree$ = timer(3000, 4000);

    combineLatest(
      timerOne$,
      timerTwo$,
      timerThree$,
      (one, two, three) => {
        return `Timer One (Proj) Latest: ${one},
              Timer Two (Proj) Latest: ${two},
              Timer Three (Proj) Latest: ${three}`;
      }
    ).subscribe(console.log);
  }
}
