# 🅿️ Parking Lot System – Low Level Design (C#)

## 📌 Overview
This project implements a **Parking Lot System** using **Low-Level Design (LLD)** principles in **C#**.  
The focus is on **clean architecture**, **design patterns**, and **extensibility**, making it ideal for **LLD interview rounds**.

The system is implemented as a **console-based simulation** to demonstrate business flow and technical design clearly.

---

## 🎯 Key Features
- Multiple parking floors
- Multiple vehicle types (Bike, Car, Truck)
- Slot assignment based on strategy
- Ticket generation at entry
- Hourly pricing calculation at exit
- Thread-safe central parking lot

---

## 🧠 Business Logic (High-Level Flow)

### 🚗 Vehicle Entry
1. Vehicle arrives at the parking lot
2. Nearest available slot for the vehicle type is selected
3. Slot is marked as **Occupied**
4. A **Ticket** is generated with entry time

### 🚙 Vehicle Exit
1. Vehicle presents the ticket
2. Parking duration is calculated
3. Hourly pricing is applied
4. Slot is freed
5. Total amount is returned

---

## 🧩 Core Domain Models

### Vehicle
- Abstract representation of a vehicle
- Types supported:
  - Bike
  - Car
  - Truck
- Created using **Factory Pattern**

### ParkingSlot
- Represents an individual slot
- Contains:
  - Slot type (Bike / Car / Truck)
  - Slot status (Available / Occupied)
- Does **not** contain allocation logic

### ParkingFloor
- Represents a parking floor
- Contains a collection of parking slots

### Ticket
- Generated when a vehicle is parked
- Contains:
  - Vehicle
  - Assigned slot
  - Entry timestamp

### ParkingLot
- Central coordinator for parking and unparking
- Manages floors, slot assignment, and pricing
- Implemented as a **thread-safe Singleton**

---

## 🏛️ Design Patterns Used

### 1️⃣ Factory Pattern
**Used For:** Vehicle creation  
**Why:**  
- Decouples object creation from usage  
- Makes adding new vehicle types easy  

**Classes:**  
- `VehicleFactory`

---

### 2️⃣ Strategy Pattern (Slot Assignment)
**Used For:** Selecting parking slots  
**Why:**  
- Slot allocation logic may change (nearest, VIP, cheapest, etc.)
- Keeps slot entities simple  

**Interfaces / Classes:**  
- `ISlotAssignmentStrategy`
- `NearestSlotStrategy`

---

### 3️⃣ Strategy Pattern (Pricing)
**Used For:** Pricing calculation  
**Why:**  
- Pricing rules can vary independently of parking logic  

**Interfaces / Classes:**  
- `IPricingStrategy`
- `HourlyPricingStrategy`

---

### 4️⃣ Singleton Pattern (Thread-Safe)
**Used For:** ParkingLot  
**Why:**  
- Parking lot is a shared resource
- Only one instance should exist  

**How:**  
- Implemented using `Lazy<T>` to ensure thread safety

---

### 5️⃣ Facade Pattern
**Used For:** ParkingLot public API  
**Why:**  
- Simplifies interaction for clients
- Hides internal complexity of parking/unparking

---

## 🧱 SOLID Principles Applied

### Single Responsibility Principle (SRP)
- Slot → manages state only
- Strategy → handles business logic
- ParkingLot → coordinates workflow

### Open/Closed Principle (OCP)
- New vehicle types → add new classes
- New pricing or allocation rules → add new strategies

### Dependency Inversion Principle (DIP)
- High-level modules depend on abstractions (interfaces)

---

## 🔐 Thread Safety
- `ParkingLot` is accessed by multiple threads
- Uses `Lazy<T>` for safe, lazy initialization
- Prevents race conditions during instance creation

---

## 🖥️ Console Demonstration
- Floors and slots are initialized in `Main`
- Vehicles are parked and unparked
- Pricing is calculated based on parking duration

This keeps the project focused on **LLD**, not UI or database concerns.

---

## 🚀 Extensibility
This design can easily support:
- EV charging slots
- VIP or reserved parking
- Vehicle-based pricing
- Multiple entry and exit gates
- Dependency Injection instead of Singleton

---

## 🧠 Interview Explanation (Quick Summary)

> “I modeled the core entities first, kept responsibilities separated, and used Strategy for slot allocation and pricing, Factory for vehicle creation, and a thread-safe Singleton with Lazy<T> for the parking lot.  
The system follows SOLID principles and is easy to extend.”

---

## ✅ Interview Readiness
✔ Suitable for **SDE-1 / SDE-2 LLD rounds**  
✔ Clean, extensible, and easy to explain  
✔ Focused on design patterns and object modeling  

---

## 📄 File Name
