
var a = "ddd";
typeof a;// string
a instanceof String;//false
var a = new String("dd");
typeof a;//object;
a instanceof String;

123.2.toFixed(2);
var a = "dd";
a.length;
a.charAt(0);

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


var myArray = [1, 2, 3];
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