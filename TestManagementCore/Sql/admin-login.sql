select t.Id
from dbo.Administrators as t
where t.Login = :login
and t.PasswordHash = :password