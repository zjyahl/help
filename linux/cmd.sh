#!/bin/bash
#chkconfig:2345 80 05 --指定在哪几个级别执行，0一般指关机，
6指的是重启，其他为正常启动。80为启动的优先级，05为关闭的优先机
#description:mystart service
RETVAL=0
start(){ --启动服务的入口函数
echo -n "mystart serive ..."
cd /home/zjy
su test1 -c "python /home/test1/test.py"

}

stop(){ --关闭服务的入口函数
echo "mystart service is stoped..."
}

case $1 in --使用case，可以进行交互式操作
start)
start
;;
stop)
stop
;;
esac
exit $RETVAL

cd /home/test1
su test1 -c "python /home/test1/test.py"
su - user -c "nohup /home/user/run.sh > /home/user/out.txt 2>&1 &"

ps aux | fgrep a.out
chmod +x test.sh

cp test.sh /etc/init.d/
chkconfig --add test.sh
chkconfig test.sh on

shutdown -r now



tar -xvf mysql-8.0.11-linux-glibc2.12-x86_64.tar.gz -C /usr/local/
cp -r mysql-5.6.33-linux-glibc2.5-x86_64 /usr/local/mysql
groupadd mysql
sudo useradd -s /sbin/nologin -M -g mysql mysql
chown -R mysql:mysql mysql-files
chmod 750 mysql-files
ps -aux | grep mysqld
netstat -tl | grep mysql
firewall-cmd --zone=public --add-port=80/tcp --permanent
firewall-cmd --reload
firewall-cmd --list-ports
rm -rf dir

sudo ./mysqld --initialize --user=mysql --basedir=/usr/local/mysql --datadir=/usr/local/mysql/data
sudo ./mysqld_safe --user=mysql
./mysql --user=root -p
alter user 'root'@'localhost' identified by '123456';
CREATE USER 'root'@'%' IDENTIFIED BY 'Hadoop3!';
grant all privileges on *.* to 'root'@'%';
alter user 'root'@'%' identified with mysql_native_password by '123456';
firewall-cmd --state 
firewall-cmd --zone=public --add-port=3306/tcp --permanent
firewall-cmd --reload