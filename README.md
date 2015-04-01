#OnCast : Technical Assessment | OrderingService

##Design
The basic structure of the project is given in the following way:
<pre>
.
|-- src/
|   |-- exception/
|	|	|-- OrderingException.cs
|   |-- model/
|	|	|-- Book.cs
|	|	|-- Order.cs
|	|-- Configuration.cs
|	|-- IBooksOrder.cs
|	|-- OrderingService.cs
|-- test/
|	|-- ConfigurationTest.cs
|	|-- OrderingServiceTest
|-- order.config
|-- packages.config
</pre>
####Attention
######`src/Configuration.cs` Sets the sort applied by OrderingService
######`src/OrderingService.cs` Ordination books service
######`order.config` Configure the sort set by Configuration
######`packages.config` Configure packages for [NuGet Package Manager](https://www.nuget.org/)


##Getting Started
1. Install [Microsoft Visual Studio 2013](http://nodejs.org/download/) (if you don't have it)
2. Install [.NET Framework 4.5](http://www.microsoft.com/pt-br/download/details.aspx?id=30653) (if you don't have it)
3. Install [NuGet Package Manager](https://www.nuget.org/) (if you don't have it)
4. Install [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/6.0.8)
5. Open Solution `oncast-taos.sln`
6. Run 'All Tests'
