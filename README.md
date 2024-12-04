# Vehicle Performance Tracking Application  

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
[![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)](https://www.javatpoint.com/what-is-vanilla-javascript)
![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)
![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)

This project is a web application developed to track the performance of vehicles in a rental company's fleet. It features role-based access control, efficient data tracking, and visually engaging performance insights, built using a 3-tier architecture with the ASP.NET MVC framework.  

## Table of Contents  
1. [Introduction](#introduction)  
2. [Technologies Used](#technologies-used)  
3. [Software Architecture](#software-architecture)  
4. [Project Development Steps](#project-development-steps)  
5. [Future Enhancements](#future-enhancements)  

---

## 1. Introduction   

This project is a tracking application for vehicle usage performance, designed to manage and analyze active work hours, maintenance hours, and idle times of vehicles. The system integrates role-based access control:  
- **Admin Role**: Can manage vehicle records and view usage performance reports.  
- **User Role**: Can add and edit vehicle usage details.  

## 2. Technologies Used  

- **Backend**:  
   - **3-Tier Architecture**: Data, Business, and Presentation layers for modular development.  
   - **ASP.NET MVC (C#)**: A reliable and scalable framework for web development.  

- **Frontend**:  
   - **HTML5**: For semantic structure and responsive design.  
   - **Bootstrap**: Ensures a polished and responsive user interface.  
   - **Vanilla JavaScript**: Lightweight and efficient for handling client-side logic.  

- **Database**:  
   - **SQL Server**: Securely stores vehicle and user data.  

- **Libraries and Tools**:  
   - **Chart.js**: Visualizes vehicle performance metrics with intuitive charts.  
   - **SignalR**: Implements real-time updates for dynamic interactions.  
   - **JWT Authentication**: Manages secure, token-based access control.  

- **Version Control**:  
   - **Git**: Tracks changes and manages the codebase efficiently.  

---

## 3. Software Architecture  

The application follows a **3-tier architecture**, ensuring scalability and clean separation of concerns. Here's how it is structured:  

### **Data Access Layer**  
- Manages database interactions using **Entity Framework** and **Fluent API**.  
- **DbContext and Entities** define the schema and relationships.  
- Utilizes **Generic Repository Pattern** for reusable data operations.  
- **Unit of Work Pattern** ensures consistent transactions.  

### **Business Logic Layer**  
- Processes data and enforces business rules through **Services and Managers**.  
- Implements secure token generation using **JWT Authentication**.  

### **Presentation Layer**  
- Built using the **Model-View-Controller (MVC)** design pattern.  
- Enhances user experience with **Bootstrap** for a responsive UI.  
- Includes real-time updates powered by **SignalR**.  
- Handles authentication with a **JWT Helper**.  

---

## 4. Project Development Steps  

1. **Requirement Analysis**:  
   - Defined user roles and features (Admin/User).  
   - Planned for integration of **SignalR** and **JWT** for scalability.  

2. **Database Design**:  
   - Designed tables for users, vehicles, and usage tracking.  

3. **Application Setup**:  
   - Initialized an ASP.NET MVC project with layered architecture.  

4. **Feature Development**:  
   - Implemented vehicle CRUD operations and role-based access control.  
   - Developed charts to visualize vehicle usage.  

5. **UI/UX Design**:  
   - Made the interface responsive and user-friendly using Bootstrap.  

---

## 5. Future Enhancements  

There are a few ideas for further improvement:  
- **Exportable Reports**: Adding functionality to export usage data to Excel for better analysis.  
- **Advanced Filters**: Allow users to filter data by date range or specific vehicles.  
- **Analytics**: Introduce advanced analytics for usage trends and predictions.  

---

# :incoming_envelope: Contact Information :incoming_envelope:

For any questions or further information, please don't hesitate to contact me :pray:

Email: merttopcu.dev@gmail.com

LinkedIn: https://www.linkedin.com/in/mert-topcu/

Happy Coding ❤️
