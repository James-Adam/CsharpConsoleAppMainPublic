windows.onload = function() {
    alert("welcome to the page");
};
//Variables

//undefined
//var x;
//alert(x);
//null
//var x=null;
//alert(x);
//integer
//var x 10;
//alert(x);
//floating point
//var x = 1.353245425;
//exponents
//var x = 1024e4;
//strings
//var x ="10 hello";
//alert(x);
//boolean
//var x = true;
//alert(x);
//math functions
//var x = Math.PI;
//alert(x);
//arrays
//var x = ["red", "green", "blue"]
//alert(x[1]);
//  object
//var x = {make:"Ford", model:"Focus",year:"2015",color:"blue"}
//alert(x.year);

//Math

// add
//var x = 0;
//x = x + 1;
//alert(x);

//var x = 0;
//x += 1;
//alert(x)

//var x = 0;
//x++;
//alert(x);

//subtract
//x = x - 1;
//x -= 1;
// x--;

//Multiplication
//var x = 10;
//x = x * 10;
//alert(x);

//Division
//var x = 100;
//x = x /10;
//alert(x);

//modulo (division reminder)
//var x = 25;
//x = x % 2;
//alert(x);

//adding strings
//var x = "Hello";
//x = x + " there!";
//alert(x);

//Conditional statements

//var x = 10;
//var y = 14;
//if ( x <= 10) {alert("true");} else {alert("false");}
//if ( x >= 10) {alert("true");} else {alert("false");}
//if ( x == 10) {alert("true");} else {alert("false");} // logical check
//if ( x > 10) {alert("true");} else {alert("false");}
//if ( x = 11 && y == 14) {alert("true");} else {alert("false");} // logical and
//if ( x = 11 || y == 14) {alert("true");} else {alert("false");} // logical or
//if  (!(x = 11 && y == 14)) {alert("true");} else {alert("false");} // logical not

// For and While Loops
//for Loops
//var x = "";
//for(i = 0; i < 100; i++;)
//for(i = 0; i < 100; i += 1;)
/*{
    x += i + " ";
}
alert(x);*/

//while loop
//var x = "";
//for(i = 0;
//while(i < 100)
/*{
    x += i + " ";
    i++;
} */

//Controlling Loops

//Break - stop
/*var x = "";
for (i = 1; i <= 100; i++)
{
    if (i == 50) break;
    x += i + " ";
}
alert(x);*/

//continue - skip itteration
/*var x = "";
for (i = 1; i <= 100; i++)
{
    if (i == 50) break;
    x += i + " ";
}
alert(x);  */

// Using Labels

/*var x = ["red", "green", "blue", "yellow", "black"];
colors = "";
count:
{
colors += x [0] + " ";
colors += x [1] + " ";
colors += x [2] + " ";
//break count;
//continue count;
colors += x [3] + " ";
colors += x [0] + " ";
}
alert(colors); */

// Using substrings

/*var x = "Now is out finest hour";
    //substr uses index location,number of characters
var y = x.substr(17,4);
alert(y);  */

//substring
//var y = x.substring(18,22);
//alert(y);;

// Functions

// DOM and operators

/*
window.onload = function(e){
    var paragraphs = document.getElementByTagName("p");
    console.log(paragraphs[0].innerHTML);

    var var1 = 3;
    var var2 = 4;

    var1 = var1 + 7 or var1 += 7;
    console.log('var1', var1);

    console.log(var 1 != 10);

    console.log'sqrt:', (Math.sqrt(var1));
    console.log('ceil:' Math.ceil(Math.sqrt(var1)));

    //conditional statements

    if (var1 = 6) {
        console.log('if statement is true');
    } else {
        console.log('if statement is false');
    } else if (var1 == 10) {
        console.log('if is false, else if statement');
    }
}
*/

// loops for

window.onload = function(a) {
    var text = "";
    myArray = [
        "first",
        "second",
        "third",
    ];
    for (i = 0; i < myArray.length; i++) {
        console.log(myArray[i]);
        text += myArray[i] + "\n";
    }
    console.log(text);
};

// while loops
while (i < 10) {
    text += "theNumber is " + i + "\n";
    i++;
}
console.log(text);

// creating objects
//objecr litterals

var car = {
    color: "red",
    model: "accord",
    make: "honda",
};
//function used for initialising new objects
var car = new object();
car.color = "red";
car.model = "accord";
car.make = "honda";

//methods
//objectName.methodName()
//name = employee.fullName()
//stored as property
// done inside constructor function

//<noscript>Sorry, your browser does not support javascript, please update</noscript>

//ineritance using protypes
var TheParent = function() {
    this.name = "TheParent";
};
TheParent.prototype.print = function() {
    console.log(this.name);
};
a = new TheParent();
a.print();

var inherit = function(child, parent) {
    child.prototype = Object.create(parent.prototype);
};
var TheChild = function() {
    this.name = "TheChild";
    this.lastname = "i am the child";
};
inherit(TheChild, TheParent);

var b = new TheChild();
b.print();

//custom objects
function someObject(parameter) {
    this.propertyOne = parameter;
    this.propertyTwo = "a second property";
}

someObject.prototype.printPropOne = function() {
    console.log(this.propertyOne);
};

someObject.prototype.printPropTwo = function() {
    console.log(this.propertyTwo);
};

var myobject = new someObject("Hello World");
console.log(myobject);

myobject.printPropOne();
myobject.printPropTwo();