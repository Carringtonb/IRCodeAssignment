# IRCodeAssignment

---

## Web Application

The web application consists of a frontend written in Razor views, HTML, CSS,
Bootstrap, and jQuery. The backend was written in C# using ASP.NET Core, Entity Framework Core, and the MVC framework.

This application is built to recieve an xml file of data regarding Cisco video endpoints. The data will be parsed and passed to a razor view where it is rendered in an easy to read format. Important pieces of data are color coded based on their status, either positive (green) or negative (red).

---

## Tools Used
Microsoft Visual Studio Community 2017 (Version 15.5.7)

- C#
- ASP.Net Core
- Entity Framework
- MVC
- Bootstrap
- Jquery

---

## Recent Updates

#### V 1.0
*Application is ready for initial deployment* - 14 Aug 2020

---

## Getting Started

Clone this repository to your local machine.

```
$ git clone https://github.com/Carringtonb/IRCodeAssignment.git
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the IRGraduateAssignment subdirectory at the root of the repository.
```
cd IRCodeAssignment/IRGraduateAssignment
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application.
```

---

## Usage

### Home page with links to LinkedIn and Github
![Home page](https://user-images.githubusercontent.com/58369033/90221492-82bee380-ddc7-11ea-9dd3-7079f0b9ed55.png)

### Upper half of the data tables showing timer at almost full time
![Upper half of data](https://user-images.githubusercontent.com/58369033/90221378-586d2600-ddc7-11ea-911f-499ef9c3db9c.png)

### Lower half of the data tables
![Lower half of data](https://user-images.githubusercontent.com/58369033/90221256-1d6af280-ddc7-11ea-9f8f-0553b29c8c40.png)

### Data rendered with countdown decrementing
![Data page with countdown working](https://user-images.githubusercontent.com/58369033/90221067-ae8d9980-ddc6-11ea-991c-2382a6074e1e.png)

---

## Model Properties and Requirements

### SystemUnit

| Parameter | Type | Required |
| --- | --- | --- |
| Product ID  | string | YES |
| Product Platform | string | YES |
| Product Type | string | YES |
| Software Name | string | YES |
| Software Release | string | YES |
| Software Version | string | Yes |
| State | string | Yes |
| Last Run | string | Yes |
| Descrption of Diagnostics | string | YES |
| Diagnostics Level  | string | YES |
| Diagnostics Reference | string | YES |
| Diagnostics Type | string | YES |
| Answer State | string | YES |
| Call Type | string | YES |
| Callback Number | string | Yes |
| Device Type | string | Yes |
| Direction | string | Yes |
| Display Name | string | YES |
| Duration  | string | YES |
| Network Address | string | YES |
| Network Device ID | string | YES |
| Network Platform | string | YES |
| MAC Address | string | YES |
| Ipv4 Address | string | Yes |
| IPv6 Address | string | Yes |
| System Time | string | Yes |
| Contact Name | string | YES |
| Contact Number | string | YES |
| Peripheral Hardware | string | YES |
| Peripheral ID | string | YES |
| Peripheral Name | string | YES |
| Peripheral Software | string | YES |
| Peripheral Status | string | Yes |
| Peripheral Type | string | Yes |

---

## Change Log
1.4: *Added Styling* - 14 Aug 2020  
1.3: *Rendered all data to web browser* - 13 Aug 2020  
1.2: *Built a DTO to send the data to Razor Page* - 12 Aug 2020  
1.1: *Parsed XML data to be stored in an object* - 12 Aug 2020  

---

## Authors
Carrington Beard
