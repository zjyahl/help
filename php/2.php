<?php
abstract  class SimpleClass
{
	const       STAT = 'S' ; 
	static     $stat = 'Static' ;

	const ABC = array('A', 'B', 'C');
    const A = '1';
    const B = '2';
    const C = '3';
    const NUMBERS = array(
        self::A,
        self::B,
        self::C,
    ); 

	public $name, $price, $qty, $total;

	public $bar = 'property'; 
	const bar = 'property'; 
	static  $bar = 'property'; 
    public function bar($sameClassObj) {
    	$sameClassObj->private;
        return 'method';
    }
    static public function getNew()
    {
    	echo static::MY_CONST;
        return new static;
    }

    abstract protected function getValue();

    public function __construct() {
    	parent::__construct();
    	self::STAT; 
		self::$stat;
    }
    function __destruct() {}
    public function __clone(){}

     public function __toString(){}



    }
}
trait ezcReflectionReturnInfo {
	public $x = 1;
    function getReturnType() { /*1*/ }
    public function inc() {
        static $c = 0;
        $c = $c + 1;
        echo "$c\n";
    }
    public static function doSomething() {
        return 'Doing something';
    }
}
}
trait HelloWorld {
    use Hello, World;
}
final  class ExtendClass extends SimpleClass
{
	 use ezcReflectionReturnInfo;
	 use HelloWorld { sayHello as protected; }
	 use HelloWorld { sayHello as private myPrivateHello; }
	 use A, B {
        B::smallTalk insteadof A;
        A::bigTalk insteadof B;
        B::bigTalk as talk;
    }
    final  function displayVar()
    {
        echo "Extending class\n";
        parent::displayVar();
    }
}

interface iTemplate
{
	const b = 'Interface constant';
    public function setVariable($name, $var);
    public function getHtml($template);
}

class Outer
{
    private $prop = 1;
    protected $prop2 = 2;

    protected function func1()
    {
        return 3;
    }

    public function func2()
    {
        return new class($this->prop) extends Outer {
            private $prop3;

            public function __construct($prop)
            {
                $this->prop3 = $prop;
            }

            public function func3()
            {
                return $this->prop2 + $this->prop3 + $this->func1();
            }
        };
    }
}