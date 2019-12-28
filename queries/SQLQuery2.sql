select o.Id, o.Sum,o.PhoneNumber,o.Address,o.Date,i.Id,i.Title,i.ImagePath,i.Price,i.Company from Orders o
inner join OrderItems oi on o.Id = oi.Order_Id
inner join Items i on oi.Item_Id = i.Id
where o.Id = 1002;

select i.Id,i.Title,i.ImagePath,i.Price,i.Company from Items i 
inner join OrderItems oi on i.Id = oi.Item_Id
inner join Orders o on oi.Order_Id = o.Id
where o.Id = 1002;

