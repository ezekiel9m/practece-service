
INSERT INTO Customer(CustomerId, Name, LastName, DocumentNumber, Email, PhoneNumebr, IsActive, CreateDate, Gender)
VALUES ('28923465-2b51-4466-a48e-b02f2b58bcd1', 'Ezekiel', 'Willan', '685.920.250-52',
'kilson@hotmail.com', '11951909300', 1, 27/02/2021, 'M');


INSERT INTO Product (Code, Name, Description, Price, CreateDate, IsActive)
VALUES ('3ZVJJTLD3V', 'iPhone 11', 'SmartPhone producto de tecnlogia', 4.600, 2021/02/27, 1);


INSERT INTO SaleStatus(Name, Code)
VALUES 
('Vendido', 'sold'),
('Cancelado','canceled'),
('Pago', 'paid'),
('Bloqueado','blocked'),
('Não Pago','unpaid')


INSERT INTO Sale(Code, CustomerId, SaleStatusId, ProductId, BillingDate, Amount, TotalAmount, CustomerName, CreateDate)
VALUES ('RC3ATZOP3J', 'eb0c090f-a1cf-49a1-9936-8e0224b0dc3b', 1, 1, 2021/02/27, 4600, 4600, 'Ezekiel Qillan', 2021/02/27)