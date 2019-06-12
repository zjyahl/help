var query = from r in persions
            where r.Money == 111.2
            orderby r.Age descending
            select r;
var query = (from r in persions
            where r.Money == 111.2
            orderby r.Age descending
            select r).ToList();
var query = persions.Where((r, inx) => r.Age == 2);
var query = list.OfType<string>;
var query = from r in persions
			from c in r.Cars
            where r.Money == 111.2 && c=="rr"
            orderby r.Age descending
            select r.Name;
var query = (from r in persions
            where r.Money == 111.2
            select r).Take(10);

var query = from r in list
group r by r.a into g
orderby g.Count() descending, g.Key
where g.Count()>2
select new {Country = g.key, count = g.Count()};

var query = from r in list
group r by r.a into g
let count = g.Count()
orderby count descending, g.Key
where count>2
select new {Country = g.key, count = g.Count(),
			Racers = from r1 in g
			select r1.name
			};

var query = from r in query1
join t in query2 on r.a equals t.a1
select new {r.year,t.a
			};

var query = from r in query1
join t in query2 on r.a equals t.a1 into rt
from t in rt.DefaultIfEmpty()
select new {r.year,Vv = t==null?"":t.name
			};

var GroupQuery = from publisher in SampleData.Publishers
                 join book in SampleData.Books
                      on publisher equals book.Publisher into publisherBooks
                 select new
                 {
                     PublisherName = publisher.Name,
                     Books = publisherBooks
                 };
 var crossJoinQuery = from publisher in SampleData.Publishers
                                 from book in SampleData.Books
                                 select new
                                 {
                                     PublisherName = publisher.Name,
                                     BookName = book.Title
                                 };

List<DeptInfo> deptList = (from emp in empList
                                where emp.Status == "在职"            //筛选“在职”员工     
                                orderby emp.DeptID ascending          //按“部门ID”排序
                                group emp by new                      //按“部门ID”和“部门名称”分组
                                {
                                    emp.DeptID,
                                    emp.DeptName
                                }
                                into g
                                select new DeptInfo()
                                {
                                    DeptID = g.Key.DeptID,
                                    DeptName = g.Key.DeptName,
                                    EmplayeeCount = g.Count(),          //统计部门员工数量
                                    WageSum = g.Sum(a => a.Wage),       //统计部门工资总额
                                    WageAvg = g.Average(a => a.Wage),   //统计部门平均工资
                                    EmplayeeList = (from e in g         //归集部门员工列表
                                                    select new Emplayee()
                                                    {
                                                        EmpID = e.EmpID,
                                                        EmpName = e.EmpName
                                                    }
                                                    ).ToList()
 
                                }).ToList();
