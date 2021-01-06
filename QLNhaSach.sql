USE [QLNHASACH]
GO
/****** Object:  Table [dbo].[Danh_Muc]    Script Date: 1/6/2021 11:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Danh_Muc](
	[Ma_DM] [nchar](10) NULL,
	[Ten_DM] [nchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Don_Hang]    Script Date: 1/6/2021 11:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Don_Hang](
	[ID] [nchar](10) NULL,
	[date] [date] NULL,
	[ID_KH] [nchar](10) NULL,
	[discount] [nchar](10) NULL,
	[total_discount] [int] NULL,
	[total] [int] NULL,
	[ID_NV] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportDetail]    Script Date: 1/6/2021 11:22:55 PM ******/
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
/****** Object:  Table [dbo].[Imports]    Script Date: 1/6/2021 11:22:55 PM ******/
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
/****** Object:  Table [dbo].[Khach_Hang]    Script Date: 1/6/2021 11:22:55 PM ******/
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
/****** Object:  Table [dbo].[San_Pham]    Script Date: 1/6/2021 11:22:55 PM ******/
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
/****** Object:  Table [dbo].[SO_detail]    Script Date: 1/6/2021 11:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SO_detail](
	[ID_SO] [nchar](10) NULL,
	[MA_SP] [nchar](10) NULL,
	[So_Luong] [int] NULL,
	[Gia] [int] NULL,
	[total] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[userd]    Script Date: 1/6/2021 11:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userd](
	[name] [nchar](255) NULL,
	[account] [nchar](255) NULL,
	[password] [nchar](255) NULL,
	[role] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Danh_Muc] ([Ma_DM], [Ten_DM]) VALUES (N'DM01      ', N'Truyện Tranh                                                                                                                                                                                                                                                   ')
INSERT [dbo].[Danh_Muc] ([Ma_DM], [Ten_DM]) VALUES (N'DM02      ', N'Lịch Sử                                                                                                                                                                                                                                                        ')
INSERT [dbo].[Danh_Muc] ([Ma_DM], [Ten_DM]) VALUES (N'DM03      ', N'Khoa Học                                                                                                                                                                                                                                                       ')
INSERT [dbo].[Danh_Muc] ([Ma_DM], [Ten_DM]) VALUES (N'DM04      ', N'Toán Học                                                                                                                                                                                                                                                       ')
INSERT [dbo].[Danh_Muc] ([Ma_DM], [Ten_DM]) VALUES (N'DM06      ', N'Văn Học                                                                                                                                                                                                                                                        ')
INSERT [dbo].[Don_Hang] ([ID], [date], [ID_KH], [discount], [total_discount], [total], [ID_NV]) VALUES (N'SO01      ', CAST(0xFC410B00 AS Date), N'KH02      ', N'0         ', 0, 82000, N'1         ')
INSERT [dbo].[Don_Hang] ([ID], [date], [ID_KH], [discount], [total_discount], [total], [ID_NV]) VALUES (N'SO02      ', CAST(0xFD410B00 AS Date), N'KH02      ', N'10        ', 3200, 28800, N'1         ')
INSERT [dbo].[Don_Hang] ([ID], [date], [ID_KH], [discount], [total_discount], [total], [ID_NV]) VALUES (N'SO03      ', CAST(0xFE410B00 AS Date), N'KH02      ', N'10        ', 3200, 28800, N'1         ')
INSERT [dbo].[Don_Hang] ([ID], [date], [ID_KH], [discount], [total_discount], [total], [ID_NV]) VALUES (N'SO04      ', CAST(0xFE410B00 AS Date), N'KH03      ', N'0         ', 0, 32000, N'1         ')
INSERT [dbo].[Don_Hang] ([ID], [date], [ID_KH], [discount], [total_discount], [total], [ID_NV]) VALUES (N'SO05      ', CAST(0x02420B00 AS Date), N'KH02      ', N'10        ', 3200, 28800, N'1         ')
INSERT [dbo].[ImportDetail] ([id_import], [MA_SP], [SoLuong], [Gia]) VALUES (N'NK01      ', N'1         ', N'23        ', N'200000    ')
INSERT [dbo].[ImportDetail] ([id_import], [MA_SP], [SoLuong], [Gia]) VALUES (N'NK02      ', N'SP01      ', N'1         ', N'23        ')
INSERT [dbo].[Imports] ([ID], [date], [total], [note], [confim_import]) VALUES (N'NK01      ', CAST(0xF9410B00 AS Date), 4600000, N'                                                                                                                                                                                                                                                               ', N'Chưa Duyệt                                                                                          ')
INSERT [dbo].[Imports] ([ID], [date], [total], [note], [confim_import]) VALUES (N'NK02      ', CAST(0x02420B00 AS Date), 23, N'                                                                                                                                                                                                                                                               ', N'Chưa Duyệt                                                                                          ')
INSERT [dbo].[Khach_Hang] ([Ma_KH], [Ten_KH], [SDT_KH], [DIEM], [DiaChi], [Sex], [Email]) VALUES (N'KH01      ', N'Tèo                                                                                                                                                                                                                                                            ', N'0836584528 ', 0, NULL, NULL, NULL)
INSERT [dbo].[Khach_Hang] ([Ma_KH], [Ten_KH], [SDT_KH], [DIEM], [DiaChi], [Sex], [Email]) VALUES (N'KH02      ', N'Huỳnh Công Hậu                                                                                                                                                                                                                                                 ', N'123        ', 166, N'1234                                                                                                                                                                                                                                                           ', N'Nam       ', N'123@gmail.com                                                                                       ')
INSERT [dbo].[Khach_Hang] ([Ma_KH], [Ten_KH], [SDT_KH], [DIEM], [DiaChi], [Sex], [Email]) VALUES (N'KH03      ', N'asd                                                                                                                                                                                                                                                            ', N'321        ', 32, N'123                                                                                                                                                                                                                                                            ', N'Nam       ', N'123                                                                                                 ')
INSERT [dbo].[Khach_Hang] ([Ma_KH], [Ten_KH], [SDT_KH], [DIEM], [DiaChi], [Sex], [Email]) VALUES (N'KH04      ', N'test                                                                                                                                                                                                                                                           ', N'3123123    ', 0, N'123123                                                                                                                                                                                                                                                         ', N'Nam       ', N'23                                                                                                  ')
INSERT [dbo].[Khach_Hang] ([Ma_KH], [Ten_KH], [SDT_KH], [DIEM], [DiaChi], [Sex], [Email]) VALUES (N'KH05      ', N'1213123 haha                                                                                                                                                                                                                                                   ', N'123456     ', 0, N'qwe                                                                                                                                                                                                                                                            ', N'Nam       ', N'qwe                                                                                                 ')
INSERT [dbo].[San_Pham] ([Ma_SP], [Ten_SP], [Image], [Note], [NgayTao], [Ma_DM], [Price], [stock], [stock_mini]) VALUES (N'SP01      ', N'Toán Lớp 12                                                                                                                                                                                                                                                    ', N'sach-giao-khoa-giai-tich-12.jpg                                                                                                                                                                                                                                ', N'asdadasd                                                                                                                                                                                                                                                       ', CAST(0x0000AC9400000000 AS DateTime), N'DM04      ', 32000, 22, 5)
INSERT [dbo].[San_Pham] ([Ma_SP], [Ten_SP], [Image], [Note], [NgayTao], [Ma_DM], [Price], [stock], [stock_mini]) VALUES (N'SP02      ', N'Ngữ Văn Lớp 12                                                                                                                                                                                                                                                 ', N'ngu_van-lop-12.jpg                                                                                                                                                                                                                                             ', N'adadasdasds                                                                                                                                                                                                                                                    ', CAST(0x0000AC9400000000 AS DateTime), N'DM06      ', 50000, 2, 5)
INSERT [dbo].[San_Pham] ([Ma_SP], [Ten_SP], [Image], [Note], [NgayTao], [Ma_DM], [Price], [stock], [stock_mini]) VALUES (N'SP03      ', N'123                                                                                                                                                                                                                                                            ', NULL, N'123                                                                                                                                                                                                                                                            ', CAST(0x0000ACA500000000 AS DateTime), N'DM04      ', 12, 0, 0)
INSERT [dbo].[San_Pham] ([Ma_SP], [Ten_SP], [Image], [Note], [NgayTao], [Ma_DM], [Price], [stock], [stock_mini]) VALUES (N'SP04      ', N'qwe                                                                                                                                                                                                                                                            ', NULL, N'123                                                                                                                                                                                                                                                            ', CAST(0x0000ACA500000000 AS DateTime), N'DM04      ', 1, 0, 0)
INSERT [dbo].[SO_detail] ([ID_SO], [MA_SP], [So_Luong], [Gia], [total]) VALUES (N'SO01      ', N'SP02      ', 1, 50000, 50000)
INSERT [dbo].[SO_detail] ([ID_SO], [MA_SP], [So_Luong], [Gia], [total]) VALUES (N'SO01      ', N'SP01      ', 1, 32000, 32000)
INSERT [dbo].[SO_detail] ([ID_SO], [MA_SP], [So_Luong], [Gia], [total]) VALUES (N'SO02      ', N'SP01      ', 1, 32000, 32000)
INSERT [dbo].[SO_detail] ([ID_SO], [MA_SP], [So_Luong], [Gia], [total]) VALUES (N'SO03      ', N'SP01      ', 1, 32000, 32000)
INSERT [dbo].[SO_detail] ([ID_SO], [MA_SP], [So_Luong], [Gia], [total]) VALUES (N'SO04      ', N'SP01      ', 1, 32000, 32000)
INSERT [dbo].[SO_detail] ([ID_SO], [MA_SP], [So_Luong], [Gia], [total]) VALUES (N'SO05      ', N'SP01      ', 1, 32000, 32000)
SET IDENTITY_INSERT [dbo].[userd] ON 

INSERT [dbo].[userd] ([name], [account], [password], [role], [id]) VALUES (N'Huỳnh Thị Mỹ Phụng                                                                                                                                                                                                                                             ', N'9999                                                                                                                                                                                                                                                           ', N'202CB962AC59075B964B07152D234B70                                                                                                                                                                                                                               ', 1, 1)
INSERT [dbo].[userd] ([name], [account], [password], [role], [id]) VALUES (N'Nguyễn Văn B                                                                                                                                                                                                                                                   ', N'3333                                                                                                                                                                                                                                                           ', N'202CB962AC59075B964B07152D234B70                                                                                                                                                                                                                               ', 2, 2)
SET IDENTITY_INSERT [dbo].[userd] OFF
