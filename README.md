# Async-Inn
**Author:** David Dicken  
**Collaborators:** Alan Hung, Scott Falbo

### Overview
This progrm was designed to practice Entity Relationships using Entity Framework Core.
It will allow database manipulation via a web connection.
It is a program to help manage a fictional hotel chain the Async Inn.

### Getting Started
* `git clone https://github.com/daviddicken/Async-Inn.git`
* Run App from Visual Studio or another compiler.
* LocalHost will open in browser.
* Endpoints:
  * `/api/hotels` - returns hotels found in hotels table.
  * `/api/rooms` - returns rooms found in rooms table.
  * `/api/amenities` - returns amenities found in amenities table.
* Routes:
  * `Get` `/api/hotels/{hotelId}` - returns data about one hotel.
  * `Put` `/api/hotels/{hotelId}` - with a body allows you to update one hotel.
  * `Post` `/api/hotels` - with a body allows you to create a new hotel.
  
  * `Get` `/api/rooms/{roomId}` - returns data about one room.
  * `Put` `/api/rooms/{roomId}` - with a body allows you to update one room.
  * `Post` `/api/rooms` - with a body allows you to create a new room.
  
  * `Get` `/api/ammenities/{amenityId}` - returns data about one amenity.
  * `Put` `/api/amenities/{amenityId}` - with a body allows you to update one amenity.
  * `Post` `/api/amenities` - with a body allows you to create a new amenity.

### Architecture
* **DbContext** - Creates the dbsets, composite keys, and seed data for the databases.  
* **Entities/Models** - Is the blueprint of properties needed for the object recieved from or put into the database.  
* **Interfaces** - Are the bluprint of methods needed to manipulate, get, and store entities/ models in the database.  
* **Controllers** - Are were the routes methods are deffined. The properties are grabed from the url and fed to the methods to create, get, and manipulate data in the database.  

### Entity Relationship Diagram
![ERD](https://github.com/daviddicken/Async-Inn/blob/master/AsyncInn/Img/AsyncInnERD.PNG?raw=true)

