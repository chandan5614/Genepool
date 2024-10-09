# Genepool

## Table of Contents
- [Object-Oriented Programming Concepts](#object-oriented-programming-concepts)
  - [Encapsulation](#encapsulation)
  - [Abstraction](#abstraction)
  - [Inheritance](#inheritance)
  - [Polymorphism](#polymorphism)
  - [Coupling](#coupling)
  - [Composition](#composition)
  - [Summary of Usage](#summary-of-usage)
- [SOLID Principles](#solid-principles)
  - [Single Responsibility Principle (SRP)](#single-responsibility-principle-srp)
  - [Open/Closed Principle (OCP)](#openclosed-principle-ocp)
  - [Liskov Substitution Principle (LSP)](#liskov-substitution-principle-lsp)
  - [Interface Segregation Principle (ISP)](#interface-segregation-principle-isp)
  - [Dependency Inversion Principle (DIP)](#dependency-inversion-principle-dip)

## Object-Oriented Programming Concepts

### Encapsulation
Encapsulation bundles data and methods into a single unit (class), hiding internal details while exposing necessary functionalities.

#### Key Points:
- Separates public interface from internal implementation.
- Simplifies object interactions and protects internal state.

#### When to Use:
- To hide an object's internal state and expose specific functionalities.
- To ensure data integrity by controlling access to attributes.

### Abstraction
Abstraction reduces complexity by hiding unnecessary details, allowing users to interact with systems at a high level.

#### Key Points:
- Simplifies interactions (e.g., using a remote).
- Changes to internal implementations do not affect external users.

#### When to Use:
- To provide a simplified interface to a complex system.
- To hide implementation details from users.

### Inheritance
Inheritance allows creating new classes based on existing ones, promoting code reuse through an "is-a" relationship.

#### Key Points:
- Reduces redundancy and promotes code reuse.
- Changes in a base class propagate to derived classes.

#### When to Use:
- When there's a clear "is-a" relationship.
- To reuse properties and behaviors from existing classes.

### Polymorphism
Polymorphism allows treating different types as instances of a common super type, enabling flexibility and extensibility.

#### Key Points:
- Supports dynamic method resolution.
- Facilitates code extension without modifying existing logic.

#### When to Use:
- To treat different objects uniformly through a common interface.
- To allow varied implementations while sharing a common interface.

### Coupling
Coupling indicates the degree of dependency between classes. Low coupling enhances flexibility, while high coupling can lead to fragility.

#### Key Points:
- High coupling complicates modifications and maintenance.
- Low coupling enhances maintainability and flexibility.

#### When to Use:
- Strive for low coupling to improve maintainability.
- Use dependency injection to reduce coupling and enhance flexibility.

### Composition
Composition involves building complex types by combining simpler objects, emphasizing a "has-a" relationship.

#### Key Points:
- Promotes code reuse by assembling smaller, reusable components.
- Reduces the risk of tight coupling associated with inheritance.

#### When to Use:
- When you need flexibility in constructing objects from smaller components.
- When there is no clear "is-a" relationship, and a "has-a" relationship is more appropriate.
- To avoid limitations of inheritance, such as tight coupling and the fragile base class problem.

### Summary of Usage

| Principle       | When to Use                                                           |
|------------------|-----------------------------------------------------------------------|
| Encapsulation     | To hide internal state and ensure data integrity.                     |
| Abstraction       | To provide a simplified interface to complex systems.                 |
| Inheritance       | To promote code reuse with a clear "is-a" relationship.              |
| Polymorphism      | To treat different objects uniformly and allow method flexibility.    |
| Coupling          | To reduce dependencies between classes for easier maintenance.        |
| Composition       | To create complex objects with reusable components, especially when there is no clear "is-a" relationship. |

## SOLID Principles

### Single Responsibility Principle (SRP)
- **Define Clear Responsibilities:** Ensure each class has one reason to change, focusing on a single task.
- **Separation of Concerns:** Divide functionality into distinct classes to make code easier to understand and maintain.
- **Refactor as Needed:** Regularly review and refactor classes that take on multiple responsibilities.

### Open/Closed Principle (OCP)
- **Design for Extension:** Create classes that can be extended without altering existing code.
- **Use Abstract Classes and Interfaces:** Allow for adding new functionalities through subclasses or implementing interfaces.
- **Favor Composition:** Consider composition for new features instead of modifying existing implementations.

### Liskov Substitution Principle (LSP)
- **Ensure Substitutability:** Verify that derived classes can replace base classes without altering expected behavior.
- **Maintain Contracts:** Ensure derived classes adhere to the contracts defined by base classes (e.g., method signatures, expected behaviors).
- **Avoid Side Effects:** Derived classes should not introduce side effects that would break the behavior of existing code.

### Interface Segregation Principle (ISP)
- **Create Focused Interfaces:** Design interfaces that are specific to the client’s needs, avoiding unnecessary methods.
- **Limit Client Exposure:** Ensure clients depend only on the methods they need, promoting clean design.
- **Refactor Large Interfaces:** Split large interfaces into smaller, more manageable ones as requirements change.

### Dependency Inversion Principle (DIP)
- **Depend on Abstractions:** Ensure high-level modules rely on interfaces or abstract classes rather than concrete implementations.
- **Use Dependency Injection:** Inject dependencies into classes rather than creating them internally to promote flexibility.
- **Maintain Loose Coupling:** Regularly assess dependencies to ensure the system remains flexible and easy to test.
