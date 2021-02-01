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
  * `/api/hotelRooms` - returns hotelRooms found in the hotelRooms table.
* Routes:  
  **Hotels:**
  * `Get` `/api/hotels/{hotelId}` - returns data about one hotel.
  * `Put` `/api/hotels/{hotelId}` - with a body allows you to update one hotel.
  * `Post` `/api/hotels` - with a body allows you to create a new hotel.
  * `Delete` `/api/hotels/{hotelId}` - deletes one hotel.  
  
  **Rooms:**
  * `Get` `/api/rooms/{roomId}` - returns data about one room.
  * `Put` `/api/rooms/{roomId}` - with a body allows you to update one room.
  * `Post` `/api/rooms` - with a body allows you to create a new room.
  * `Delete` `/api/rooms/{roomId}` - deletes one room.    
  
  **Amenities:**
  * `Get` `/api/ammenities/{amenityId}` - returns data about one amenity.
  * `Put` `/api/amenities/{amenityId}` - with a body allows you to update one amenity.
  * `Post` `/api/amenities` - with a body allows you to create a new amenity.
  * `Delete` `/api/amenities/{amenitiyId}` - deletes one aminity.   
  
  **HotelRooms:**
  * `Get` `/api/hotelRooms/{hotelId}/{roomNumber}` - returns data about one hotelRoom.
  * `Put` `/api/hotelRooms/{hotelId}/{roomNumber}` - with a body allows you to update one hotelRoom.
  * `Post` `/api/hotelRooms` - with a body allows you to create a new hotelRoom.
  * `Delete` `/api/hotelRooms/{hotelId}/{roomNumber}` - deletes one hotelRoom.

### Architecture
* **DbContext** - Creates the dbsets, composite keys, and seed data for the databases.  
* **Entities/Models** - Is the blueprint of properties needed for the object recieved from or put into the database.  
* **Interfaces** - Are the bluprint of methods needed to manipulate, get, and store entities/ models in the database.  
* **Controllers** - Are were the routes methods are deffined. The properties are grabed from the url and fed to the methods to create, get, and manipulate data in the database.  

### Entity Relationship Diagram
![ERD](https://github.com/daviddicken/Async-Inn/blob/master/AsyncInn/Img/AsyncInnERD.PNG?raw=true)

### Relationships
* `Hotel` has a 1 to Many relationship with `HotelRoom`
* `Room` has a one to many relationship with `HotelRoom`
* `Room` has a one to many relationship with `RoomAmenities`
* `Amenities` has a one to many relationship with `RoomAmenities`

### Tables
* Hotel - This table holds the data for each hotel in the AsynInn chain. Each one has a unique primary key. The properties that can be found in the hotel table are: the hotels name, city, state, country, phone number, and street address.

* Room - This table holds data about a room including it's name and layout(studio, One Bedroom, or Two Bedrooms). Each room has a unique primary key.

* Aminities - The amenities table hold data on amenities that can be found in any of the hotel rooms. Each amenity has a unique primary key and a name.

* HotelRoom - HotelRoom is a joint table that joins a room from the room table to a hotel. The HotelRoom table will need to have a Hotel Id from a hotel in the Hotel table and a Room Id from a room in the Room table. It also has properties for a room number, rate, and a Boolean if pets are allowed. A composite key is made with the hotel id and room number.

* RoomAmenities - This is a pure joint table that is used to link what amenities are found in a room. It only stores a Room Id and a Amenity Id and makes a composite key out of the two to link them.

