# Async-Inn

----

Lab 12, 13, 14, 15, 16, 17 - Databases & ERDs

*Author: Matthew Johnson, Jin Kim*

----

## Description

This lab demonstrate your uses of hotel scenario to practice setting up for ERD. In this scenario there are six relational tables that comprise our database. 

---
### Visuals

### Screenshots
![Postman](./assets/final-result.png)
Final result of our postman search

![Postman](./assets/Postman.png)
Postman example amenity

#### ERD Diagram
![Application based on this model](./assets/AsyncInn2.png)

![previous model](./assets/ERD-diagram.png)

---

#### Explanation of diagram

1. Async Inn(Hotel)
- The hotel is named `Async Inn` and has many nationwide locations. Each location will have a name, city, state, address, and phone number. It navigates to the hotel room and price join table with payload. Hotel will have one to many relation with both.

2. Hotel Room(Join Table)
- The hotel room join table pulls in combination key from Async Inn and room and has many to one relationsihp with both.

3. Room
- Each room will have a room ids, nick names, amenitites and price per locations. It navigates to the amenities and hotel room tables and has a one to many relationship with both. It has many to one relationship with the enum room type.

4. Price (Join table with payload)
- The rooms vary in price, per location, as well as per room number. It navigates to Async Inn(hotel) and room. Price will have one to many relation with both.

5. Amenities
- Amenities consist of features like “air conditioning”, “coffee maker”, “ocean view”, “mini bar”. It navigates to the room table has a one to many relationship.

6. Room Types (enum)
- Some have one bedroom, others have 2 bedrooms, while a few are more of a cozy studio. It navigates to the room table has a one to many relationship.

### Change Log
- 6.1: *Completed application and updated final README documentation* April 10 2020
- 6.0: *Seed the new information and implementation of hotelDTO is finished* April 9 2020
- 5.3: *The update method for hotel room is updated* April 8, 2020
- 5.2: *Created a DTO for HotelRoom and connected all of the data together.* April 8, 2020
- 5.3: *Created a DTO for Amenities and room is connected* April 8, 2020
- 5.0: *Added Amenities DTO and refactored Get andd Push code to accept.* April 8, 2020
- 4.2: *Connected Amenities to Room and Hotel to Rooms to Amenities. Added the NewtonsoftJSON loop handling.* April 8, 2020
- 4.1: *Created interfaces and services for dependency injection and applied it to our controller* April 7, 2020
- 4.0: *Added dependency injection in to our project using interface and services* April 7, 2020
- 3.3: *Controllers added for all models* April 6, 2020
- 3.2: *Room, Hotel and Amenities dbs seeded with hardcoded data.* April 6, 2020
- 3.1: *Secrets built out and added to Startup. Additional comments added to all the models.* April 6, 2020
- 3.0: *Switched to Matthew Driving* April 6 2020
- 2.1: *Migrated and updated database* April 2 2020
- 2.0: *Created a new classes in the models folder. In DbContext, created a new table for each entity class. We added composite keys association with own overriden `OnModelCreating` method* April 2 2020
- 1.4: *Added migration* - April 2 2020
- 1.3: *Scaffolding database, install all needed dependencies* - April 2 2020
- 1.2: *Lab 12 complete, updated our ERD diagram* - April 2 2020
- 1.1: *Added description of ERD diagram* - April 1 2020
- 1.0: *Created repo and added image to the README documentation* - April 1 2020  