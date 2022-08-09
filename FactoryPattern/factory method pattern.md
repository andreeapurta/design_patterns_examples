# Factory Method Pattern

Using OOP means that at some point in our applications we need to instantiate some objects. The question is where do we instantiate them? 

**Factory Method** is a creational design pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.

**Factory method** is a **creational design pattern** which solves the problem of creating product objects without specifying their concrete classes.

![img](https://www.dofactory.com/img/diagrams/net/factory.png)

## Pro vs cons

![image](https://user-images.githubusercontent.com/67948869/183693208-1e150257-d5f4-4657-8359-177c2919236b.png)


## How to implement

1. Make all products follow the same interface / abstract class. This interface should declare methods / properties that make sense in every product.
2. Make the creator class. Add an empty factory method inside the creator class. The return type of the method should match the common product interface.
3. Now, create a set of creator subclasses for each type of product listed in the factory method. Override the factory method in the subclasses and extract the appropriate bits of construction code from the base method.
4. Let the user choose at runtime what product he needs. Use the concrete factory to create a product you need.

## Example

### Problem

As a smartphone user, I want to be able to get a new phone. Based on my choice, I want to be able to order it from the company's store and have it delivered to my house. 

### Solution

![image](https://user-images.githubusercontent.com/67948869/183692773-cbe82c6b-0a4c-4bfd-9d98-4b8e42050962.png)
