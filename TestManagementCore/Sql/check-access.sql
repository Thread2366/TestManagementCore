select count(*)
from dbo.AccessRules
where PermissionId = :permId
and RoleId = :roleId