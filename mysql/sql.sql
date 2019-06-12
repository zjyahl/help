SELECT GROUP_CONCAT(COLUMN_NAME SEPARATOR ",") FROM information_schema.COLUMNS 
WHERE TABLE_SCHEMA = 'ifx_b2b' AND TABLE_NAME = 'trx_his'


show variables like '%explicit_defaults_for_timestamp%'; 

SET FOREIGN_KEY_CHECKS=0;
SET FOREIGN_KEY_CHECKS=1;

show databases;
create database if not exists test;
drop database if exists test;
use test;


CREATE TABLE `jc_account_draw` (
  `account_draw_id` int(11) NOT NULL AUTO_INCREMENT,
  `channel_id` int(11) NOT NULL DEFAULT '0' COMMENT '提现申请者',
   `channel_id` int(11) zerofill,
  `apply_account` varchar(100) DEFAULT '',
  `apply_amount` double NOT NULL DEFAULT '0',
  `min_draw_amount` double(11,2) NOT NULL DEFAULT,
  `apply_status` tinyint(1) NOT NULL DEFAULT '0',
  `account_pay_id` bigint(20) DEFAULT NULL,
  `ups` smallint(6) NOT NULL DEFAULT '0'.
  `plan_list` longtext,
  `code` text,
  `content` longblob,
  `is_enabled` char(1) NOT NULL DEFAULT '1'
  `apply_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `login_time` timestamp NOT NULL  ON UPDATE CURRENT_TIMESTAMP,
  `start_time` datetime DEFAULT NULL,
   `count_clear_time` date NOT NULL,
  PRIMARY KEY (`account_draw_id`),
   KEY `fk_jc_acquisition_channel` (`channel_id`),
   UNIQUE KEY `ak_field` (`field`),
   CONSTRAINT fk_jc_acquisition_replace FOREIGN KEY (acquisition_id) REFERENCES jc_acquisition (acquisition_id)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8 COMMENT='用户账户提现申请';

create trigger triggerContentInsert after insert on jc_content for each row     update jc_site_attr set attr_value=attr_value+1 where attr_name="contentTotal" and site_id=new.site_id;
create trigger triggerContentDelete after delete on jc_content for each row    update jc_site_attr set attr_value=attr_value-1 where attr_name="contentTotal" and site_id=old.site_id;

ALTER TABLE testalter_tbl  DROP i;
ALTER TABLE testalter_tbl ADD i INT AFTER c;
ALTER TABLE jc_account_draw ADD COLUMN smsid  bigint(20) NULL COMMENT '配置了的短信运营商';
ALTER TABLE jc_config CHANGE COLUMN email_validate validate_type  integer(2) NULL DEFAULT 0 COMMENT '验证类型：0:无  1：邮件验证  2：SMS验证';
ALTER TABLE `jc_acquisition`
ADD CONSTRAINT `fk_jc_acquisition_channel` FOREIGN KEY (`channel_id`) REFERENCES `jc_channel` (`channel_id`),
ADD CONSTRAINT `fk_jc_acquisition_user` FOREIGN KEY (`user_id`) REFERENCES `jc_user` (`user_id`);


alter table t_user drop foreign key FKC112;
drop table if exists t_group;
alter table t_user add index key111 (user_id),
ADD CONSTRAINT `fk_jc_acquisition_channel` FOREIGN KEY (`channel_id`) REFERENCES `jc_channel` (`channel_id`);

INSERT INTO table (a,b,c) VALUES (1,2,3),(4,5,6) ON DUPLICATE KEY UPDATE c=VALUES(a)+VALUES(b); 
REPLACE INTO test(title,uid) VALUES ('1234657','1003');
SELECT
    FROM_UNIXTIME(unixdatefield), datefield
FROM
    a
WHERE
    FROM_UNIXTIME(unixdatefield) > '2016-01-01' and m.datefield > '2016-01-01 00:00:00.0'
LIMIT 5;

select IFNULL(sum(score),0) as sumcore from table

SELECT * FROM table_name WHERE ... LOCK IN SHARE MODE
SELECT * FROM table_name WHERE ... FOR UPDATE

SHOW VARIABLES LIKE 'slow%'
SHOW VARIABLES LIKE 'long%'
SELECT SLEEP(3)

SELECT * FROM tb_user u
INNER JOIN (SELECT id FROM tb_user LIMIT 1000,10) AS b ON b.id=u.id
SELECT * FROM tb_user WHERE id > 1000 LIMIT 10

SELECT * FROM tb_user USE INDEX (user_name)
SELECT * FROM tb_user IGNORE INDEX (user_name) WHERE user_name="qq"
SELECT * FROM tb_user FORCE INDEX (user_name) WHERE user_name="qq"
