var a = new {A1 = 12};
class ClassA: A, It
{
	public const int a = 12;
	protected int a2;
	protected internal int a3;
	static readonly int a4;
	private string _firstName;
	public string FirstName
	{
		get{return _firstName;}
		set{_firstName = value;}
	}
	public int Age{get;private set;}
	string Id{get;} = "ddd";
	string FullName => $ "{initedvar}";

	ClassA(int a, int b){}
	ClassA(int a): this(a, 12){}

	static ClassA(){}


	bool fun1(int a) => a ==2;
	string fun1(string a) => "ddd";

	bool fun2(int a, int b=2) => a ==2;

	bool fun3(int a, params int[] data) => true;

	ClassB fun4(ClassB b) => b ?? (b = new ClassB());

	bool fun5(ref int a, out int b) => true;

}
struct StrA{}
StrA a = new StrA();
StrA a ;// no init value
partial class A
{
	void tt()
	{
		add();
	}
	partial void add(); // must return void and param void
}

public static class StringExt // same call namespace
{
	public static int add(this string s)=> s.length;
}

class A
{
	virtual string Name{get;set;}
	virtual bool add()=>true;
}
class B: A
{
	override bool add()=>base.add();

	new bool add2()=>true;
}
//abstract fun override
interface IA
{

}