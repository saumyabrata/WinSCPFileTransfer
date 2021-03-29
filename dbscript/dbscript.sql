USE [spencerswupdate]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 30/03/2021 12:02:20 AM ******/
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
/****** Object:  Table [dbo].[location]    Script Date: 30/03/2021 12:02:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location](
	[location_id] [int] IDENTITY(1,1) NOT NULL,
	[location] [varchar](100) NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Target_Server]    Script Date: 30/03/2021 12:02:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Target_Server](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[servername] [varchar](100) NOT NULL,
	[ipaddress] [char](15) NOT NULL,
	[location_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[schedule_update] [bit] NULL,
	[schedule_datetime] [datetime] NULL,
	[is_updated] [bit] NULL,
	[is_reachable] [bit] NULL,
	[last_update_applied] [datetime] NULL,
	[last_update_version] [decimal](7, 2) NULL,
 CONSTRAINT [PK_Table_Target_Server_1] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Target_Server]    Script Date: 30/03/2021 12:02:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Target_Server] ON [dbo].[Target_Server]
(
	[servername] ASC,
	[ipaddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_targetserver]    Script Date: 30/03/2021 12:02:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_targetserver]  
(  
    @rowid int = NULL,
	@servername VARCHAR(100) = NULL,  
    @ipaddress CHAR(15) = NULL,  
    @location_id int = NULL,  
    @category_id int = NULL,  
    @lastupdatedversion decimal(7,2) = NULL,
	@ActionType VARCHAR(25)
)  
AS  
BEGIN  
    IF @ActionType = 'SaveData'  
    BEGIN  
        IF NOT EXISTS (SELECT * FROM Target_Server WHERE rowid=@rowid)  
        BEGIN  
            INSERT INTO Target_Server (servername,ipaddress,location_id,category_id,last_update_version)  
            VALUES (@servername,@ipaddress,@location_id,@category_id,@lastupdatedversion)  
        END  
        ELSE  
        BEGIN  
            UPDATE Target_Server SET servername=@servername,ipaddress=@ipaddress,location_id=@location_id,  
            category_id=@category_id,last_update_version=@lastupdatedversion WHERE rowid=@rowid  
        END  
    END  
    IF @ActionType = 'DeleteData'  
    BEGIN  
        DELETE Target_Server WHERE rowid=@rowid  
    END  
    IF @ActionType = 'FetchData'  
    BEGIN  
        SELECT rowid,servername,ipaddress,location_id,category_id,last_update_version FROM Target_Server  
    END  
    IF @ActionType = 'FetchRecord'  
    BEGIN  
        SELECT servername,ipaddress,location_id,category_id,last_update_version FROM Target_Server   
        WHERE rowid=@rowid 
    END  
END  
GO
