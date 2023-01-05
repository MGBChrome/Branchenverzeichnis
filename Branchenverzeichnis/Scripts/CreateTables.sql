use master;
go

If(db_id(N'IndustryDirectory') IS NOT NULL)
begin
	drop database IndustryDirectory;
end
go

create database IndustryDirectory;
go

use IndustryDirectory;

create table Company
(
	CompanyID	int				not null	identity(1,1),
	[Name]		varchar(50)		not null,
	Phonenumber	varchar(50)		null,
	Street		varchar(50)		null,
	PLZ			varchar(20)		not null,
	[Location]	varchar(50)		not null,
	CeoFirstName	varchar(50)	null,
	CeoLastName		varchar(50)	null,
	IndustryID	int				null,
	constraint PK_Company primary key (CompanyID)
)

create table Product
(
	ProductID	int			not null	identity(1,1),
	[Name]		varchar(50)	not null,
	constraint PK_Product primary key (ProductID)
)

create table CompanyProduct
(
	CompanyProductID int	not null	identity(1,1),
	CompanyID	int			not null,
	ProductID	int			not null,
	constraint	PK_CompanyProduct primary key (CompanyProductID)
)

create table Industry
(
	IndustryID	int			not null	identity(1,1),
	[Name]		varchar(50)	not null
	constraint PK_Industry primary key (IndustryID)
)

alter table Company
	add constraint FK_Company_Industry foreign key (IndustryID) references Industry(IndustryID);

alter table CompanyProduct
	add constraint FK_CompanyProduct_Company foreign key (CompanyID) references Company(CompanyID);

alter table CompanyProduct
	add constraint FK_CompanyProduct_Product foreign key (ProductID) references Product(ProductID);