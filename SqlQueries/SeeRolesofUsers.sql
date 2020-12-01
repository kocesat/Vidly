SELECT Result.Email, AspNetRoles.Name
FROM 
	(SELECT AspNetUsers.Email, AspNetUserRoles.RoleId
	FROM AspNetUsers
	INNER JOIN AspNetUserRoles ON AspNetUsers.Id=AspNetUserRoles.UserId) Result
INNER JOIN AspNetRoles ON AspNetRoles.Id = Result.RoleId;