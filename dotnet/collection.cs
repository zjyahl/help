int[,] a = {{1,2,3},{4,5,6}};
int[,] b =(int[,])a.Clone();
int[,] c = new int[2,3];
c =Array.Copy(a);
Array.sort(a);
Tuple<int, string> a = Tuple.create(1, "tt");
a.Item1,a.Item2; 
a.Equals(a2);//IStructuralEquatable
class TypleComparer: IEqualityCompare
{
	public new bool Equals(object a, object b){return a.Equals(b)}
	public override int GetHashCode(object obj){}
}
a.Equals(a2, new TypleComparer())

List<int> a = new List<int>(){1,2};
Queue, Stack;
LinkedList<int> t;
t.Add(new LinkedListNode<int>(12));
LinkedListNode<int> a ;
a.Previous;
SortList<string, string> a;
Dictionary<string, string> a;
SortDictionary<strin, string> a;
HashSet, SortedSet;