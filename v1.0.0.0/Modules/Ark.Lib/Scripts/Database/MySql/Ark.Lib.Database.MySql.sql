drop user if exists 'ark'@'localhost';
drop database if exists Ark;
create database Ark;
create user 'ark'@'localhost' identified by 'ark';
grant all privileges on Ark.* to 'ark'@'localhost';
flush privileges;
use Ark;
