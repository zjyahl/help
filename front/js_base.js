var a = 42;
a.toString();
var b = a + ""; // 隐式强制类型转换
var c = String(a); // 显式强制类型转换
var a = {
    valueOf: function () {
        return "42";
    }
};
var b = {
    toString: function () {
        return "42";
    }
};//valueOf  toString
var c = [4, 2];
c.toString = function () {
    return this.join(""); // "42"
};
Number(a); // 42
Number(b); // 42
Number(c); // 42
Number(""); // 0
Number([]); // 0
Number(["abc"]); // NaN
var c = "3.14";
var d = 5 + +c;//8.14
var timestamp = +new Date();
~42; // -(42+1) ==> -43
0 | -0; // 0
0 | NaN; // 0
0 | Infinity; // 0
0 | -Infinity; // 0
Math.floor(-49.6); // -50
~~-49.6; // -49
Number(b); // NaN
var b = "42px";
parseInt(b); // 42
var a = {
    num: 21,
    toString: function () { return String(this.num * 2); }
};
parseInt(a); // 42
parseInt(0.000008); // 0 ("0" 来自于 "0.000008")
parseInt(0.0000008); // 8 ("8" 来自于 "8e-7")
parseInt(false, 16); // 250 ("fa" 来自于 "false")
parseInt(parseInt, 16); // 15 ("f" 来自于 "function..")
parseInt("0x10"); // 16
parseInt("103", 2); // 2
if (typeof DEBUG !== "undefined") {
    console.log("Debugging is starting");
}

Object.prototype.toString.call([1, 2, 3]);
var a = "ddd";
typeof a;// string
a instanceof String;//false
var a = new String("dd");
typeof a;//object;
a instanceof String;
a.valueOf(); // "abc

123.2.toFixed(2);// str 123.20
42..tofixed(3);
//42 .toFixed(3);
var a = .12;
a = 12.;
a = 5E10;
a.toExponential();
a.toPrecision(2);//total len
0xf3;
0363;
0b11110011;
if (!Number.EPSILON) {
    Number.EPSILON = Math.pow(2, -52);
}
function numbersCloseEnoughToEqual(n1, n2) {
    return Math.abs(n1 - n2) < Number.EPSILON;
}
Number.MIN_VALUE;
Number.MAX_SAFE_INTEGER//2^53 - 1
Number.isInteger(42); // true
Number.isInteger(42.000); // true
if (!Number.isInteger) {
    Number.isInteger = function (num) {
        return typeof num == "number" && num % 1 == 0;
    };
}
Number.isSafeInteger(Number.MAX_SAFE_INTEGER); // true
Number.isSafeInteger(Math.pow(2, 53)); // false
Number.isSafeInteger(Math.pow(2, 53) - 1); // true
if (!Number.isSafeInteger) {
    Number.isSafeInteger = function (num) {
        return Number.isInteger(num) &&
            Math.abs(num) <= Number.MAX_SAFE_INTEGER;
    };
}
a | 0;// 可以将变量 a 中的数值转换为 32 位有符号整数
var a = 2 / "foo"; // NaN
typeof a === "number"; // true
sNaN(a); // true
if (!Number.isNaN) {
    Number.isNaN = function (n) {
        return (
            typeof n === "number" &&
            window.isNaN(n)
        );
    };
}
if (!Number.isNaN) {
    Number.isNaN = function (n) {
        return n !== n;
    };
}
void 0;//undefined
Number.POSITIVE_INfiNITY;
var a = 1 / 0; // Infinity
var b = -1 / 0; // -Infinity
+"-0"; // -0
Number("-0"); // -0
JSON.parse("-0"); // -0
0 > -0; // false
function isNegZero(n) {
    n = Number(n);
    return (n === 0) && (1 / n === -Infinity);
}
Object.is(a, NaN); // true
Object.is(b, -0); // true
if (!Object.is) {
    Object.is = function (v1, v2) {
        // 判断是否是-0
        if (v1 === 0 && v2 === 0) {
            return 1 / v1 === 1 / v2;
        }
        // 判断是否是NaN
        if (v1 !== v1) {
            return v2 !== v2;
        }
        // 其他情况
        return v1 === v2;
    };
}

var a = "dd";
a.length;
a.charAt(0);
a.indexOf("o");
var c = a.concat("bar");
a.toUpperCase();
Array.prototype.join.call(a, "-");
Array.prototype.map.call(a, function (v) {
    return v.toUpperCase() + ".";
}).join("");
var c = a
    // 将a的值转换为字符数组
    .split("")
    // 将数组中的字符进行倒转
    .reverse()
    // 将数组中的字符拼接回字符串
    .join("");
var h = new RegExp("^a*b+", "g");
var i = /^a*b+/g;

var { a, b } = getData();

let id1 = Symbol('id');
let id2 = Symbol('id');
console.log(id1 == id2);  //false
let name1 = Symbol.for('name'); //检测到未创建后新建
let name2 = Symbol.for('name'); //检测到已创建后返回
console.log(name1 === name2); // true
console.log(Symbol.keyFor(name1));  // 'name'
let id = Symbol("id");
let obj = {
    [id]: 'symbol'
};
for (let option in obj) {
    console.log(obj[option]); //空
}
let array = Object.getOwnPropertySymbols(obj);
console.log(array); //[Symbol(id)]
console.log(obj[array[0]]);  //'symbol'

if (!Date.now) {
    Date.now = function () {
        return (new Date()).getTime();
    };
}

throw new Error("x wasn’t provided");

var myArray = [1, 2, 3];
myArray.length = 0;
var d = myArray.concat(["b", "a", "r"]);
b.push("!");
for (var v of myArray) {
    console.log(v);
}
var myArray = [1, 2, 3];
var it = myArray[Symbol.iterator]();
it.next(); // { value:1, done:false }
it.next(); // { value:2, done:false }
it.next(); // { value:3, done:false }
it.next(); // { done:true }

