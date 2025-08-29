create  database restaurantPOS;

create table public.tblrole(
       roleid varchar not null primary key,
       roleCode varchar unique,
       roleName varchar
);

create table public.tbluser(
       userid varchar not null primary key,
       userName varchar,
       roleCode varchar references public.tblrole(roleCode) on delete set null,
    password varchar
);

create table public.tblMainCategory(
    mainCategoryID varchar not null primary key ,
    mainCategoryCode varchar,
    mainCategoryName varchar,
    createdAt timestamp,
    createdBy varchar,
    modifiedAt timestamp,
    modifiedBy varchar
);

CREATE TABLE public.tblCategory (
    CategoryID VARCHAR NOT NULL PRIMARY KEY,
    CategoryCode VARCHAR,
    CategoryName VARCHAR,
    mainCategoryCode VARCHAR REFERENCES public.tblMainCategory(mainCategoryCode) ON DELETE SET NULL,
    createdAt TIMESTAMP,
    createdBy VARCHAR REFERENCES public.tbluser(userName) ON DELETE SET NULL,
    modifiedAt TIMESTAMP,
    modifiedBy VARCHAR REFERENCES public.tbluser(userName) ON DELETE SET NULL
);


create table public.tblItem(
    itemId varchar not null  primary key,
    itemCode varchar,
    itemName varchar,
    categoryCode varchar references public.tblCategory(CategoryCode) ON DELETE SET NULL ,
    price decimal(20,2),
    description text,
    outOfStock bool default false,
    createdAt TIMESTAMP,
    createdBy VARCHAR REFERENCES public.tbluser(userName) ON DELETE SET NULL,
    modifiedAt TIMESTAMP,
    modifiedBy VARCHAR REFERENCES public.tbluser(userName) ON DELETE SET NULL,
    deleteflag bool default false
);

create table public.tblServingTable(
    servingTableID VARCHAR NOT NULL PRIMARY KEY ,
    tableNumber INT,
    peopleCount INT,
    status varchar
);

create table public.tblOrder(
  orderID varchar not null primary key ,
  orderCode varchar,
    tableNumber varchar references public.tblServingTable(tableNumber),
     createdAt TIMESTAMP,
    createdBy VARCHAR REFERENCES public.tbluser(userName),
    closedAt TIMESTAMP,
    closedBy VARCHAR REFERENCES public.tbluser(userName)
);

create table public.tblOrderItem(
    orderItemID varchar not null primary key,
    orderID varchar references public.tblOrder(orderID),
    itemCode varchar references public.tblItem(itemCode),
    qty int,
    totalPrice decimal(20,2)
);

create table public.tblPayment(
  paymentID varchar not null primary key ,
  orderID varchar references  public.tblOrder(orderID),
totalAmount decimal(20,2),
    paymentMethod varchar,
    paydate timestamp,
    recivedBy varchar references tbluser(userName)
);

create table public.tblDailyProfit(
  dailyprofitid varchar not null primary key ,
  dailyprofitcode varchar,
    createdby varchar references  public.tbluser(userName),
  date timestamp,
  cashamount decimal(30,2),
  cardamount decimal(30,2),
  totalamount decimal(30,2)
);

select * from tblrole;
select * from tblrole where roleCode='R0001';