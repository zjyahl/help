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
print('%2d-%02d' % (3, 1))
print('%.2f' % 3.1455926)
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



with open('',"rb") as f1:
    with open('',"wb") as f2:
        while True:
            strb = f1.read(1024)
            if strb == b"":
                break
            f2.write(strb)
f = open('workfile', 'rb+')
f.write(b'111')
f.seek(0)
print(f.read(1))
f.write(b'2')

import re
pattern = re.compile(r'\d+')
m = pattern.match('one12twothree34four')
m = pattern.match('one12twothree34four', 2, 10)
matchObj = re.match( r'(?P<logTime>.+) VSP_CP_FTP$','', re.I)
matchObj = re.search( r'(?P<logTime>.+) VSP_CP_FTP$','', re.I)
if matchObj:
    matchObj.group(1)
    matchObj.group('logTime')
    matchObj.start(1)
    matchObj.end(1)
    matchObj.span(1)
dataList = re.findall(r'\bf[a-z]*', 'which foot or hand fell fastest')
it = re.finditer(r"\d+","12a32bc43jf3") 
for match in it: 
    print (match.group() )
re.split(r'\W+', ' runoob, runoob, runoob.')
re.sub(r'(\b[a-z]+) \1', r'\1', 'cat in the the hat')

import time
import datetime
time.strptime(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime()), "%Y-%m-%d %H:%M:%S")
datetime.datetime.strptime(datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f'), '%Y-%m-%d %H:%M:%S.%f')
now1 = datetime.datetime.now()+ datetime.timedelta(days=3)
intervatime = datetime.datetime.now()-now1
intervatime.seconds
now1 > datetime.datetime.now()
time.mktime(time.localtime())
time.localtime(time.mktime(time.localtime()))
datetime.datetime.fromtimestamp(time.mktime(time.localtime()))
structTime = time.localtime()
datetime.datetime(*structTime[:6])



