create or alter  procedure TableGetAllUser
as
begin
create table BookTicket
(
TicketId bigint not null identity(1,1),
Busname  nvarchar(200) not null,
Startingpoint  nvarchar(200) not null,
Droppingpoint  nvarchar(200) not null,
Amount  bigint not null,
NoOfpeople bigint not null,
JourneyDate  datetime2 not null,
ContactNo bigint  not null)
end


--INSERT

create or alter procedure InsertBookTicket_sp

@Busname  nvarchar(200) ,
@Startingpoint  nvarchar(200) ,
@Droppingpoint  nvarchar(200) ,
@Amount  bigint ,
@NoOfpeople bigint ,
@JourneyDate  datetime2 ,
@ContactNo bigint  
as
begin
insert into BookTicket (Busname,Startingpoint,Droppingpoint,Amount,NoOfpeople,JourneyDate,ContactNo)
values (@Busname,@Startingpoint,@Droppingpoint,@Amount,@NoOfpeople,@JourneyDate,@ContactNo)
end

exec InsertBookTicket_sp 'Jbl','pl','cbe',100,2,'2/09/2024',987787878

--select


create or alter  procedure ListBookTicket_sp
as
begin

select TicketId,Busname,Startingpoint,Droppingpoint,Amount,NoOfpeople,JourneyDate,ContactNo from BookTicket

end

exec ListBookTicket_sp

--Select by name

create or alter procedure SelectByName(@Busname nvarchar(200))
as
begin

select TicketId,Busname,Startingpoint,Droppingpoint,Amount,NoOfpeople,JourneyDate,ContactNo
from BookTicket
where
Busname=@Busname
end
exec SelectByName 'jbs'

--update

create or alter procedure UpdateBookTicket_sp
(
@TicketID int ,
@Busname  nvarchar(200) ,
@Startingpoint  nvarchar(200) ,
@Droppingpoint  nvarchar(200) ,
@Amount  bigint ,
@NoOfpeople bigint ,
@JourneyDate  datetime ,
@ContactNo bigint)  
as
begin
update BookTicket set Busname= @Busname,Startingpoint= @Startingpoint,Droppingpoint= @Droppingpoint,Amount= @Amount,NoOfpeople= @NoOfpeople,JourneyDate= @JourneyDate,ContactNo= @ContactNo 
where TicketId =@TicketID
end

exec UpdateBookTicket_sp 1, 'Jbs','po','palakad',120,3,'2/8/2024',9878787878

--Delete

create or alter procedure DeleteBookTicket_sp(@TicketId bigint)
as
begin
delete from BookTicket
where
TicketId=@TicketId
end
exec DeleteBookTicket_sp 1
