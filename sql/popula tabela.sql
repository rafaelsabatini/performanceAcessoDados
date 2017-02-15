declare @count int = 80000,
@count_iten int = 3,
@usuario uniqueidentifier =  NEWID()



while(@count > 0)
begin
declare @id uniqueidentifier = NEWID();
insert into Pedido(id,UsuarioId,Numero,DataCadastro) values (@id,@usuario,SUBSTRING(CONVERT(varchar(255),NEWID()),1,8), GETDATE())
while(@count_iten > 0)
begin
insert into  Item(Id,Pedido_Id,ProdutoId,Quantidade,Valor) values (NEWID(),@id,NEWID(),2,10.45)
set @count_iten = @count_iten -1;
end


--select Pedido.id as id ,UsuarioId,Numero,DataCadastro, Item.Id as Item_Id,Pedido_Id as Item_Pedido_Id, ProdutoId as Item_ProdutoId,Quantidade as Item_Quantidade,Valor as Item_Valor  from Pedido inner join item on Item.Pedido_Id = Pedido.Id

--select p. from Pedido as  p inner join item as i on i.Pedido_Id = p.Id

--select Pedido.* as p, item.* as i from Pedido inner join item on Item.Pedido_Id = Pedido.Id
set @count_iten = 3;
set @count = @count -1;
end






