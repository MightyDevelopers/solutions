@echo off

set mysql="C:\Program Files\MySQL\MySQL Server 5.6\bin\mysql.exe"
set hostname=db4free.net
set port=3306
set user=chaleng
set password=Q!W@E#r4t5y6

for %%G in (%~dp0\0.1\Schema\Create\*.sql) do %mysql% -h %hostname% --port=%port% -u%user% -p%password% --database=solutions< "%%G"
for %%G in (%~dp0\0.1\Programmability\Create\Users\*.sql) do %mysql% -h %hostname% --port=%port% -u%user% -p%password% --database=solutions < "%%G"
for %%G in (%~dp0\0.1\Programmability\Create\Groups\*.sql) do %mysql% -h %hostname% --port=%port% -u%user% -p%password% --database=solutions < "%%G"
pause

echo on