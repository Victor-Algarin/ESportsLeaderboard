echo off

rem batch file to run a script to create a db
rem 05/22/2019

sqlcmd -s localhost -E -i ESportsLeaderBoardDB.sql


ECHO if no error messages appear DB was created
PAUSE