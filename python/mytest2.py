import time
import os
import csv
import datetime
import shutil
import sys
import glob
from pathlib import Path
import re
import random
import statistics
from urllib import request, parse
import smtplib
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
from email.header import Header
import zipfile
import gzip
import tarfile
sys.path.append('')
Path('').glob('')
print(sys.argv)
sys.exit() 
sys.stdout = None

def re_op():
    matchObj = re.match(
                                r'^(?P<logTime>.+) VSP_CP_FTP (WARNING|ERROR|exception|INFO) => (?P<logTxt>[\s\S]+)',
                                '', re.I)
    re.findall(r'\bf[a-z]*', 'which foot or hand fell fastest')
    re.sub(r'(\b[a-z]+) \1', r'\1', 'cat in the the hat')

def random_op():
    random.choice(['apple', 'pear', 'banana'])
    random.sample(range(100), 10)
    random.random()
    random.randrange(6)

def statistics_op():
    data = [2.75, 1.75, 1.25, 0.25, 0.5, 1.25, 3.5]
    statistics.mean(data)
    statistics.median(data)
    statistics.variance(data)

def time_fun():
    timedesc = int(os.path.getctime('filePath'))
    time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(timedesc))

    timedesc = os.path.getmtime('filePath')
    timedesc = os.path.getatime('filePath')
    
    time.strftime("%Y%m%d%H%M%S", time.localtime())
    time.mktime(time.localtime())

    datetime.datetime.now().isocalendar()
    time.strftime("%W")
    print(datetime.date(2018, 10, 15).isocalendar())

    mic = int(time.mktime(time.strptime('20191212121212', '%Y%m%d%H%M%S')))
    mic += 60 * 60 * 24

def get_time_stamp():
    ct = time.time()
    local_time = time.localtime(ct)
    data_head = time.strftime("%Y-%m-%d %H:%M:%S", local_time)
    data_secs = (ct - int(ct)) * 1000
    time_stamp = "%s.%03d" % (data_head, data_secs)
    return time_stamp

def readCsv():
    with open('G:\\tmp\\some.csv', 'r') as f:
        reader = csv.DictReader(f)
        for row in reader:
            print(row['first_name'], row['last_name'])

def writeCsv():
    with open('G:\\tmp\\some.csv', 'w',newline ='') as f:

        # writer = csv.writer(f)
        # writer.writerow(['first_name','last_name'])
        # writer.writerows({'first_name': 'Baked', 'last_name': 'Beans'})

        fieldnames = ['first_name', 'last_name']
        writer = csv.DictWriter(f, fieldnames=fieldnames)
        writer.writeheader()
        writer.writerow({'first_name': 'Lovely', 'last_name': 'Spam'})

def dirOp():
    os.makedirs('')
    shutil.rmtree('')
    shutil.copy2("","")
    shutil.move("","")
    os.path.dirname('')
    os.path.basename('')
    os.path.split('')
    os.path.abspath(__file__)
    os.path.isabs('')
    os.getcwd()

def http_post(self, postUrl, postData):
    #[('LOT_ID', 'IFX1847002M000'),('oper', '3162')]
    try:
        encodeData = parse.urlencode(postData)
        inx = postUrl.find('//') + 2
        inx = inx + postUrl[inx:].find('/')
        serUrl = postUrl[0:inx]
        referUrl = postUrl[0: postUrl.rfind('?')]
    
        req = request.Request(postUrl)
        req.add_header('Origin', serUrl)
        req.add_header('User-Agent',
                       'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:64.0) Gecko/20100101 Firefox/64.0')
        req.add_header('Referer', referUrl)
        with request.urlopen(req, data=encodeData.encode('utf-8')) as f:
            if f.status == 200:
                rst = f.read().decode('utf-8')
                print(rst)
                if 'flag=0' in rst:
                    return True
            else:
                print(str.format("status:{0} reason:{1}",f.status,f.reason))
    except BaseException as e:
        pass

def sendMail(subject, msg, revs, fileInfos):
    mail_host = ''
    mail_user = ''
    mail_pass = ''
    sender = ''
    receivers = revs
    message = MIMEMultipart()

    message['Subject'] = Header(subject, 'utf-8')
    message['To'] = ','.join(receivers)
    message.attach(MIMEText(msg, 'plain', 'utf-8'))

    for fileInfo in fileInfos:
        att1 = MIMEText(open(fileInfo['path'], 'rb').read(), 'base64', 'utf-8')
        att1["Content-Type"] = 'application/octet-stream'
        att1["Content-Disposition"] = 'attachment; filename="' + fileInfo['name'] + '"'
        message.attach(att1)

    smtpObj = smtplib.SMTP()
    smtpObj.connect(mail_host, 25)
    smtpObj.login(mail_user, mail_pass)
    smtpObj.sendmail(sender, receivers, message.as_string())

def zipFile(fileName, files):
    zipPath = fileName+'.zip'
    if not os.path.exists(zipPath):
        zipPathTmp =  zipPath+'.tmp'
        if os.path.exists(zipPathTmp):
            os.remove(zipPathTmp)
        with zipfile.ZipFile(zipPathTmp, 'w') as myzip:
            for file in files:
                myzip.write(file, os.path.basename(file),compress_type=zipfile.ZIP_DEFLATED)
        os.rename(zipPathTmp,  zipPath)
    for file in files:
        if os.path.exists(file):
            os.remove(file)
    return zipPath

def tar_gz(self,file1, file2, key, rstDir):
    fname = rstDir + key
    t = tarfile.open(fname + ".tar.gz", "w:gz")
    t.add(file1, os.path.basename(file1))
    t.add(file2, os.path.basename(file2))
    t.close()
def gz():
    with open('filePath', 'rb') as f_in:
        with gzip.open('newFilePath', 'wb') as f_out:
            shutil.copyfileobj(f_in, f_out)