USE [spencerswupdate]
GO
/****** Object:  StoredProcedure [dbo].[sp_targetserver]    Script Date: 4/5/2021 8:14:11 PM ******/
DROP PROCEDURE [dbo].[sp_targetserver]
GO
ALTER TABLE [dbo].[Target_Server] DROP CONSTRAINT [FK_Target_Server_location]
GO
ALTER TABLE [dbo].[Target_Server] DROP CONSTRAINT [FK_Target_Server_Category]
GO
/****** Object:  Table [dbo].[Target_Server]    Script Date: 4/5/2021 8:14:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Target_Server]') AND type in (N'U'))
DROP TABLE [dbo].[Target_Server]
GO
/****** Object:  Table [dbo].[location]    Script Date: 4/5/2021 8:14:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[location]') AND type in (N'U'))
DROP TABLE [dbo].[location]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/5/2021 8:14:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/5/2021 8:14:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category] [varchar](100) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[location]    Script Date: 4/5/2021 8:14:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location](
	[Store_Code] [varchar](20) NOT NULL,
	[Region] [varchar](100) NULL,
	[Store_Name] [varchar](200) NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[Store_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Target_Server]    Script Date: 4/5/2021 8:14:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Target_Server](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[servername] [varchar](100) NOT NULL,
	[ipaddress] [char](15) NOT NULL,
	[username] [char](20) NULL,
	[password] [varchar](200) NULL,
	[store_code] [varchar](20) NOT NULL,
	[category_id] [int] NOT NULL,
	[is_updated] [bit] NULL,
	[connectivity] [bit] NULL,
	[SSH_status] [bit] NULL,
	[fingerprint_generated] [bit] NULL,
	[last_update_applied] [datetime] NULL,
	[last_updated_version] [decimal](7, 2) NULL,
	[created_by] [varchar](150) NULL,
	[created_on] [datetime] NULL,
	[modified_by] [varchar](150) NULL,
	[modified_on] [datetime] NULL,
 CONSTRAINT [PK_Table_Target_Server_1] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([category_id], [category]) VALUES (1, N'BO Server')
INSERT [dbo].[Category] ([category_id], [category]) VALUES (2, N'POS')
INSERT [dbo].[Category] ([category_id], [category]) VALUES (3, N'CSD/Cash')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'1', N'Sinthi', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'10', N'Kasba', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'11', N'Uttarpara', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'2', N'Shyambazar', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'3', N'South City Mall', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'4', N'Park Circus', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'5', N'Gariahat', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'6', N'Jadavpur', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'7', N'Jodhpur Park', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'8', N'Esplanade', NULL)
INSERT [dbo].[location] ([Store_Code], [Region], [Store_Name]) VALUES (N'9', N'Bullygunj', NULL)
GO
SET IDENTITY_INSERT [dbo].[Target_Server] ON 

INSERT [dbo].[Target_Server] ([rowid], [servername], [ipaddress], [username], [password], [store_code], [category_id], [is_updated], [connectivity], [SSH_status], [fingerprint_generated], [last_update_applied], [last_updated_version], [created_by], [created_on], [modified_by], [modified_on]) VALUES (1, N'WIN-5GD5MCBH2AA', N'103.145.37.78  ', N'Administrator       ', N'e6BmPfe+RdOWYMlxhBAHMmnjNBX4BzW1VR9ZdiYlxCJxsgMDCMs5YNjutqprFqqZqNinATOouiEfW/2T4+xXlyPJeEim50YD7IFcA48jD4qbI1XSOodwDdMNRxHiOX6q', N'2', 3, NULL, NULL, NULL, NULL, NULL, CAST(13.59 AS Decimal(7, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[Target_Server] ([rowid], [servername], [ipaddress], [username], [password], [store_code], [category_id], [is_updated], [connectivity], [SSH_status], [fingerprint_generated], [last_update_applied], [last_updated_version], [created_by], [created_on], [modified_by], [modified_on]) VALUES (2, N'H012BO', N'10.34.22.2     ', N'smartshopuser       ', N'vq/I3qiQvlQgCvSUOCi5Paxy9c6gUv0IGWek0fmiuqCE9tGxOl2kGolDBGQdM4AytcWVKfFv+HWPRpxPAkEaiCjaqDpuHVbhTBwQFBIZhwVJHDQtphpnOrrTZpjm923Q', N'3', 1, NULL, NULL, NULL, NULL, NULL, CAST(10.23 AS Decimal(7, 2)), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Target_Server] OFF
GO
ALTER TABLE [dbo].[Target_Server]  WITH CHECK ADD  CONSTRAINT [FK_Target_Server_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([category_id])
GO
ALTER TABLE [dbo].[Target_Server] CHECK CONSTRAINT [FK_Target_Server_Category]
GO
ALTER TABLE [dbo].[Target_Server]  WITH CHECK ADD  CONSTRAINT [FK_Target_Server_location] FOREIGN KEY([store_code])
REFERENCES [dbo].[location] ([Store_Code])
GO
ALTER TABLE [dbo].[Target_Server] CHECK CONSTRAINT [FK_Target_Server_location]
GO
/****** Object:  StoredProcedure [dbo].[sp_targetserver]    Script Date: 4/5/2021 8:14:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_targetserver]  
(  
    @rowid int = NULL,
	@servername VARCHAR(100) = NULL,  
    @ipaddress CHAR(15) = NULL,
	@username CHAR(20) = NULL,
	@password VARCHAR(200) = NULL,
    @store_code VARCHAR(20) = NULL, 
    @category_id int = NULL,
	@is_updated bit = false,
	@connectivity bit = false,
	@SSH_status bit = false,
	@fingerprint_generated bit = false,
	@last_update_applied datetime = NULL,
	@last_updated_version decimal(7, 2) = NULL,
	@created_by varchar(150) = NULL,
	@created_on datetime = NULL,
	@modified_by varchar(150) = NULL,
	@modified_on datetime = NULL,
	@ActionType VARCHAR(25)
)  
AS  
BEGIN  
    IF @ActionType = 'SaveData'  
    BEGIN  
        IF NOT EXISTS (SELECT * FROM Target_Server WHERE rowid=@rowid)  
        BEGIN 
			INSERT INTO [dbo].[Target_Server]
           ([servername]
           ,[ipaddress]
           ,[username]
           ,[password]
           ,[store_code]
           ,[category_id]
           ,[is_updated]
           ,[connectivity]
           ,[SSH_status]
           ,[fingerprint_generated]
           ,[last_update_applied]
           ,[last_updated_version]
           ,[created_by]
           ,[created_on]
           ,[modified_by]
           ,[modified_on])
     VALUES
           (@servername
           ,@ipaddress
           ,@username
           ,@password
           ,@store_code
           ,@category_id
           ,@is_updated
           ,@connectivity
           ,@SSH_status
           ,@fingerprint_generated
           ,@last_update_applied
           ,@last_updated_version
           ,@created_by
           ,@created_on
           ,@modified_by
           ,@modified_on)
		--GO
        END  
        ELSE  
        BEGIN  
			UPDATE [dbo].[Target_Server]
			   SET [servername] = @servername
				  ,[ipaddress] = @ipaddress
				  ,[username] = @username
				  ,[password] = @password
				  ,[store_code] = @store_code
				  ,[category_id] = @category_id
				  ,[is_updated] = @is_updated
				  ,[connectivity] = @connectivity
				  ,[SSH_status] = @SSH_status
				  ,[fingerprint_generated] = @fingerprint_generated
				  ,[last_update_applied] = @last_update_applied
				  ,[last_updated_version] = @last_updated_version
				  ,[created_by] = @created_by
				  ,[created_on] = @created_on
				  ,[modified_by] = @modified_by
				  ,[modified_on] = @modified_on
			 WHERE rowid=@rowid



        END  
    END  
    IF @ActionType = 'DeleteData'  
    BEGIN  
        DELETE Target_Server WHERE rowid=@rowid  
    END  
    IF @ActionType = 'FetchData'  
    BEGIN  
       SELECT [rowid]
      ,[servername]
      ,[ipaddress]
      ,[username]
      ,[password]
      ,[store_code]
      ,[category_id]
      ,[is_updated]
      ,[connectivity]
      ,[SSH_status]
      ,[fingerprint_generated]
      ,[last_update_applied]
      ,[last_updated_version]
      ,[created_by]
      ,[created_on]
      ,[modified_by]
      ,[modified_on]
  FROM [dbo].[Target_Server]  
    END  
    IF @ActionType = 'FetchRecord'  
    BEGIN  
        SELECT [rowid]
      ,[servername]
      ,[ipaddress]
      ,[username]
      ,[password]
      ,[store_code]
      ,[category_id]
      ,[is_updated]
      ,[connectivity]
      ,[SSH_status]
      ,[fingerprint_generated]
      ,[last_update_applied]
      ,[last_updated_version]
      ,[created_by]
      ,[created_on]
      ,[modified_by]
      ,[modified_on]
	  FROM [dbo].[Target_Server] 
      WHERE rowid=@rowid 
    END  
END  
GO
