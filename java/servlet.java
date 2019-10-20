http://localhost:8080/test/test.jsp?p=fuck
request.getScheme()+"://"+request.getServerName()+":"+request.getServerPort();
request.getContextPath:/test 
request.getServletPath:/test.jsp 
request.getRequestURI:/test/test.jsp 
request.getRequestURL:http://localhost:8080/test/test.jsp 
request.getRealPath:D:\Tomcat 6.0\webapps\test\ 
request.getServletContext().getRealPath:D:\Tomcat 6.0\webapps\test\ 
request.getQueryString:p=fuck

ServletConfig config = httpServlet .getServletConfig();
config.getInitParameter("charset"); 
Enumeration e = config.getInitParameterNames();
while(e.hasMoreElements()){
      String name = (String) e.nextElement();
      String value = config.getInitParameter(name);
} 

ServletContext context = httpServlet.getServletContext();
context.setAttribute("data", "aaaaaaaaaa");
String username = context.getInitParameter("username");
context.getMimeType(filename)
String realpath = context.getRealPath("/db.properties"); //root
InputStream in = context.getResourceAsStream("/db.properties"); 
URL url = context.getResource("/db.properties");
InputStream in = url.openStream(); 

Test.class.getResource("");//class dir  file:/D:/work_space/java/bin/net/swiftlet/
Test.class.getResource("/")//ClassPath  file:/D:/work_space/java/bin/
A.class.getResourceAsStream("1.txt")//class dir
A.class.getResourceAsStream("../2.txt")//class dir
A.class.getResourceAsStream("/com/github/demo/1.txt")；//ClassPath 
Test.class.getClassLoader().getResource("");//file:/D:/work_space/java/bin/
Test.class.getClassLoader().getResource("/");null;
ClassLoader loader = StudentDao.class.getClassLoader();
URL url = loader.getResource("cn/itcast/dao/db.properties");


String value = request.getParameter("name");
String values[] = request.getParameterValues("name");
Map<String,String[]> map = request.getParameterMap(); 
InputStream in = request.getInputStream();  //这种方式只用在文件上传上
request.getHeader("referer");
request.setCharacterEncoding("UTF-8");  //只对post提交有效
String username = request.getParameter("username");
username = new String(username.getBytes("iso8859-1"),"UTF-8");//GET
request.getRequestDispatcher("/index.jsp").forward(request, response);//已写入到HttpServletResponse对象中的响应头字段信息保持有效   
request.getRequestDispatcher("/public/head.html").include(request, response); //被包含的Servlet程序不能改变响应消息的状态码和响应头
response.getOutputStream().write("hahahah".getBytes()); 
request.getRequestDispatcher("/public/footer.html").include(request, response);
Cookie cookies[] = request.getCookies();
request.getSesion();

response.setHeader("content-type", "text/html;charset=UTF-8"); 
response.setContentType("image/jpeg");
response.setDateHeader("Cache-Control", no-cache );
response.getOutputStream().write("ggggggg".getBytes());
response.getOutputStream().write((120+"").getBytes("UTF-8"));
response.getWriter().write("<a href='/"+name+"/1.html'>点点</a>");
response.setHeader("content-disposition", "attachment;filename="+URLEncoder.encode(filename, "UTF-8")); 
response.setStatus(302);
response.setHeader("location", "/day06/index.jsp");
response.sendRedirect("/day06/index.jsp");
Cookie cookie = new Cookie("lastAccessTime",System.currentTimeMillis()+"");
cookie.setMaxAge(1*24*60*60);
response.addCookie(cookie); 
response.setHeader("content-encoding", "gzip");

filter.config.getInitParameter("charEnc");
<dispatcher>指定过滤器所拦截的资源被 Servlet 容器调用的方式，可以是REQUEST,INCLUDE,FORWARD和ERROR之一，默认REQUEST

ServletContextListener  HttpSessionListener ServletRequestListener 
ServletContextAttributeListener ，HttpSessionAttributeListener ，ServletRequestAttributeListener
HttpSessionBindingListener HttpSessionActivationListener//实现这两个接口的类不需要 web.xml 文件中进行注册

class MyRequest extends HttpServletRequestWrapper{
    private HttpServletRequest request;
    public MyRequest(HttpServletRequest request) {
      super(request);
      this.request = request;
    }
    @Override
    public String getParameter(String name) {      
      String value = this.request.getParameter(name);
      if(!request.getMethod().equalsIgnoreCase("get")){
        return value;
      }
      if(value==null){
        return null;
      }
      try {
        return value = new String(value.getBytes("iso8859-1"),request.getCharacterEncoding());
      } catch (UnsupportedEncodingException e) {
        throw new RuntimeException(e);
      }      
    }    
  }

