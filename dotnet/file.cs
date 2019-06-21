DriveInfo[] drivers = DriveInfo.GetDrivers();
foreach( var driver in drivers)
{
	if(driver.IsReady){}
}
Path.Combine(@"D:\a", "dd.txt");
Environment.GetEnvironmentVariable("HOMEDRIVER");
Path.Combine(
	Environment.GetEnvironmentVariable("HOMEDRIVER"),
	Environment.GetEnvironmentVariable("HOMEPATH"),
	"documents");
Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

string[] dirs = Directory.GetDirectories(@"G:\source");
string[] files = Directory.GetFiles(path);

File.WriteAllText(fileName, "data");
var file = new FileInfo(@".\1.txt");
fileCopyTo(@"c:\1.txt");
File.Copy(@"srcpath", @"topath");
var folder = new DirectoryInfo("dir");
File.ReadAllText(filePath);
string[] lines = File.ReadAllLines(filePath);
IEnumerable<string> lines = File.ReadAllLines(filePath);
IEnumerable<string> fileNames = Directory.EnumerateFiles(dir,"*.xml");
File.AppendAllLones(fileName, stringArr);
Path.GetFileNameWithoutExtension(fileName);

FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
f.CanRead;

long origPos = stream.Seek(0, SeekOrigin.Begin);
byte[] b = new byte[4];
stream.Read(b, offset:0, count:4);
int nByte = stream.ReadByte();
byte2 = Convert.ToByte(stream.ReadByte());

StreamReader;
StreamWriter;
BinaryReader;
BinaryWriter;

var stream = File.OpenWrite(filePath);
stream.CopyTo(outStream);
if (byte1 == 0xFF && byte2 == 0xFE && byte3 == 0 && byte4 == 0)
{
	Encoding.UTF32;
}
if (byte1 == 0xFF && byte2 == 0xFE && byte3 != 0xFF)
{
	Encoding.Unicode;
}
if (byte1 == 0xFE && byte2 == 0xFF)   
{
    Encoding.BigEndianUnicode;
}
if (byte1 == 0xEF && byte2 == 0xBB && byte3 == 0xBF) 
{
    Encoding.UTF8;
}


if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
{
   Encoding.BigEndianUnicode;
}
else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
{
    Encoding.Unicode;
}
else
{
    if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
    {
        reVal = Encoding.UTF8;
    }
    else
    {
        int i;
        int.TryParse(fs.Length.ToString(), out i);
        ss = r.ReadBytes(i);
        if (IsUTF8Bytes(ss))
            reVal = Encoding.UTF8;
    }
}
private static bool IsUTF8Bytes(byte[] data)
{
    int charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数   
    byte curByte; //当前分析的字节.   
    for (int i = 0; i < data.Length; i++)
    {
        curByte = data[i];
        if (charByteCounter == 1)
        {
            if (curByte >= 0x80)
            {
                //判断当前   
                while (((curByte <<= 1) & 0x80) != 0)
                {
                    charByteCounter++;
                }
                //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　   
                if (charByteCounter == 1 || charByteCounter > 6)
                {
                    return false;
                }
            }
        }
        else
        {
            //若是UTF-8 此时第一位必须为1   
            if ((curByte & 0xC0) != 0x80)
            {
                return false;
            }
            charByteCounter--;
        }
    }
    if (charByteCounter > 1)
    {
        throw new Exception("非预期的byte格式!");
    }
    return true;
}
