# Async-Inn

----

Lab 12 - Databases & ERDs

*Author: Matthew Johnson, Jin Kim*

----

## Description

This lab demonstrate your uses of hotel scenario to practice setting up for ERD. In this scenario there are six relational tables that comprise our database. 

---
### Visuals

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
- 1.1: *Added description of ERD diagram* - April 1 2020
- 1.0: *Created repo and added image to the README documentation* - April 1 2020  