# Project Title

Shopping Cart

## Getting Started

Just Clone my repo , you may need to delete the packages folder and restore.
Then please update all the nuget packages.

I have fully imlemented the server side TDD Discount Logic for the cart.
Please Run the tests.

If you run the web project, all you will get at the moment is a login form and you being able to login with your username. 
All implemented in Javascript, with advanced ES6 Modules and IIFE s to avoid global scope. 
The username is then added in the cookies, with the session default expiry.
Once you log in you can check out your cookie in Dev Tools application tab.

I started implementing the client side with javascript just to practice but I havent completed the client side work
I will finish the work for UI.

## Running the tests

Once you download please use VS NUnit test runner to run the unit tests. 

### Break down into end to end tests

```
I have only tested for the cases provided not for any extra edge cases, like no products or multiple threads
creating carts etc.
```

```
We are not looking at available stock in this project, so havent tested on that.
```

## Important Notes on Things I would have done differently in a company project

Ideally the Repo for the shopping carts in this project needs to be a concurrent collection which is what i will implement next, atm we only have one cart.

The repo itself should be Generic, and it is advised async ORM methods are used so we can have an async end-to-end solution from repo to web api or mvc controller. 

So the controller itself would most likely be async in a real project.

The item repo should also be a concurrent collection as stock may be updated by many threads otherwise the collection would have to be locked which wouldnt work after a certain amount of users.

## Versioning


## Authors

* **Amy Papaconstantinou** - *Initial work* - 


