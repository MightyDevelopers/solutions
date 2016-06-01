set mysql="C:\Program Files\MySQL\MySQL Server 5.6\bin\mysql.exe"
set hostname=localhost
set port=3306
set user=root
set password=localhost

%mysql% -h %hostname% --port=%port% -u%user% -p%password% < %~dp0\0.1\Schema\000_Database_Solutions.sql
for %%G in (%~dp0\0.1\Schema\Create\*.sql) do %mysql% -h %hostname% --port=%port% -u%user% -p%password% --database=solutions< "%%G"
for %%G in (%~dp0\0.1\Programmability\Create\Users\*.sql) do %mysql% -h %hostname% --port=%port% -u%user% -p%password% --database=solutions < "%%G"
for %%G in (%~dp0\0.1\Programmability\Create\Groups\*.sql) do %mysql% -h %hostname% --port=%port% -u%user% -p%password% --database=solutions < "%%G"
pause