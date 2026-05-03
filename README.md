\# Client-Server Shopping System



\## Overview

This project is a C# client-server shopping application. It includes a console-based server and a Windows Forms client application. The system allows users to connect with an account number, view available products, purchase items, and view current purchase orders.



The server manages products, accounts, orders, and communication with multiple clients at the same time.



\## Main Features

\- Console-based server application

\- Windows Forms client application

\- Login using account number

\- Product inventory with randomized quantities

\- Purchase function

\- Order history display

\- Multi-client support

\- Custom client-server command protocol

\- Graceful client disconnect

\- Error handling for invalid login, unavailable products, and invalid products



\## Technologies Used

\- C#

\- .NET

\- Windows Forms

\- Client-server communication

\- Socket programming

\- Multithreading / asynchronous programming

\- Object-oriented programming



\## Protocol Commands

\- CONNECT:account\_no

\- GET\_PRODUCTS

\- PURCHASE:product\_name

\- GET\_ORDERS

\- DISCONNECT



\## Skills Demonstrated

\- Network programming

\- GUI development

\- Server-side programming

\- Multi-client communication

\- Protocol design

\- Object-oriented design

\- Error handling

\- Separation of UI and handler logic

