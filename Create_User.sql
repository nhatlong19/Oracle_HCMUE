--show con_name;

alter session set "_ORACLE_SCRIPT"=true;

CREATE USER SpaceTeam IDENTIFIED BY 123456;

GRANT CONNECT, DBA TO SpaceTeam 

GRANT CREATE SESSION, GRANT ANY PRIVILEGE TO SpaceTeam 

GRANT UNLIMITED TABLESPACE TO SpaceTeam 

--GRANT CREATE TABLE TO SpaceTeam 

--AMERICAN_AMERICA.WE8MSWIN1252

alter session set container=pdbdb12c;
alter session set "_ORACLE_SCRIPT"=true;

CREATE USER nvc IDENTIFIED BY 123456 DEFAULT COLLATION BINARY_AI;

GRANT CONNECT, DBA TO nvc;

GRANT CREATE SESSION, GRANT ANY PRIVILEGE TO nvc;

GRANT UNLIMITED TABLESPACE TO nvc;