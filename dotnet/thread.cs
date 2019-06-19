IAsyncResult ar=delegateF.BeginInvoke(3,"str参数",null,"AsycState:OK");
int result = f.EndInvoke(ar);

void CallBack(IAsyncResult result) 
{ 
    Fun1 handler = (result as AsyncResult).AsyncDelegate as DoWorkHandler; 
    handler.EndInvoke(result);
    result.AsyncState;
 }



string a = Task.CurrentId?ToString() ?? "no task";
a = Thread.CurrentThread.ManagedThreadId;
bool a = Thread.CurrentThread.IsThreadPoolThread;
a = Thread.CurrentThread.IsBackground;

vart tf = new TaskFactory();
Task t1 = ft.SratrNew(method, obj);
Task.Factory.SratrNew(method, obj);
new Task(method, obj).Start;
Task.Run(()=>method(obj));

Task t = new Task(method, obj);
t.RunSynchronously();

var t = new Task(method, obj, TaskCreationOptions.LongRunning);

var t = new Task<string>(method, obj);
t.Result;
t.Wait();

void method(Task t)
{

}
Task task2 = task1.ContinueWith(method, TaskContinuationOptions.OnlyOnFaulted);
task1.ContinueWith(method2, TaskContinuationOptions.OnlyOnFaulted);
task1.start();

void parent()
{
    Task child = new Task(method);//TaskCreationOptions.DetachedFromParent
    child.Start();
}
Task t = new Task(parent);
t.Start();
t.Status; //WaitingForChildrenToComplete

Task<string> t = Task.FromResult<string>(new string("ddd"));

var cts = new CancellationTolenSource();
cts.Token.Register(()=>WriteLine("cancel"));
cts.CancelAfter(500);
var t1 = Task.Run(()=>
    {
        CancellationToken token = cts.Token;
        if(token.isCancellationRequested)
        {
            token.ThrowIfCancellationRequested();
        }
    }, cts.Token);
try
{
    t1.Wait()
}
catch(AggregateException ex)
{
    foreach(var inex in ex.InnerExceptions)
    {

    }
}


static event EventHandler<AggregateExceptionArgs> AggregateExceptionCatched;
static void TestThree()
{
    AggregateExceptionCatched += new EventHandler<AggregateExceptionArgs>(Program_AggregateExceptionCatched);

    Task t1 = new Task(() =>
    {
        try
        {
            throw new InvalidOperationException("任务并行编码 中产生未知错误");
        }
        catch (Exception ex)
        {
            AggregateExceptionArgs args = new AggregateExceptionArgs()
            {
                AggregateException = new AggregateException(ex)
            };
            AggregateExceptionCatched?.Invoke(null, args);
        }
    });
    t1.Start();
}
static void Program_AggregateExceptionCatched(object sender, AggregateExceptionArgs e)
{
    foreach (var item in e.AggregateException.InnerExceptions)
    {
        Console.WriteLine("异常类型：{0}{1}来自：{2}{3}异常内容：{4}",
            item.GetType(), Environment.NewLine, item.Source,
            Environment.NewLine, item.Message);
    }
}
public class AggregateExceptionArgs : EventArgs
{
    public AggregateException AggregateException { get; set; }
}

Task<string>  method()
{
    return Task.Run<string>(()=>{fun1();})
}
async call()
{
    string result = await method();

    await Task.WhenAll(task1,task2);
    string[] res = await Task.WhenAll(task1,task2);
}
IAsyncResult BeginMethod(sting name, AsyncCallback callback, object state)
{
    return delegateF.BeginInvoke(name, callback, state);
}
string EndMethod(IAsyncResult ar)
{
    return delegateF.EndInvoke(ar);
}
string s = await Task<string>.Factory.FromAsynv<string>(BeginMethod, EndMethod, "name", "state");


Task res = null;
try
{
    await(res = ask.WhenAll(task1,task2));
}
catch(Exception ex)
{
    foreach (var item in res.Exception.InnerExceptions){}
}