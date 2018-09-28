# URL Shortener
ASP.NET Core URL Shortener with MySQL database.

# Configuration

Set connection to MySQL database at appsettings.json:  
Server=localhost;Database=dbName;User=user;Password=password;  

Set MySQL version at Startup.cs in ConfigureServices method:  
For MySQL v10.1.26 - Version(10, 1, 26)  

Entity Framework:  
dotnet ef dbcontext info  
dotnet ef migrations add NAME_OF_MIGRATION  
dotnet ef database update  

Server configuration (apache2):  
https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-2.1&tabs=aspnetcore2x

Launch:  
systemctl enable SERVICENAME.service  
systemctl start SERVICENAME.service  
