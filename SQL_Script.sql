CREATE TABLE [dbo].[RegisterEmp](
	[UserName] [varchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL primary key,
	[Password] [nvarchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[DOB] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[Physical] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[FileName] [varchar](500) NULL,
	[FileData] [varbinary](max) NULL
) ON [PRIMARY]