>>>>>>>>>>>>>>>> Text

>>> Basic Types
Boolean
let isDone: boolean = false;

> Number
let decimal: number = 6;
let hex: number = 0xf00d;
let binary: number = 0b1010;
let octal: number = 0o744;

> String
let color: string = "blue";
color = 'red';
let sentence: string = `Hello, my name is ${ fullName }. I'll be ${ age + 1 } years old next month.`;

> Array
let list: number[] = [1, 2, 3];
let list: Array<number> = [1, 2, 3];

> Tuple
// Declare a tuple type
let x: [string, number];
// Initialize it
x = ["hello", 10]; // OK
// Initialize it incorrectly
x = [10, "hello"]; // Error

> Enum
enum Color {Red, Green, Blue}
let c: Color = Color.Green;

enum Color {Red = 1, Green = 2, Blue = 4}
let c: Color = Color.Green;

> Any
let notSure: any = 4;
notSure = "maybe a string instead";
notSure = false; // okay, definitely a boolean

let list: any[] = [1, true, "free"];
list[1] = 100;

> Void
function warnUser(): void {
    console.log("This is my warning message");
}

let unusable: void = undefined;
unusable = null; // OK if `--strictNullChecks` is not given

> Null and Undefined
// Not much else we can assign to these variables!
let u: undefined = undefined;
let n: null = null;
By default null and undefined are subtypes of all other types. That means you can assign null and undefined to something like number.

> Never
The never type represents the type of values that never occur.
// Function returning never must have unreachable end point
function error(message: string): never {
    throw new Error(message);
}

// Inferred return type is never
function fail() {
    return error("Something failed");
}

// Function returning never must have unreachable end point
function infiniteLoop(): never {
    while (true) {
    }
}

> Object
object is a type that represents the non-primitive type, i.e. anything that is not number, string, boolean, bigint, symbol, null, or undefined.
declare function create(o: object | null): void;

create({ prop: 0 }); // OK
create(null); // OK

create(42); // Error
create("string"); // Error
create(false); // Error
create(undefined); // Error

> Type assertions
let someValue: any = "this is a string";
let strLength: number = (<string>someValue).length;

let someValue: any = "this is a string";
let strLength: number = (someValue as string).length;

> A note about let
The let keyword was introduced to JavaScript in ES2015 and is now considered the standard because it’s safer than var.


>>> Variable Declarations
> Scoping rules 
> let declarations
> Variable capturing quirks 
> Block-scoping
> Re-declarations and Shadowing
> Block-scoped variable capturing 
> const declarations
> let vs. const
> Array destructuring
let input = [1, 2];
let [first, second] = input;
let [first, ...rest] = [1, 2, 3, 4];
> Tuple destructuring
let tuple: [number, string, boolean] = [7, "hello", true];
let [a, b, c] = tuple; // a: number, b: string, c: boolean
let [a, b, c, d] = tuple; // Error, no element at index 3
let [a, ...bc] = tuple; // bc: [string, boolean]

ignore trailing elements, or other elements:
let [a] = tuple; // a: number
let [, b] = tuple; // b: string
> Object destructuring

> Spread
let first = [1, 2];
let second = [3, 4];
let bothPlus = [0, ...first, ...second, 5];


>>> Interfaces
interface LabeledValue {
    label: string;
}

> Optional Properties 
interface SquareConfig {
    color?: string;
    width?: number;
}

> Readonly properties
interface Point {
    readonly x: number;
    readonly y: number;
}

> Function Types
interface SearchFunc {
    (source: string, subString: string): boolean;
}

let mySearch: SearchFunc;
mySearch = function(source: string, subString: string) {
    let result = source.search(subString);
    return result > -1;
}

> Indexable Types
interface StringArray {
    [index: number]: string;
}

let myArray: StringArray;
myArray = ["Bob", "Fred"];

let myStr: string = myArray[0];

> Class Types
interface ClockInterface {
    currentTime: Date;
}

class Clock implements ClockInterface {
    currentTime: Date = new Date();
    constructor(h: number, m: number) { }
}

> Extending Interfaces
interface Shape {
    color: string;
}

interface Square extends Shape {
    sideLength: number;
}

let square = {} as Square;
square.color = "blue";
square.sideLength = 10;

> Hybrid Types
interface Counter {
    (start: number): string;
    interval: number;
    reset(): void;
}

function getCounter(): Counter {
    let counter = (function (start: number) { }) as Counter;
    counter.interval = 123;
    counter.reset = function () { };
    return counter;
}

let c = getCounter();
c(10);
c.reset();
c.interval = 5.0;

> Interfaces Extending Classes
hat have certain properties. The subclasses don’t have to be related besides inheriting from the base class. For example:

class Control {
    private state: any;
}

interface SelectableControl extends Control {
    select(): void;
}

class Button extends Control implements SelectableControl {
    select() { }
}

class TextBox extends Control {
    select() { }
}

// Error: Property 'state' is missing in type 'Image'.
class Image implements SelectableControl {
    private state: any;
    select() { }
}


>>> Classes
> Inheritance
> Public, private, and protected modifiers
> Accessors
class Employee {
    private _fullName: string;

    get fullName(): string {
        return this._fullName;
    }

    set fullName(newName: string) {
        if (newName && newName.length > fullNameMaxLength) {
            throw new Error("fullName has a max length of " + fullNameMaxLength);
        }
        
        this._fullName = newName;
    }
}

> Static Properties
> Abstract Classes
abstract class Animal {
abstract class Animal {
    abstract makeSound(): void;
    move(): void {
        console.log("roaming the earth...");
    }
}




>>> Functions



>>> Generics



>>> Enums



>>> Type Inference



>>> Type Compatibility



>>> Advanced Types



>>> Symbols



>>> Iterators and Generators



>>> Modules



>>> Namespaces



>>> Decorators



>>> Utility Types



>>> Tips and Tricks



>>> Best Practices













