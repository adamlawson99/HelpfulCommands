
# Helpful Commands

RESTful Api designed to save time looking for common commands for Windows and Linux. I would often forget the name and usage for common command line commands for performing command line functions.

## Getting Started

### Prerequisites
* Windows
* Visual Studio
* Postman or any other tool that allows sending web requests

### Installing
1. Clone the repository
2. Right click the project and install the following
  * Microsoft.AspNetCore.Mvc.NewtonsoftJson
  * Microsoft.EntityFrameworkCore.Proxies
  * Microsoft.EntityFrameworkCore.SqlServer
3. Open NuGet package manager console. Tools > NuGet Package Manager > Package Manager Console
4. Apply the database migrations
```
Add-Migration <Migration Name>
Update-Database
```
5. Run
## Usage Examples
```
https://localhost:44324/api/Platforms/1
https://localhost:44324/api/Platforms
https://localhost:44324/api/Categories
https://localhost:44324/api/Commands
```


## Authors

* **Adam Lawson** - *Lead* - [Portfolio](https://adamlawson.dev/)