class MyResponse extends HttpServletResponseWrapper{
    private ByteArrayOutputStream bout = new ByteArrayOutputStream();
    private PrintWriter pw;
    private HttpServletResponse response;
    public MyResponse(HttpServletResponse response) {
      super(response);
      this.response = response;
    }
    @Override
    public ServletOutputStream getOutputStream() throws IOException {
      return new MyServletOutputStream(bout);    //myresponse.getOutputStream().write("hahah");
    }
    @Override
    public PrintWriter getWriter() throws IOException {
      pw = new PrintWriter(new OutputStreamWriter(bout,response.getCharacterEncoding()));
      return pw;  //MyResponse.getWriter().write("中国");
    }

    public byte[] getBuffer(){
      if(pw!=null){
        pw.close();
      }
      return bout.toByteArray();
    }

  }

class MyServletOutputStream extends ServletOutputStream{
    private ByteArrayOutputStream bout;
    public MyServletOutputStream(ByteArrayOutputStream bout){
      this.bout = bout;
    }
    @Override
    public void write(int b) throws IOException {
      bout.write(b);
    }
  }

public class CountNumListener implements HttpSessionListener { 
      public void sessionCreated(HttpSessionEvent se) {
            ServletContext context = se.getSession().getServletContext();
            Integer count = (Integer) context.getAttribute("count");
            if(count==null){
                  count = 1;
                  context.setAttribute("count", count);
            }else{
                  count++;
                  context.setAttribute("count", count);
            }
      }
      public void sessionDestroyed(HttpSessionEvent se) {
            ServletContext context = se.getSession().getServletContext();
            Integer count = (Integer) context.getAttribute("count");
            count--;
            context.setAttribute("count", count); 
      }

}

 public class SessionScanner implements HttpSessionListener,ServletContextListener { 
          private List<HttpSession> list = Collections.synchronizedList(new LinkedList<HttpSession>());
          private Object lock = new Object();
              public void contextInitialized(ServletContextEvent sce) {    
                    Timer timer = new Timer();
                    timer.schedule(new MyTask(list,lock), 0, 30*1000);
             }

          public void sessionCreated(HttpSessionEvent se) {
                HttpSession session = se.getSession();
                System.out.println(session + "被创建了！！");
                synchronized (lock) {  //锁旗标——防止定时器中删除操作 发生“并发修改异常”。
                      list.add(session);
                }
          }
          public void sessionDestroyed(HttpSessionEvent se) {
                System.out.println(se.getSession() + "被销毁了");
          }
          public void contextDestroyed(ServletContextEvent sce) {
          }
    }

package com.test.servlet3;
 
import javax.servlet.AsyncContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.concurrent.ThreadPoolExecutor;
 
/**
 * Created by wangxindong on 2017/10/19.
 */
@WebServlet(urlPatterns = "/AsyncLongRunningServlet", asyncSupported = true)
public class AsyncLongRunningServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;
 
    protected void doGet(HttpServletRequest request,
                         HttpServletResponse response) throws ServletException, IOException {
        long startTime = System.currentTimeMillis();
        System.out.println("AsyncLongRunningServlet Start::Name="
                + Thread.currentThread().getName() + "::ID="
                + Thread.currentThread().getId());
 
        request.setAttribute("org.apache.catalina.ASYNC_SUPPORTED", true);
 
        String time = request.getParameter("time");
        int secs = Integer.valueOf(time);
        // max 10 seconds
        if (secs > 10000)
            secs = 10000;
 
        AsyncContext asyncCtx = request.startAsync();
        asyncCtx.addListener(new AppAsyncListener());
        asyncCtx.setTimeout(9000);//异步servlet的超时时间,异步Servlet有对应的超时时间，如果在指定的时间内没有执行完操作，response依然会走原来Servlet的结束逻辑，后续的异步操作执行完再写回的时候，可能会遇到异常。
 
        ThreadPoolExecutor executor = (ThreadPoolExecutor) request
                .getServletContext().getAttribute("executor");
 
        executor.execute(new AsyncRequestProcessor(asyncCtx, secs));
        long endTime = System.currentTimeMillis();
        System.out.println("AsyncLongRunningServlet End::Name="
                + Thread.currentThread().getName() + "::ID="
                + Thread.currentThread().getId() + "::Time Taken="
                + (endTime - startTime) + " ms.");
    }
}

package com.test.servlet3;
 
import javax.servlet.AsyncEvent;
import javax.servlet.AsyncListener;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebListener;
import java.io.IOException;
import java.io.PrintWriter;
 
/**
 * Created by wangxindong on 2017/10/19.
 */
@WebListener
public class AppAsyncListener implements AsyncListener {
    @Override
    public void onComplete(AsyncEvent asyncEvent) throws IOException {
        System.out.println("AppAsyncListener onComplete");
        // we can do resource cleanup activity here
    }
 
    @Override
    public void onError(AsyncEvent asyncEvent) throws IOException {
        System.out.println("AppAsyncListener onError");
        //we can return error response to client
    }
 
