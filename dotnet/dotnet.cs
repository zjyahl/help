sbyte short int long 
byte unshort uint unlong // 12UL
float double decimal//128 12.3M
char string bool

switch(a)
{
	case "a":
	goto case "dd";
} 
goto label;

label:
-----

enum TimeOfDay
{
	Moring = 0;
}
TimeOfDay.Moring;
TimeOfDay.Moring.ToString();
TimeOfDay a = (TimeOfDay) Enum.Parse(typeof(TimeOfDay), "moring", true);
foreach (TimeOfDay suit in Enum.GetValues(typeof(TimeOfDay)))
{
    Console.WriteLine((int)suit+ ":" + suit);
}
namespace aa.bb;
using System;
using a = TT;
a::t;
static void Main(string args[]);
#defing DEBUG
#Undef defing
#if DEBUG
 #elif TT && (YY == false)
#else
#endif
const int a;
readonly;
class A
{
	static A(){}
}
var tt = new {Tt = 12, a.YY};
struct A{};
A a;
A a = new A();
ref out
int? a = null;
int b = a.HasValue ? a.Value : -1;
b = a ?? -1;
PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
(int a, int b) => a*b;
IComparable

IEnumerable, IEnumerator

void print(params  object[]  objs){}

public static class ClassA  
public static class StringHelper
{
    //扩展方法必须为静态的
    //扩展方法的第一个参数必须由this来修饰（第一个参数是被扩展的对象）
    public static bool isEmail(this string _string)
    {
        return Regex.IsMatch(_string, 
            @"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");
    }
}

string txt = @"
			dfdfdfdfdfdf
";
char a= txt[2];
foreach(char a in txt){}
string.Format("{0:000.000}", 12.2);//012.200
string.Format("{0:#.##}", "12.799");
string.Format("{0:N3}", 250000.777888);//250,000.778
string.Format("{0:P1}", 0.24583);//24.6% 
string.Format("{0:X2}",10)//0A
DateTime.Now.ToString("yyyy-M-d H:m:s");
DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff")
string.Format("{0:yyyy_MM_dd HH:mm:ss}", dtime);
string a = $"{txt}";
StringBuilder a;

DateTime dt = DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

DateTime dt;
DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
dtFormat.ShortDatePattern = "yyyy/MM/dd";
dt = Convert.ToDateTime("2011/05/26", dtFormat);

DateTime timeUtc = DateTime.UtcNow;
TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
DateTime cstTime = TimeZoneInfo.ConvertTime(timeUtc, cstZone);

DateTime cstTime = DateTime.Now;
DateTime timeUtc = TimeZoneInfo.ConvertTime(cstTime, TimeZoneInfo.Utc);

static double ToTimestamp(DateTime value)
{
    TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
    return (double)span.TotalSeconds;
}

static DateTime ConvertTimestamp(double timestamp)
{
    DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);
    DateTime newDateTime = converted.AddSeconds(timestamp);
    return newDateTime.ToLocalTime();
}

const string pattern = @"(?<tt>a.*?b)";
string text = "g a1b fft ayyoooob";
var reg = new Regex(pattern,RegexOptions.IgnoreCase);
MatchCollection marches = reg.Matches(text);
foreach (Match match in marches)
{
    Console.WriteLine($"match {match.Index} {match.ToString()}");
    foreach(Group g in match.Groups)
    {
        if(g.Success)
        {
            Console.WriteLine($"group {g.Index} {g.Value}");
        }
    }
    foreach (string name in reg.GetGroupNames())
    {
        Console.WriteLine($"group {name} {match.Groups[name].Value}");
    }
}


Path.Combine(@"D:\a", "dd.txt");
File.Copy(filePath, filePath2,true);
var file = new FileInfo(filePath);
File.WriteAllText(filePath, "");
File.WriteAllLines(filePath, string []);
File.AppendAllLines(filePath, string []);

string[] lines = File.ReadAllLines(filePath);
IEnumerable<string> lines = File.ReadAllLines(filePath);

IEnumerable<string> fileNames = Directory.EnumerateFiles(dir,"*.xml");
foreach(var fileName in fileNames)
{
    WriteLine(fileName);
}

DataTable dt = otherdt.GetChanges(DataRowState.Added);
dt.AcceptChanges();

foreach (var item in dct)
{
    Console.WriteLine(item.Key + item.Value);
}
 foreach (KeyValuePair<string, int> kv in list)
{
    Console.WriteLine(kv.Key + kv.Value);
}