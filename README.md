# GarmentShop
The garment management system designed by using Clean Architecture, Domain Driven Design, ASP.NET Core 7, T-SQL, EF Core 7, domain events, Fluent validation, Fluent API, logging, JWT Bearer, generic repository, CQRS, unit of work, outbox message patterns, mediatR, mapper, Polly, Quartz, custom role and permission attribute system.
There are aggregates:
1) User Aggregate:
This aggregate would represent the users of the system, such as employees or customers, and would have properties such as username, password, email, and roles.
Each user has a set of roles such as administrator, etc. Each role has a set of permissions, such as the ability to manage garment items, manage sales, etc.
2) Authentication Aggregate:
This aggregate would handle authentication for the system, including verifying user credentials and generating authentication tokens.
Permission entity represents the specific actions a user can perform within the system, such as adding a garment item, deleting a garment item, etc.
3) Brand Aggregate:
This aggregate represents the basic information about a brand in the system.
4) Garment Type aggregate:
This aggregate which has relationships with the Garment and GarmentCategory aggregates, as well as properties to represent the basic information about a garment type.
5) Garment Category aggregate: 
This aggregate is responsible for managing the information about the different garment categories in the system, and the relationships between garment categories and garment types.
6) Garment Aggregate:
This aggregate, which are represented by the Brand and GarmentType properties. These relationships allow to associate a garment with a specific brand and garment type in the system.
7) Sale aggregate:
This aggregate that is responsible for managing all sales transactions in the system. This aggregate could have entities such as:
a) Order entity contains information about the items a customer wants to purchase, such as the quantity and size of each item. 
b) Payment entity contains information about how the customer intends to pay for the order, such as credit card details or cash.
c) Invoice entity contains information about the total cost of the order, the tax, shipping and handling fees, and any other charges that may apply. It also has a relationship with the Payment entity to ensure that the payment is processed correctly.

Aggregates look like:
1) User:

![image](https://user-images.githubusercontent.com/97736243/221298872-3bc92633-7493-4470-aa50-424602dea4dc.png)

2) Authentication:

![image](https://user-images.githubusercontent.com/97736243/221299079-03e9809b-2ad0-4d2d-8d05-b63a23d7e76a.png)

3) Brand:

![image](https://user-images.githubusercontent.com/97736243/221299115-bf5054a8-e894-4d60-a3f1-9bf0818d1485.png)

4) Garment Type:

![image](https://user-images.githubusercontent.com/97736243/221299146-65c7e009-ca99-4671-a595-998df361567f.png)

5) Garment Category:

![image](https://user-images.githubusercontent.com/97736243/221299232-bd7f2c75-2942-44ac-b88e-e46b28646bc7.png)

6) Garment:

![image](https://user-images.githubusercontent.com/97736243/221299272-f069f882-f0db-4a83-8a69-1fedabad3fab.png)

7) Sale:

![image](https://user-images.githubusercontent.com/97736243/221299311-823249d4-5268-440b-b3e0-85367df69099.png)
