# Lamazon 🦙

## Requirements 📌

A company is contracting you to make an Amazon like application. The application will be for finding and ordering premium products. When the user makes an order, the company checks their stocks and if everything is okay it approves the order. Then an external transport and shipping company takes the item and delivers it to the customer. The customer can pay on delivery with cash or online, and should get an invoice for the order. The company will need an interface to approve orders made. The clients will need a login system to login and finalize their order.

> The online payment system will be done by another banking team

## Key Logic 📌

- Customer - A customer that can make orders
- Supplier - The application owner that can approve orders
- Product - Premium item that can be ordered
- Order - An order that contains products for a user
- Invoice - Description of the order(Address) and the payment system as well as proof that an order happened

## Details 📌

- The application should have an interface where the users can login, see products and buy them as well as make the order
- The Customer and Supplier need to login with username and password
- The Supplier needs to see all orders and approve them
- The products are listed in one page
- Customers orders are also listed in a page with details for that customer
- Invoices are listed as links under every approved order
- There should be an error view so that when the application breaks, the user sees a nice error message
- There should be a navigational bar that navigates the users through the page
- There should be an approve order page where the user sees the order details and decides if they want to make the order
- Statuses of the orders are
  - Processing - When the order is waiting for approval of the supplier
  - Confirmed - When the supplier approved the order but it is not yet delivered
  - Delivered - When the order is delivered
- Product categories are
  - Food
  - Drink
  - Electronics
  - Books
  - Other
- The application logo will be provided from the design team. It's a Llama.
