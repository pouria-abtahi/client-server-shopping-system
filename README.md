# Client-Server Shopping System

A small shopping system in two parts:

- **Server:** a console app that holds the products, accounts and orders.
- **Client:** a Windows Forms app that logs in and shops.

They talk over TCP using a plain-text protocol I defined for the project. Several clients can be connected at the same time.

Final project for **PRG650 Advanced Programming Concepts** at Seneca Polytechnic, Fall 2024. Individual project.

## How it works

The server listens on port 5000 and handles each connected client on its own task. When it starts, it creates five products with a random stock of 1 to 3 each, and a few test accounts. It prints every command it receives and every reply it sends, so you can follow the conversation in the console.

The client connects to a hostname (default `localhost`) with an account number. Then it shows the product list, lets you buy items, and shows your orders.

## Protocol

One command per line, one reply per line.

| Client sends | Server replies |
|---|---|
| `CONNECT:<account_no>` | `CONNECTED:<user name>` or `CONNECT_ERROR` |
| `GET_PRODUCTS` | product names and stock |
| `PURCHASE:<product>` | success, `NOT_AVAILABLE` (out of stock), `NOT_VALID` (unknown product) or `USER_NOT_CONNECTED` |
| `GET_ORDERS` | the orders placed so far |
| `DISCONNECT` | closes the session |
| anything else | `INVALID_COMMAND` |

## Run it

1. Open `ShoppingManager.sln` in Visual Studio 2022.
2. Start **ShoppingServer** first. It targets .NET Framework 4.7.2.
3. Start one or more **ShoppingClient** windows. They target .NET 8 for Windows.
4. Log in with account 1001, 1002, 1003 or 1004.

## What I'd improve

- **Thread safety.** Each client runs on its own task, but the shared product and order lists aren't locked. Two clients buying the last item at the same moment could both succeed. A `lock` around purchases, or concurrent collections, would fix it.
- **Persistence.** Orders live only in memory, as the assignment allowed, so they're lost when the server stops.

## Tech

C# · .NET Framework 4.7.2 (server) · .NET 8 Windows Forms (client) · TcpListener / TcpClient · async/await · Task-based concurrency
