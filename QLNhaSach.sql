USE [QLNHASACH1]
GO
/****** Object:  Table [dbo].[Danh_Muc]    Script Date: 12/28/2020 11:14:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Danh_Muc](
	[Ma_DM] [nchar](10) NULL,
	[Ten_DM] [nchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportDetail]    Script Date: 12/28/2020 11:14:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportDetail](
	[id_import] [nchar](10) NULL,
	[MA_SP] [nchar](10) NULL,
	[SoLuong] [nchar](10) NULL,
	[Gia] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Imports]    Script Date: 12/28/2020 11:14:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imports](
	[ID] [nchar](10) NULL,
	[date] [date] NULL,
	[total] [int] NULL,
	[note] [nchar](255) NULL,
	[confim_import] [nchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khach_Hang]    Script Date: 12/28/2020 11:14:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khach_Hang](
	[Ma_KH] [nchar](10) NULL,
	[Ten_KH] [nchar](255) NULL,
	[SDT_KH] [nchar](11) NULL,
	[DIEM] [int] NULL,
	[DiaChi] [nchar](255) NULL,
	[Sex] [nchar](10) NULL,
	[Email] [nchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[San_Pham]    Script Date: 12/28/2020 11:14:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[San_Pham](
	[Ma_SP] [nchar](10) NULL,
	[Ten_SP] [nchar](255) NULL,
	[Image] [nchar](255) NULL,
	[Note] [nchar](255) NULL,
	[NgayTao] [datetime] NULL,
	[Ma_DM] [nchar](10) NULL,
	[Price] [int] NULL,
	[stock] [int] NULL,
	[stock_mini] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[userd]    Script Date: 12/28/2020 11:14:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userd](
	[id] [int] NOT NULL,
	[name] [nchar](255) NULL,
	[account] [nchar](255) NULL,
	[password] [nchar](255) NULL,
	[role] [int] NULL
) ON [PRIMARY]

GO
INSERT INTO [dbo].[userd]
           ([id]
           ,[name]
           ,[account]
           ,[password]
           ,[role])
     VALUES('12',N'Huỳnh Thị Mỹ Phụng','9999','202CB962AC59075B964B07152D234B70',1)
GO