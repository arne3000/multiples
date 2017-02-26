# API with Rules & Multiples

A dot net core API with Entity Framework Core. 

##Getting Started
* download
* dotnet restore
* update-database
* clean & build

to populate the database do two post requests:
* [/api/rules?multiple=3&output=fizz](http://localhost:5000/api/rules?multiple=3&output=fizz)
* [/api/rules?multiple=5&output=buzz](http://localhost:5000/api/rules?multiple=5&output=buzz)

all the rules are:
* [/api/rules](http://localhost:5000/api/rules)

to make a ranged response: (min: 1, max: 1000)
* [/api/multiples?rangeStart=1&rangeEnd=20](http://localhost:5000/api/multiples?rangeStart=1&rangeEnd=20)
