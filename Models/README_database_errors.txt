dotnet ef migrations add InitialCreate --namespace Models
dotnet ef database update



EnsureCreated is used to make sure the database exists.

//For testing, the DB is read from the Test/bin/... location <- not always true. could be other bins. or could be specified.


If you need to make a foreign key, will need to seed the child entity first, then use "ForeignTableId" = # as the entry in the parent table


NOTE ON JOINS: MUST DO THE FOLLOWING:
	- Use the Joins.cs in the API project
	- Create an explicit join table
	- Use Fluent API to set up the join fields
	- For a repeated field for A in B, you need to ignore the field in fluent API on create of B, otherwise A may have a field for B 

