
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