var a = {
    tt: 2
};
a.tt;
a["tt"];
delete a.tt;
var prefix = "foo";
var myObject = {
    [prefix + "bar"]: "hello",
};
myObject["foobar"]; // hello

var myArray = ["foo", 42, "bar"];
myArray["3"] = "baz";

var newObj = JSON.parse(JSON.stringify(someObj));
var newObj = Object.assign({}, myObject, myObject2);

var myObject = {};
Object.defineProperty(myObject, "a", {
    value: 2,
    writable: true,
    configurable: true,// no cfg del
    enumerable: true//for..in myObject.propertyIsEnumerable( "a" ); Object.keys( myObject );
});
Object.preventExtensions(myObject);
Object.seal(myObject);//preventExtensions cfg false
Object.freeze(myObject);//seal writable false

Object.defineProperty(
    myObject, // 目标对象
    "b", // 属性名
    { // 描述符
        // 给 b 设置一个 getter
        get: function () { return this.a * 2 },
        // 确保 b 会出现在对象的属性列表中
        enumerable: true
    }
);
var myObject = {
    // 给 a 定义一个 getter
    get a() {
        return this._a_;
    },
    // 给 a 定义一个 setter
    set a(val) {
        this._a_ = val * 2;
    }
};
("b" in myObject); //Prototype
myObject.hasOwnProperty("a"); // self
Object.prototype.hasOwnProperty.call(myObject, "a");
Object.getOwnPropertyNames(myObject);

Object.defineProperty(myObject, Symbol.iterator, {
    enumerable: false,
    writable: false,
    configurable: true,
    value: function () {
        var o = this;
        var idx = 0;
        var ks = Object.keys(o);
        return {
            next: function () {
                return {
                    value: o[ks[idx++]],
                    done: (idx > ks.length)
                };
            }
        };
    }
});
var it = myObject[Symbol.iterator]();
it.next(); // { value:2, done:false }
it.next(); // { value:3, done:false }
it.next(); // { value:undefned, done:true }
// 用 for..of 遍历 myObject
for (var v of myObject) {
    console.log(v);
}
var randoms = {
    [Symbol.iterator]: function () {
        return {
            next: function () {
                return { value: Math.random() };
            }
        };
    }
};


function Vehicle() {
    this.engines = 1;
}
Vehicle.prototype.ignition = function () {
    console.log("Turning on my engine.");
};
Vehicle.prototype.drive = function () {
    this.ignition();
    console.log("Steering and moving forward!");
};
Vehicle.prototype.constructor === Vehicle;
var a = new Vehicle()
Object.getPrototypeOf(a) === Vehicle.prototype;
a.constructor === Vehicle;

Foo.prototype = { /* .. */ };
Object.defineProperty(Foo.prototype, "constructor", {
    enumerable: false,
    writable: true,
    configurable: true,
    value: Foo // 让 .constructor 指向 Foo
});

function Foo(name) {
    this.name = name;
}
Foo.prototype.myName = function () {
    return this.name;
};
function Bar(name, label) {
    Foo.call(this, name);
    this.label = label;
} // 我们创建了一个新的 Bar.prototype 对象并关联到 Foo.prototype
Bar.prototype = Object.create(Foo.prototype);
Bar.prototype = new Foo();//可能会产生一些副作用

// ES6 之前需要抛弃默认的 Bar.prototype
Bar.ptototype = Object.create(Foo.prototype);
// ES6 开始可以直接修改现有的 Bar.prototype
Object.setPrototypeOf(Bar.prototype, Foo.prototype);

Foo.prototype.isPrototypeOf(a);
Object.getPrototypeOf(a) === Foo.prototype;

var anotherObject = {
    a: 2
};
// 创建一个关联到 anotherObject 的对象
var myObject = Object.create(anotherObject);
var myObject = Object.create(anotherObject, {
    b: {
        enumerable: false,
        writable: true,
        configurable: false,
        value: 3
    },
    c: {
        enumerable: true,
        writable: false,
        configurable: false,
        value: 4
    }
});

function* foo(x) {
    var y = x * (yield "Hello"); // <-- yield一个值！
    return y;
}
var it = foo(6);
var res = it.next(); // 第一个next()，并不传入任何东西
res.value; // "Hello"
res = it.next(7); // 向等待的yield传入7
res.value; // 42

var something = (function () {
    var nextVal;
    return {
        // for..of循环需要
        [Symbol.iterator]: function () { return this; },
        // 标准迭代器接口方法
        next: function () {
            if (nextVal === undefined) {
                nextVal = 1;
            }
            else {
                nextVal = (3 * nextVal) + 6;
            }
            return { done: false, value: nextVal };
        }
    };
})();

function* something() {
    try {
        var nextVal;
        while (true) {
            if (nextVal === undefined) {
                nextVal = 1;
            }
            else {
                nextVal = (3 * nextVal) + 6;
            }
            yield nextVal;
        }
    }
    // 清理子句
    finally {
        console.log("cleaning up!");
    }
}
var it = something();
for (var v of it) {
    console.log(v);
    // 不要死循环！
    if (v > 500) {
        console.log(
            // 完成生成器的迭代器
            it.return("Hello World").value
        );
        // 这里不需要break
    }
}
// 1 9 33 105 321 969
// 清理！
// Hello World

[...arr1, ...arr2, ...arr3];
[...'hello'];



var name1 = "李四";
var name2 = "张三";
export { name1, name2 }
import { name1 as a, name2 } from "/.a.js" 

var name="李四";
export default name
import name from "/.a.js"