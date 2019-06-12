<?php
namespace NS {
    class ClassName {
    }
    
    echo ClassName::class;
}
$x = new stdClass;
$x->a = 22;
$y = (object) null;  
$z = (object) 'a';         // creates property 'scalar' = 'a'
$a = (object) array('property1' => 1, 'property2' => 'b');
(array) $obj;

$a = new A();
$a->foo();
$obj->{'ref-type'} = 'Journal Article';
A::foo();
$className = 'A';
$instance = new $className();
$reference =& $instance;

$obj instanceof Obj;
$obj1 instanceof $obj2;
is_subclass_of($obj, 'Class');
get_parent_class($obj);


Clas::staticfun(); 
$obj->staticfun();

$obj = new Foo();
echo var_dump($obj->a);
$obj->a=function(){echo 'ok\n';};
($obj->a)();
$obj->a=99;

if (method_exists($this, ($method = 'isset_'.$name)))
{
  return $this->$method();
}
$example = function () use (&$message) {
    var_dump($message);
};

call_user_func(function(){
    $arg = func_get_arg(0); 
    $args = func_get_args();
    if(func_num_args() == 1)
        return $args[0];
},$arg1,$arg2);
call_user_func("Func::_func",'hell world');
call_user_func(array('Func','_func'));

call_user_func(array($obj,'__func'),$num);

call_user_func_array("foobar", array("one", "two"));

call_user_func_array(array($foo, "bar"), array("three", "four"));

""、0、"0"、NULL、、FALSE、array()、var $var; obj no property empty;
