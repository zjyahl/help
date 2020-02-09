def test():
    def testLocal():
        nonlocal testVar
        localVar = 2
        global newGloablVar
        newGloablVar = 2
    testVar = 1
    testLocal()

ord('中')
ord('\u4e2d')
chr(20013)

print('{0}{1}{0}'.format('abra', 'cad'))
print('Coordinates: {latitude}, {longitude}'.format(latitude='37.24N', longitude='-115.81W'))
print('{0.real} {0.imag}'.format(3-5j))
print('{t.real} {t.imag}'.format(t = 3-5j))
print("repr() shows quotes: {!r}; str() doesn't: {!s}".format('test1', 'test2'))
print('{:+f}; {: f}'.format(3.14, -3.14))
print("int: {0:d};  hex: {0:x};  oct: {0:o};  bin: {0:b}".format(42))
print("int: {0:d};  hex: {0:#x};  oct: {0:#o};  bin: {0:#b}".format(42))
print('{:,}'.format(1234567890))
print('Correct answers: {:.2%}'.format(19/22))
print('{:>30}'.format('left aligned'))
print( '{:*^30}'.format('centered'))
from string import Template
s = Template('$who likes $what')
print(s.substitute(who='tim', what='kung pao'))


import sys
from imp import reload

mod = sys.modules[__name__]

import importlib
from doctor.models import StationSite
model=globals().get('StationSite')
if not model:
    model = importlib.import_module("doctor.models").__dict__.get('StationSite')
model_name ='StationSite'
model_path = 'doctor.models'
params = importlib.import_module(model_path)
model = getattr(params, model_name)

from functools import wraps
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

class decorator(object):
    def __init__(self, *args,**kwargs):
         print(self,args,kwargs)
         self.fun = args[0]

    def __call__(self, *args, **kwargs):
        print(self,args,kwargs)
        print('before............')
        rst = self.fun(*args, **kwargs)
        print('after............')
        return rst

class decorator2(object):
    def __init__(self, *args,**kwargs):
         print(self,args,kwargs)

    def __call__(self, *args, **kwargs):
        print(self,args,kwargs)
        fun = args[0]
        def invoke(*args, **kwargs):
            print('before............')
            rst = fun(*args, **kwargs)
            print('after............')
            return rst
        return invoke

    

# obj.__class__.__dict__ and father (data descriptor)->obj.__dict__  (data descriptor and attr)->obj.__class__.__dict__  non-data descriptor and attr
# obj.__class__.__dict__ and father (data descriptor)->obj.__dict__ any attr   ->obj.__class__.__dict__  non-data descriptor and attr

# obj.__class__.__dict__ and father (data descriptor)->obj.__dict__['attr'] = value


import collections
obj = collections.Counter('aabbccc')
obj.most_common(2)
max([1,-3], key=abs)
import copy

from pathlib import Path
data_folder = Path("source_data/text_files")
file_to_open = data_folder / "raw_data.txt"
