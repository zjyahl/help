# -*- coding: utf-8 -*-
from enum import Enum, unique
from types import FunctionType, MethodType
from functools import wraps
import abc

class Desc(object):
    def __init__(self):
        self.name = 12
    
    def __get__(self, instance, owner):
        return 12
    
    def __set__(self, instance, value):
        self.name = value

    def __delete__(self, instance):
        del self.name

class MyType(type):
    def __new__(cls, name, bases, attrs):
        print('1')
        return super().__new__(cls, name, bases, attrs)

    def __init__(self,*args,**kwargs):
        print('2')
        print(args)
        super().__init__(*args,**kwargs)


   


class A(metaclass=MyType):
    def __init__(self,a,b):
        self.a=a
        self.b = b
     def __call__(cls, *args, **kwargs):
        print('every 3')
        obj = cls.__new__(cls,*args, **kwargs)
        cls.__init__(obj,*args, **kwargs)
        return obj

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


class Class_Common(object):
    __slots__ = ('name', 'age')

    @staticmethod
    def add():
        pass

    @classmethod
    def sub(cls):
        pass
    @abc.abstractmethod
    def midBinHandler(self, fileInfos):
        pass

    def __getattr__(self, attr):
        if attr == 'age':
            return lambda: 25
        raise AttributeError('\'Student\' object has no attribute \'%s\'' % attr)

    def __setattr__(self, key, value):
        print(key,value)
        self.__dict__[key] = value


    def __getattribute__(self,*args,**kwargs): 
        print(args,kwargs)
        return object.__getattribute__(self,*args,**kwargs)

class Class_list(object):

    def __iter__(self):
        return self
    def __next__(self):
        self.a, self.b = self.b, self.a + self.b
        if self.a > 100000:
            raise StopIteration()
        return self.a
    def __getitem__(self, n):
        if isinstance(n, int):
            a, b = 1, 1
            for x in range(n):
                a, b = b, a + b
            return a
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



def log(func):
    @wraps(func)
    def wrapper(*args, **kw):
        print('call %s():' % func.__name__)
        return func(*args, **kw)
    return wrapper

def log2(text):
    def decorator(func):
        @wraps(func)
        def wrapper(*args, **kw):
            print('%s %s():' % (text, func.__name__))
            return func(*args, **kw)
        return wrapper
    return decorator