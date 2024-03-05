USE ByteJanECommerceDb24;
GO

INSERT INTO Categories (CategoryName,CategoryDescription) VALUES('Sports Shoes','All companies Sports shoes');
INSERT INTO Categories (CategoryName,CategoryDescription) VALUES('Formal Shoes','All companies Formal shoes');
INSERT INTO Categories (CategoryName,CategoryDescription) VALUES('Loafer Shoes','All companies Loafer shoes');


INSERT INTO Products(ProductName,
UnitPrice,
ManufacturingDate,
MadeIn,
ShoeType,
Gender,
Description,
WarrantyPeriod,
ReturnPolicy,
Quantity,
Discount,
Picture,
CategoryId)
VALUES
(
'Bata',
4200,
GETDATE(),
'India',
'Boot',
'Male',
'Geniune Lather',
'1-Year',
'14-Days',
452,
10,
'~/Images/bata_b_m_1.jpg',
1
);



INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Campus',1599,GETDATE(),'India','Boot','Male','Genuine Leather','3 months','7 days',73,5,'~/Images/campus_b_m_1.jpg',2);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Woodland',4599,GETDATE(),'India','Boot','Male','Genuine Leather','1 year','14 days',547,10,'~/Images/woodland_b_m_1.jpeg',3);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Woodland',2399,GETDATE(),'India','Boot','Male','Genuine Leather','6 months','7 days',78,5,'~/Images/woodland_b_m_2.jpg',3);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Puma',1200,GETDATE(),'India','Casual','Male','Running Shoe','6 months','14 days',54,5,'~/Images/puma_c_m_1.jpg',1);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Bata',1199,GETDATE(),'India','Casual','Male','Casual Soft Leather','2 months','7 days',97,5,'~/Images/bata_c_m_1.jpeg',1);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Bata',1899,GETDATE(),'India','Casual','Male','Party Ware Leather','3 months','7 days',78,10,'~/Images/bata_c_m_2.jpeg',1);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Campus',1599,GETDATE(),'India','Casual','Male','Fasion ware','1 months','7 days',567,5,'~/Images/campus_c_m_1.jpeg',1);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Campus',999,GETDATE(),'India','sneakers','Male','Anywhere wear product','0 months','7 days',453,5,'~/Images/campus_l_m_2.jpg',1);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Nike',1599,GETDATE(),'India','sneakers','Male','Anywhere wear product','1 months','7 days',789,5,'~/Images/nike_l_m_1.jpg',1);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Nike',2099,GETDATE(),'India','sneakers','Male','Anywhere wear product','1 months','7 days',665,5,'~/Images/nike_l_m_2.jpg',1);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Nike',1599,GETDATE(),'India','sneakers','Male','Anywhere wear product','3 months','14 days',478,10,'~/Images/nike_l_m_3.jpg',1);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Adidas',4599,GETDATE(),'India','Sports','Male','Football Sports Shoes','6 Months','14 Days',465,5,'~/Images/adidas_soc_m_1.jpeg',2);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Nike',3499,GETDATE(),'India','Sports','Male','Football Sports Shoes','3 Months','7 days',546,5,'~/Images/nike_soc_m_1.jpeg',2);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Puma',3455,GETDATE(),'India','Sports','Male','Football Sports Shoes','1 months','7 days',75,5,'~/Images/puma_soc_m_1.jpeg',1);
INSERT INTO Products(productName,unitPrice,manufacturingDate,madeIn,shoeType,gender,Description,warrantyPeriod,returnPolicy,quantity,discount,picture,CategoryId) VALUES ('Puma',2999,GETDATE(),'India','Sports','Male','Football Sports Shoes','1 months','7 days',75,5,'~/Images/puma_soc_m_2.png',1);

Select * from Categories;
select * from Products;