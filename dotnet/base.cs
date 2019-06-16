sbyte a = -1;
short a = -1;
int a = -1;
long a = -1L;
byte a = 1;
ushort a = 1;
uint a = 1;
ulong a = 1UL;
int a = 0x12ab;

int? a = null;
int b = a ?? -1;

float a = -0.1F;
double a = -0.1;
decimal a = -0.1M;

bool a = true;

char a = 'a';

object a = null;
string a = null;
string a = @"c:\t\a";
string a = @"
			ttt
			ttt
			";
string a = $"{var1}";

public enum TimeOfDay 
{
	Morning = 0, //public
	Afrernoon = 1;
}
public enum TimeOfDay:short
{
	Morning = 0,
	Afrernoon = 1
}
TimeOfDay a = TimeOfDay.Moring;
TimeOfDay a = (TimeOfDay)intA;
int intA = (int)a;
string a = aEnum.ToString();
TimeOfDay a = (TimeOfDay) Enum.Parse(typeof(TimeOfDay), "moring", true);
Enum.TryParse<TimeOfDay>("red", out a);
foreach (TimeOfDay suit in Enum.GetValues(typeof(TimeOfDay)))
{
    Console.WriteLine((int)suit+ ":" + suit);
}
[Flags]
enum DaysOfWeek
{
	Monday = 0x1,
	Tuesday = 0x2,
	Wednesday = 0x4,
	T = Tuesday | Wednesday
}
DaysOfWeek morAndTu = DaysOfWeek.Monday | DaysOfWeek.Tuesday;


if(true)else if(true) else{}
switch(a)
{
	case 1:
		break;
	default:
		break;
}
for(int i=0; i<5; i++){}
while(true){continue;}
do{}while(true)
foreach(var a in as){}

goto label;
label:
var a = 12;


1  left right   [] () . ->(point)    
2  right left   - (int) ++ --  *(point) &(address) ! ~ sizeof
3  left right   / * %
4  left right   + -
5  left right   << >>
6  left right   > >= < <=
7  left right   == !=
8  left right   &
9  left right   ^
10  left right   |
11  left right   &&
12  left right   ||
13  right left   ?a:b 
14  right left    = /= *= += -= >>= <<= &= ^= !=
15  left right   ,

fun(1,2);
fun(a:1, b:2);

fun(ref a, out b);
is, as
a?.b();
var a = new WeakReference(new A());
if(a.IsAlive)
{
	A t = a.Target as A;
}

/* */
//
#defing DEBUG
#Undef defing
#if DEBUG
 #elif TT && (YY == false)
#else
#endif