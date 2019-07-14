(p.foo = o.foo)(); // foo 默认绑定
var bar = foo.bind(obj);
[1, 2, 3].forEach(foo, obj);
function foo(p1, p2) {
	this.val = p1 + p2;
}
var bar = foo.bind(null, "p1");
var baz = new bar("p2");
baz.val; // p1p2
for (var i = 1; i < 5; i++) {
	(
		function (j) {
			setTimeout(function timer() { console.log(j); }, 1000);
		}
	)(i);
}
for (let i = 1; i < 5; i++)//i loop declare
{
	setTimeout(function timer() { console.log(i); }, 1000);
}
var obj = {
	count: 0,
	cool: function coolFn() {
		if (this.count < 1) {
			setTimeout(() => {
				this.count++;
			}, 100);
		}
	},
	cool2: function coolFn() {
		var self = this;
		if (self.count < 1) {
			setTimeout(function timer() {
				self.count++;
			}, 100);
		}
	}
};

var MyModules = (function Manager() {
	var modules = {};
	function define(name, deps, impl) {
		for (var i = 0; i < deps.length; i++) {
			deps[i] = modules[deps[i]];
		}
		modules[name] = impl.apply(impl, deps);
	}
	function get(name) {
		return modules[name];
	}
	return {
		define: define,
		get: get
	};
})();

function bind(fn, obj) {
	return function () {
		return fn.apply(obj, arguments);
	};
}

if (!Function.prototype.bind) {
	Function.prototype.bind = function (oThis) {
		if (typeof this !== "function") {
			// 与 ECMAScript 5 最接近的
			// 内部 IsCallable 函数
			throw new TypeError(
				"Function.prototype.bind - what is trying " +
				"to be bound is not callable"
			);
		}
		var aArgs = Array.prototype.slice.call(arguments, 1),
			fToBind = this,
			fNOP = function () { },
			fBound = function () {
				return fToBind.apply(
					this instanceof fNOP &&
						oThis ? this : oThis
					,
					aArgs.concat(
						Array.prototype.slice.call(arguments)
					)
				);
			};
		fNOP.prototype = this.prototype;
		fBound.prototype = new fNOP();
		return fBound;
	};
}

