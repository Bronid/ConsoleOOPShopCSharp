# ConsoleOOPShopCSharp
My final project for OOP exam

## Table of Contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Database structure](#Database-structure)
* [Setup](#setup)

## General-info

### Goal: 
Design and implement an object-oriented shop management system. The basic assumptions are given below:
1. System should contain core objects:
* Product (describes the single product in the shop)
* Category (contains products from a specific category, such as drinks, cosmetics, toys, etc.),
* Catalogue (stores shop catalogue by category)
* Order (describes a single user's order)
* Application (the main object that provides interaction with the user)

2. Inheritance: design descendant objects from the Product object type that are product types, e.g. GroceryProduct, BrandedProduct, ElectroProduct, etc. You can also design Invoice and Receipt descendant objects from the BaseReceipt object.

3. Enable basic operations on Products, Categories, Catalogue, Orders and Receipts. Basic operations include:
* Adding object/collection of objects
* Deleting object/collection of objects
* Displaying object/collection of objects
* Searching/Filtering object/collection of objects

4. Additional functions of the program (for a score above 4.0)
* Design and implement interfaces. Base the entire system on the interfaces principle
* Perform write and read to file(s) (data persistence)
* Use "Dependency Injection" mechanisms, e.g. Singleton, Factory, Decorator (e.g. decorators for implementing operators “and”/”or” when searching)

### My solution
I create application which contains:
1. Objects:
   * [Product](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Class/DataClass/Product.cs) (describes the single product in the shop)
   * [Category](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Class/DataClass/Category.cs)(contains list of products)
   * [Assortment](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Class/DataClass/Assortment.cs)(contains list of categories)
   * [Order](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Class/DataClass/Order.cs)(describes a single user's order)
   * [User](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Class/DataClass/User.cs)(contains list of orders)
   * [Application](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Class/Application.cs)(static class)
   * [Database](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Class/Database.cs)(class with database functionality)
   * [ExceptionHelper](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Class/ExceptionHelper.cs) (controls user incorrect input)

2. Functionality:
   * Adding object/collection of objects
   * Deleting object/collection of objects
   * Displaying object/collection of objects
   * Filtering and sorting object/collection of objects
   * Buying products and money balance system
   * Users register/authorization

3. Additional functions:
   * Interfaces:
     1. [ISpacious](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Class/Interface/ISpacious.cs) - interface for object which contains list of another objects
     2. [IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-7.0) - interface which lets count objects (example: in foreach loop)
        [this](https://github.com/Bronid/ConsoleOOPShopCSharp/tree/master/Class/Enumaratos) enumerators classes for product and category
     3. [IComparable](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable?view=net-7.0) - interface which lets sort object
   * Implemented write and read to file via [sqlite](https://www.sqlite.org/)
   Files are saving in database file:
   Path: project folder -> bin -> Debug -> database.db
   Read from database implemented by [syncData](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/5cce7636d989e7c0109a13c70da36958e2c9a14d/Class/Database.cs#L71) function which synchronize data
   after any interaction with the database, it is mean that application can be run on more than 1 computer and data always will be synchronized.
   * Singleton

## Technologies
* [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [sqlite](https://www.sqlite.org/)
* To work with .db files [DB Browser SQLite](https://sqlitebrowser.org/)

## Database-structure
![image](https://user-images.githubusercontent.com/61603558/216708439-2452c6d7-c24d-4562-9483-81177188bf2d.png)

## Setup

1. Clone this repository
```
git clone https://github.com/Bronid/ConsoleOOPShopCSharp.git
```
2. Run [Program.cs](https://github.com/Bronid/ConsoleOOPShopCSharp/blob/master/Program.cs)file via your IDE
3. Done =)
