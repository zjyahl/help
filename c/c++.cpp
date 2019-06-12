
class ClassA
{
public:
    ClassA(int a):g(12),a7(0),a8(a)
    {

    }
    int getLen() const;
    const char& operator[](std::size pos) const{}
    char& operator[](std::size pos){
        return const_cast<char&>(
                static_cast<const ClassA&>(*this)[pos]
                );
    }
    virtual ~ClassA()=0;
private:
    enum Enu
    {
        A1,B1
    };
    const int a =12;
    const int * a4 = &a;
    const double a5;
    const int a6;
    int  a7;
    int& a8;
    char a2[A1];
    char a3[a];
    mutable int len;   
    ClassA(const ClassA&);
    ClassA& operator=(const ClassA&);
};

ClassA::~ClassA(){}
const int ClassA::a;// fetch a address
const double ClassA::a5 = 11.6;
int ClassA::getLen() const
{
    len = 99;
    return len;


std::function<void()> func_1 = [](){cout << "hello world" << endl;};  
std::function<void(const Foo&,int)> f_add_display = &Foo::print_add;
Foo foo(2);
f_add_display(foo,1);

auto f1 = std::bind(fun,1,2,3); 
auto f2 = std::bind(fun, placeholders::_1,placeholders::_2,3);
auto f3 = std::bind(fun,placeholders::_2,placeholders::_1,3);
int n = 12;
auto f4 = std::bind(fun_2, n,placeholders::_1);
A a;
auto f5 = std::bind(&A::fun_3, a,placeholders::_1,placeholders::_2);

Foo foo;
auto f = std::bind(&Foo::print_sum, &foo, 95, std::placeholders::_1);
f(5); // 100