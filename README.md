# GarmentShop
This is the skeleton of the future garment management system designed by using Clean Architecture, Domain Driven Design, ASP.NET Core 7, T-SQL, EF Core 7, domain events, Fluent validation, Fluent API, logging, JWT Bearer, generic repository, CQRS, unit of work, outbox message patterns, mediatR, mapper, polly, quartz, custom role and permission attribute system.

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

Use-case diagram:

![image](https://github.com/strd1337/GarmentShop/assets/97736243/96329db3-6eae-497d-a855-9cbea7473eb6)

Activity diagram (Ordering):

![image](https://github.com/strd1337/GarmentShop/assets/97736243/07177c2e-5a06-4787-b0ea-7bf296e7bcbf)

State diagram (authentication):

![image](https://github.com/strd1337/GarmentShop/assets/97736243/8f5c7b3e-d26f-436b-a8e3-f776acbe5704)

Sequence diagram (Selecting product):

![image](https://github.com/strd1337/GarmentShop/assets/97736243/f118a66e-9456-405f-8ee6-087dd2657999)

Class diagram:

![image](https://github.com/strd1337/GarmentShop/assets/97736243/9c94d142-a63c-4f2c-9850-ced3e5772681)

Deployment diagram:

![image](https://github.com/strd1337/GarmentShop/assets/97736243/c85c3c4e-cff0-406a-b1fe-6d0152bc723b)
