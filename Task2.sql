create table Product(
  id int primary key,
  name varchar(50)
  );
  
 create table Category(
  id int primary key,
  name varchar(50)
  );
  
 create table ProductCategory(
  product_id int REFERENCES Product(id),
  category_id int REFERENCES Category(id),
  PRIMARY Key(product_id, category_id)
  );
  
INSERT INTO Category
VALUES
  (1, 'Category_Name_1'),
  (2, 'Category_Name_2'),
  (3, 'Category_Name_3');
  
INSERT INTO Product
VALUES
  (1, 'Product_Name_1'),
  (2, 'Product_Name_2'),
  (3, 'Product_Name_3');
  
  
INSERT INTO ProductCategory
VALUES 
  (1, 1),
  (2, 3),
  (2, 2);
 
 
select P.name as 'product_name', C.name as 'category_name' from Product as P 
left join ProductCategory as PC on P.id = PC.product_id
left join Category as C on PC.category_id = C.id
 