    @Override
    public void onStartAsync(AsyncEvent asyncEvent) throws IOException {
        System.out.println("AppAsyncListener onStartAsync");
        //we can log the event here
    }
 
    @Override
    public void onTimeout(AsyncEvent asyncEvent) throws IOException {
        System.out.println("AppAsyncListener onTimeout");
        //we can send appropriate response to client
        ServletResponse response = asyncEvent.getAsyncContext().getResponse();
        PrintWriter out = response.getWriter();
        out.write("TimeOut Error in Processing");
    }
}

package com.test.servlet3;
 
import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;
import javax.servlet.annotation.WebListener;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.concurrent.TimeUnit;
 
/**
 * Created by wangxindong on 2017/10/19.
 * 在监听中初始化线程池
 */
@WebListener
public class AppContextListener implements ServletContextListener {
    public void contextInitialized(ServletContextEvent servletContextEvent) {
 
        // create the thread pool
        ThreadPoolExecutor executor = new ThreadPoolExecutor(100, 200, 50000L,
                TimeUnit.MILLISECONDS, new ArrayBlockingQueue<Runnable>(100));
        servletContextEvent.getServletContext().setAttribute("executor",
                executor);
 
    }
 
    public void contextDestroyed(ServletContextEvent servletContextEvent) {
        ThreadPoolExecutor executor = (ThreadPoolExecutor) servletContextEvent
                .getServletContext().getAttribute("executor");
        executor.shutdown();
    }
}

package com.test.servlet3;
 
import javax.servlet.AsyncContext;
import java.io.IOException;
import java.io.PrintWriter;
 
/**
 * Created by wangxindong on 2017/10/19.
 * 业务工作线程
 */
public class AsyncRequestProcessor implements Runnable {
    private AsyncContext asyncContext;
    private int secs;
 
    public AsyncRequestProcessor() {
    }
 
    public AsyncRequestProcessor(AsyncContext asyncCtx, int secs) {
        this.asyncContext = asyncCtx;
        this.secs = secs;
    }
 
    @Override
    public void run() {
        System.out.println("Async Supported? "
                + asyncContext.getRequest().isAsyncSupported());
        longProcessing(secs);
        try {
            PrintWriter out = asyncContext.getResponse().getWriter();
            out.write("Processing done for " + secs + " milliseconds!!");
        } catch (IOException e) {
            e.printStackTrace();
        }
        //complete the processing
        asyncContext.complete();
    }
 
    private void longProcessing(int secs) {
        // wait for given time before finishing
        try {
            Thread.sleep(secs);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}


package com.test.servlet3Noblock;
 
import javax.servlet.AsyncContext;
import javax.servlet.ServletException;
import javax.servlet.ServletInputStream;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
 
/**
 * Created by wangxindong on 2017/10/23.
 */
@WebServlet(urlPatterns = "/AsyncLongRunningServlet2", asyncSupported = true)
public class AsyncLongRunningServlet extends HttpServlet {
    protected void doGet(HttpServletRequest request,
                         HttpServletResponse response) throws ServletException, IOException {
        request.setCharacterEncoding("UTF-8");
        response.setContentType("text/html;charset=UTF-8");
 
        AsyncContext actx = request.startAsync();//通过request获得AsyncContent对象
 
        actx.setTimeout(30*3000);//设置异步调用超时时长
 
        ServletInputStream in = request.getInputStream();
        //异步读取（实现了非阻塞式读取）
        in.setReadListener(new MyReadListener(in,actx));
        //直接输出到页面的内容(不等异步完成就直接给页面)
        PrintWriter out = response.getWriter();
        out.println("<h1>直接返回页面，不等异步处理结果了</h1>");
        out.flush();
    }
 
}

package com.test.servlet3Noblock;
 
import javax.servlet.AsyncContext;
import javax.servlet.ReadListener;
import javax.servlet.ServletInputStream;
import java.io.IOException;
import java.io.PrintWriter;
 
/**
 * Created by wangxindong on 2017/10/23.
 */
public class MyReadListener implements ReadListener {
    private ServletInputStream inputStream;
    private AsyncContext asyncContext;
    public MyReadListener(ServletInputStream input,AsyncContext context){
        this.inputStream = input;
        this.asyncContext = context;
    }
    //数据可用时触发执行
    @Override
    public void onDataAvailable() throws IOException {
        System.out.println("数据可用时触发执行");
    }
 
    //数据读完时触发调用
    @Override
    public void onAllDataRead() throws IOException {
        try {
            Thread.sleep(3000);//暂停5秒，模拟耗时处理数据
            PrintWriter out = asyncContext.getResponse().getWriter();
            out.write("数据读完了");
            out.flush();
            System.out.println("数据读完了");
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
 
    }
 
    //数据出错触发调用
    @Override
    public void onError(Throwable t){
        System.out.println("数据 出错");
        t.printStackTrace();
    }
}