# The Goal
Spend a few hours to develop a simple system in which a user can post a question, other users can post answers to said questions.

***Approach***

I will approach this with haste in order to provide as full a solution as possible cutting as few corners as possible. The approach I am going to use is:

1. Build a simple ERD
2. Using a clean architecture approach, build out a simple .net REST service
3. Build a simple Angular front end to consume the api and provide a browser only view of the site

***Considerations***

Due to time constraints, the level of TDD will be limited, but somewhat shown.

We are skipping authentication of any sort. 

We are considering golden path only, and ungracefully handling exceptions.

***ERD***

![erd](./erd/erd.png)

***.net Service***

Harnessing the clean architecture approach, we will be using: 

- Mediatr
- AutoMapper
- Entity Framework

***Angular Frontend***

This will be browser only, mobile will not be in consideration.