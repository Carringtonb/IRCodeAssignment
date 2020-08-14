# IRCodeAssignment

---

## Azure Deployment

[IR Graduate Assignment](https://irgraduateassignment.azurewebsites.net/)

## Web Application

The web application consists of a frontend written in Razor views, HTML, CSS,
Bootstrap, and jQuery. The backend was written in C# using ASP.NET Core, Entity Framework Core, and the MVC framework.

This application is built to recieve an xml file of data regarding Cisco video endpoints. The data will be parsed and passed to a razor view where it is rendered in an easy to read format. Important pieces of data are color coded based on their status, either positive (green) or negative (red).

I have chosen to build this application using C# because it is my most famliliar language. I also believe that with object-oriented programming it is much easier to seperate each piece of the project and tackle one thing at a time. OOP also is modular which helps in trouble shooting. Using RazorPages is also a very convenient way to present a view, since logic is able to be implemented in the cshtml file as well as the code behind file.

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


---
## Design Diagram

![IRGraduationDesign.pdf](https://i.imgur.com/jPyrXFV.png)


## Usage

### Home page with links to LinkedIn and Github
![Home page](https://i.imgur.com/lymt5jJ.png)

### Upper half of the data tables showing timer at almost full time
![Upper half of data](https://i.imgur.com/NwZclvU.png)

### Lower half of the data tables
![Lower half of data](https://i.imgur.com/kvIpIrK.png)

### Data rendered with countdown decrementing
![Data page with countdown working](https://i.imgur.com/GBN9Dzn.png)

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
