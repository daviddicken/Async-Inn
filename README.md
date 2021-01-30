# Async-Inn
**Author:** David Dicken  
**Collaborators:** Alan Hung, Scott Falbo

### Overview
This progrm was designed to practice Entity Relationships using Entity Framework Core.
It will allow database manipulation via a web connection.
It is a program to help manage a fictional hotel chain the Async Inn.

* **DbContext** - Creates the dbsets, composite keys, and seed data for the databases
* **Entities/Models** - Is the blueprint of properties needed for the object recieved from or put into the database
* **Interfaces** - Are the bluprint of methods needed to manipulate, get, and store entities/ models in the database.
* **Controllers** - Are were the routes methods are deffined. The properties are grabed from the url and fed to the methods to create, get, and manipulate data in the database.

### Entity Relationship Diagram
![ERD](https://github.com/daviddicken/Async-Inn/blob/master/AsyncInn/Img/AsyncInnERD.PNG?raw=true)

