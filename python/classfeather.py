from types import MethodType
class TestClass:
    pass
a = TestClass()
a.setData = MethodType(lambda self, value:self.data = value, a)

class Class_Common(object):
     __slots__ = ('name', 'age')

    def __new__(cls,*args,**kwargs):
        return  super().__new__(cls)

    @property
    def birth(self):
        return self._birth

    @birth.setter
    def birth(self, value):
        self._birth = value

    @birth.deleter
    def birth(self, value):
        self._birth = value

    @staticmethod
    def add():
        pass

    @classmethod
    def sub(cls):
        pass
    @abc.abstractmethod
    def midBinHandler(self, fileInfos):
        pass

    def __str__(self):
        return str(self.__data)
    __repr__ = __str__

    def __getattr__(self, attr):
        if attr == 'age':
            return lambda: 25
        raise AttributeError('\'Student\' object has no attribute \'%s\'' % attr)

    def __setattr__(self, key, value):
        print(key,value)
        self.__dict__[key] = value
        #object.__setattr__(self,key,value)


    def __getattribute__(self,*args,**kwargs): 
        print(args,kwargs)
        return object.__getattribute__(self,*args,**kwargs)
        
class Class_list(object):

    def __init__(self):
        super().__init__()
        self.data = []
        self.index = -1
    
    def __iter__(self):
        return self

    def __next__(self):
        if self.index >= len(self.data):
            self.index = 0
            raise StopIteration()
        self.index += 1
        return self.data[self.index - 1]
        
    def __getitem__(self, n):
        if isinstance(n, int):
            if n >0 and n < len(self.data):
                return self.data[n]
            raise StopIteration()
        if isinstance(n, slice):
            start = n.start
            stop = n.stop
            if start is None:
                start = 0
            if stop is None:
                stop = 10
            a, b = 1, 1
            L = []
            for x in range(stop):
                if x >= start:
                    L.append(a)
                a, b = b, a + b
            return L

class Class_Collection_Data(object):
    def __init__(self,data):
        self.__data = data

    @property
    def data(self):
        return self.__data

    @data.setter
    def data(self, value):
        self.__data = value

    def __gt__(self, other):
        return self.__data > other.data

    def __lt__(self, other):
        return self.__data < other.data

    def __eq__(self, obj):
        return self.__data == obj.data

    def __hash__(self):
        return  hash(self.__data)


class UserInt(int):
    def __init__(self, val=0):
        self._val = int(val)
        super().__init__(val)
    def __add__(self, val):
        if isinstance(val, UserInt):
            return UserInt(self._val + val._val)
        return self._val + val
    def __radd__(self, val):
        if isinstance(val, UserInt):
            return UserInt(self._val + val._val)
        return self._val + val
    def __iadd__(self, val):
        raise NotImplementedError("not support operation")
    def __str__(self):
        return str(self._val)
    def __repr__(self):
        return "Integer %s" % self._val
        
from enum import Enum, unique
@unique
class Weekday(Enum):
    Sun = 0
    Mon = 1
    Tue = 2
    Wed = 3
    Thu = 4
    Fri = 5
    Sat = 6
Month = Enum('Month', ('Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'))
for name, member in Month.__members__.items():
    print(name, '=>', member, ',', member.value)            

class Desc(object):
    def __init__(self):
        self.name = 12
    
    def __get__(self, calObj, calType):
        print(calObj, calType)
        return self.name
    
    def __set__(self, calObj, value):
        print(calObj,'FF')
        self.name = value

    def __delete__(self, calObj):
        del self.name
        
def fn(self, name='world'):
    pass
Hello = type('Hello', (object,), dict(hello=fn))

class MyType(type):
    def __new__(cls, name, bases, attrs):
        print('1')
        return super().__new__(cls, name, bases, attrs)

    def __init__(self,*args,**kwargs):
        print('2')
        super().__init__(*args,**kwargs)
        
    def __call__(cls, *args, **kwargs):
        print('every 3')
        obj = cls.__new__(cls,*args, **kwargs)
        cls.__init__(obj,*args, **kwargs)
        return obj