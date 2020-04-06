# Blog
A simple Blog web application demonstrating capabilities of ASP.NET Core 3.1 and Angular

# Prerequisite
- ASP.NET Core 3.1
- Node.js
- Angular CLI 8
- TypeScript 3.7

# Applications
- Visual Studio 2019 (Install ASP.NET and Database options) for Backend
- Visual Studio Code for Frontend
- Microsoft SQL Server 2017 for Storage

# Setup
Setup ClientApp in Visual Studio Code ClientApp:
1. Add bash in integrated terminal to run node.js commands
   Update %User%\AppData\Roaming\Code\User\settings.json
   Add "terminal.integrated.shell.windows": "C:\\Program Files\\Git\\bin\\bash.exe"
2. Open ClientApp folder in Visual Studio Code, open Terminal->New Terminal
   Bottom pane should show the Terminal, click '+' and select 'bash'
3. Get latest Angular CLI by typing 'npm install -g @angular/cli@latest'
4. Test run ClientApp UI by executing 'ng serve --open'
   After successful build, a new browser window with URL 'https://localhost:44368/' will show

Setup Database Migration in Visual Studio 2019:
1. Install Nuget Packages for Database Access
   (Tools->Nuget Package Manager->Manager Nuget Packages for Solution)
   Find the following under Browse Tab then Install each:
    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.SqlServer
2. Remove the contents of the folder Migrations.
3. Open the Package Manager Console this time
    (Tools->Nuget Package Manager->Package Manager Console)
4. Run the following commands:
    Add-Migration Initial
    Update-Database
5. Check if tables is created
   (View->SQL Server Object Explorer->(localdb)\MSSQLLocalDB\Databases\)
   BlogPostContext-{GUID}\Tables\dbo.BlogPosts
6. Build and run the application

# Acknowledgement
Thank you very much to @dileno (https://github.com/dileno) for this great tutorial
https://dev.to/dileno/build-a-simple-crud-app-with-angular-8-and-asp-net-core-2-2-part-1-back-end-39e1
