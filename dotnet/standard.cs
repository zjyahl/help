class A: IDisposable
{
	private bool _isDisposed = false;
	
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	protected virtual void Dispose(bool disposing)
	{
		if(!_isDisposed)
		{
			if(disposing)
			{

			}
			_isDisposed = true;
		}
	}
	~A()
	{
		Dispose(false);
	}
}
using(var a = new A()){}

class A: IEnumerable, IComparable<A>,IFormattable IEquatable<A>
{
	public IEnumerator GetEnumerator()
	{
		while(true){yield return a}
	}
	
	public override bool Equals(Object a){}
 	public override int GetHashCode(){}
 	public override string ToString(){}

 	public int CompareTo(A a){}
 	public string ToString(string format, IFormatProvider formatProvider){}
 	public  bool Equals(A a){}
 	//IEquatable Arry Tuple (a1 as IStructuralEquatable).Equals(a2,EqualityComparer<A>.Default) == true

}
class xcomparer: IComparer<A>{public int Compare(A a, A b){}}

public class DocumentManager<TDocument> where TDocument:IDocument
{
	private TDocument t = default(TDocument);
	
	void Swap<T>(ref T x){}
}
class A<out T>
{
	T fun1(){}
}
class A<in T>
{
	void fun2(T t);
}
T:struct  T:class T:new() T:T2  T:IFoo,new()
Foo<string> t = new Foo<string>();
Foo<string>.a = 66;