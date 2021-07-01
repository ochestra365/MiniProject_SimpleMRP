USE [MRP]
GO
/****** Object:  Table [dbo].[Process]    Script Date: 2021-07-01 오후 2:02:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Process](
	[PrcIdx] [int] IDENTITY(1,1) NOT NULL,
	[SchIdx] [int] NOT NULL,
	[PrcCD] [char](14) NOT NULL,
	[PrcDate] [date] NOT NULL,
	[PrcLoadTime] [int] NULL,
	[PrcStartTime] [time](7) NULL,
	[PrcEndTime] [time](7) NULL,
	[PrcFacilityID] [char](8) NULL,
	[PrcResult] [bit] NOT NULL,
	[RegDate] [datetime] NULL,
	[RegID] [varchar](20) NULL,
	[ModDate] [datetime] NULL,
	[ModID] [varchar](20) NULL,
 CONSTRAINT [PK_Process] PRIMARY KEY CLUSTERED 
(
	[PrcIdx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 2021-07-01 오후 2:02:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[SchIdx] [int] IDENTITY(1,1) NOT NULL,
	[PlantCode] [char](8) NULL,
	[SchDate] [date] NOT NULL,
	[SchLoadTime] [int] NOT NULL,
	[SchStartTime] [time](7) NULL,
	[SchEndTime] [time](7) NULL,
	[SchFacilityID] [char](8) NULL,
	[SchAmount] [int] NULL,
	[RegDate] [datetime] NULL,
	[RegID] [varchar](20) NULL,
	[ModDate] [datetime] NULL,
	[ModID] [varchar](20) NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[SchIdx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 2021-07-01 오후 2:02:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[BasicCode] [char](8) NOT NULL,
	[CodeName] [nvarchar](100) NOT NULL,
	[CodeDesc] [nvarchar](max) NULL,
	[RegDate] [datetime] NULL,
	[RegID] [varchar](20) NULL,
	[ModDate] [datetime] NULL,
	[ModID] [varchar](20) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[BasicCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Process] ON 

INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (1, 4, N'PRC20210629001', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-29T10:25:01.380' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (2, 4, N'PRC20210629002', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 0, CAST(N'2021-06-29T10:26:02.840' AS DateTime), N'MRP', CAST(N'2021-06-29T11:20:27.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (3, 4, N'PRC20210629003', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-29T11:58:33.553' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (4, 4, N'PRC20210629004', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-29T11:59:05.970' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (5, 4, N'PRC20210629005', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-29T11:59:28.193' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (6, 4, N'PRC20210629006', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 0, CAST(N'2021-06-29T12:22:22.987' AS DateTime), N'MRP', CAST(N'2021-06-29T12:24:08.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (7, 4, N'PRC20210629007', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-29T12:28:54.200' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (8, 4, N'PRC20210629008', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 0, CAST(N'2021-06-29T12:32:39.527' AS DateTime), N'MRP', CAST(N'2021-06-29T12:41:30.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (9, 4, N'PRC20210629009', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-29T12:43:44.453' AS DateTime), N'MRP', CAST(N'2021-06-30T09:03:37.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (10, 6, N'PRC20210630001', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-30T09:36:05.113' AS DateTime), N'MRP', CAST(N'2021-06-30T09:36:36.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (11, 6, N'PRC20210630002', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 0, CAST(N'2021-06-30T09:43:40.537' AS DateTime), N'MRP', CAST(N'2021-06-30T09:44:03.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (12, 6, N'PRC20210630003', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 0, CAST(N'2021-06-30T09:44:39.027' AS DateTime), N'MRP', CAST(N'2021-06-30T09:44:56.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (13, 6, N'PRC20210630004', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 0, CAST(N'2021-06-30T10:01:57.893' AS DateTime), N'MRP', CAST(N'2021-06-30T10:10:12.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (14, 6, N'PRC20210630005', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-30T10:35:27.437' AS DateTime), N'MRP', CAST(N'2021-06-30T10:35:55.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (15, 6, N'PRC20210630006', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-30T10:36:10.843' AS DateTime), N'MRP', CAST(N'2021-06-30T10:36:22.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (16, 6, N'PRC20210630007', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-30T10:36:33.410' AS DateTime), N'MRP', CAST(N'2021-06-30T10:36:43.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (17, 6, N'PRC20210630008', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-30T10:37:28.643' AS DateTime), N'MRP', CAST(N'2021-06-30T10:37:40.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (18, 6, N'PRC20210630009', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-30T10:38:10.500' AS DateTime), N'MRP', CAST(N'2021-06-30T10:38:20.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (19, 6, N'PRC20210630010', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-30T10:45:27.787' AS DateTime), N'MRP', CAST(N'2021-06-30T10:45:40.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (20, 6, N'PRC20210630011', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-30T10:45:43.507' AS DateTime), N'MRP', CAST(N'2021-06-30T10:45:54.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (21, 6, N'PRC20210630012', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 0, CAST(N'2021-06-30T10:46:31.017' AS DateTime), N'MRP', CAST(N'2021-06-30T11:38:34.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (22, 6, N'PRC20210630013', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 0, CAST(N'2021-06-30T11:38:46.520' AS DateTime), N'MRP', CAST(N'2021-06-30T11:38:56.000' AS DateTime), N'SYS')
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (23, 6, N'PRC20210630014', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 1, CAST(N'2021-06-30T12:09:05.097' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (24, 7, N'PRC20210701001', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:03.240' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (25, 7, N'PRC20210701002', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:08.360' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (26, 7, N'PRC20210701003', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:13.530' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (27, 7, N'PRC20210701004', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:18.937' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (28, 7, N'PRC20210701005', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:24.183' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (29, 7, N'PRC20210701006', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:29.303' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (30, 7, N'PRC20210701007', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:31.217' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (31, 7, N'PRC20210701008', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:32.593' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (32, 7, N'PRC20210701009', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:34.207' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (33, 7, N'PRC20210701010', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:35.920' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (34, 7, N'PRC20210701011', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:37.850' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (35, 7, N'PRC20210701012', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:39.770' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (36, 7, N'PRC20210701013', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:41.520' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (37, 7, N'PRC20210701014', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:43.403' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (38, 7, N'PRC20210701015', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:45.747' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (39, 7, N'PRC20210701016', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:48.090' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (40, 7, N'PRC20210701017', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:50.497' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (41, 7, N'PRC20210701018', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:52.697' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (42, 7, N'PRC20210701019', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:54.827' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (43, 7, N'PRC20210701020', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T08:53:57.357' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (44, 7, N'PRC20210701021', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T09:17:22.787' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Process] ([PrcIdx], [SchIdx], [PrcCD], [PrcDate], [PrcLoadTime], [PrcStartTime], [PrcEndTime], [PrcFacilityID], [PrcResult], [RegDate], [RegID], [ModDate], [ModID]) VALUES (45, 7, N'PRC20210701022', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 1, CAST(N'2021-07-01T09:17:29.777' AS DateTime), N'MRP', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Process] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedules] ON 

INSERT [dbo].[Schedules] ([SchIdx], [PlantCode], [SchDate], [SchLoadTime], [SchStartTime], [SchEndTime], [SchFacilityID], [SchAmount], [RegDate], [RegID], [ModDate], [ModID]) VALUES (1, N'PC010001', CAST(N'2021-06-24' AS Date), 14, CAST(N'10:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10001', 50, CAST(N'2021-06-24T18:00:00.000' AS DateTime), N'SYS', CAST(N'2021-06-25T12:08:49.210' AS DateTime), N'MRP')
INSERT [dbo].[Schedules] ([SchIdx], [PlantCode], [SchDate], [SchLoadTime], [SchStartTime], [SchEndTime], [SchFacilityID], [SchAmount], [RegDate], [RegID], [ModDate], [ModID]) VALUES (2, N'PC010001', CAST(N'2021-06-25' AS Date), 10, CAST(N'09:00:00' AS Time), CAST(N'17:00:00' AS Time), N'FAC10001', 25, CAST(N'2021-06-25T12:38:49.950' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Schedules] ([SchIdx], [PlantCode], [SchDate], [SchLoadTime], [SchStartTime], [SchEndTime], [SchFacilityID], [SchAmount], [RegDate], [RegID], [ModDate], [ModID]) VALUES (3, N'PC010002', CAST(N'2021-06-28' AS Date), 5, NULL, NULL, N'FAC10002', 40, CAST(N'2021-06-28T09:20:56.160' AS DateTime), N'MRP', CAST(N'2021-06-28T14:05:01.380' AS DateTime), N'MRP')
INSERT [dbo].[Schedules] ([SchIdx], [PlantCode], [SchDate], [SchLoadTime], [SchStartTime], [SchEndTime], [SchFacilityID], [SchAmount], [RegDate], [RegID], [ModDate], [ModID]) VALUES (4, N'PC010002', CAST(N'2021-06-29' AS Date), 5, NULL, NULL, N'FAC10002', 30, CAST(N'2021-06-29T09:14:28.090' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Schedules] ([SchIdx], [PlantCode], [SchDate], [SchLoadTime], [SchStartTime], [SchEndTime], [SchFacilityID], [SchAmount], [RegDate], [RegID], [ModDate], [ModID]) VALUES (5, N'PC010002', CAST(N'2021-06-23' AS Date), 5, NULL, NULL, N'FAC10002', 10, CAST(N'2021-06-30T09:20:36.113' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Schedules] ([SchIdx], [PlantCode], [SchDate], [SchLoadTime], [SchStartTime], [SchEndTime], [SchFacilityID], [SchAmount], [RegDate], [RegID], [ModDate], [ModID]) VALUES (6, N'PC010002', CAST(N'2021-06-30' AS Date), 5, NULL, NULL, N'FAC10002', 20, CAST(N'2021-06-30T09:21:45.360' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Schedules] ([SchIdx], [PlantCode], [SchDate], [SchLoadTime], [SchStartTime], [SchEndTime], [SchFacilityID], [SchAmount], [RegDate], [RegID], [ModDate], [ModID]) VALUES (7, N'PC010002', CAST(N'2021-07-01' AS Date), 5, CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'FAC10002', 30, CAST(N'2021-07-01T08:52:59.130' AS DateTime), N'MRP', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Schedules] OFF
GO
INSERT [dbo].[Settings] ([BasicCode], [CodeName], [CodeDesc], [RegDate], [RegID], [ModDate], [ModID]) VALUES (N'FAC10001', N'설비1', N'생산설비1', CAST(N'2021-06-24T14:08:51.953' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Settings] ([BasicCode], [CodeName], [CodeDesc], [RegDate], [RegID], [ModDate], [ModID]) VALUES (N'FAC10002', N'설비2', N'생산설비2', CAST(N'2021-06-24T14:08:44.253' AS DateTime), N'MRP', NULL, NULL)
INSERT [dbo].[Settings] ([BasicCode], [CodeName], [CodeDesc], [RegDate], [RegID], [ModDate], [ModID]) VALUES (N'PC010001', N'수원공장', N'수원공장(코드) 11', CAST(N'2021-06-24T11:22:10.000' AS DateTime), N'SYS', CAST(N'2021-06-28T10:44:48.777' AS DateTime), N'MRP')
INSERT [dbo].[Settings] ([BasicCode], [CodeName], [CodeDesc], [RegDate], [RegID], [ModDate], [ModID]) VALUES (N'PC010002', N'부산공장', N'부산공장!!!', CAST(N'2021-06-24T13:58:07.337' AS DateTime), N'MRP', CAST(N'2021-06-28T10:44:42.657' AS DateTime), N'MRP')
INSERT [dbo].[Settings] ([BasicCode], [CodeName], [CodeDesc], [RegDate], [RegID], [ModDate], [ModID]) VALUES (N'TEST0001', N'테스트코드(수정)', N'테스트코드 설명', CAST(N'2021-06-24T16:01:47.310' AS DateTime), N'MRP', CAST(N'2021-06-24T16:03:38.033' AS DateTime), N'MRP')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Process_PrcCD]    Script Date: 2021-07-01 오후 2:02:09 ******/
ALTER TABLE [dbo].[Process] ADD  CONSTRAINT [UK_Process_PrcCD] UNIQUE NONCLUSTERED 
(
	[PrcCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Process]  WITH NOCHECK ADD  CONSTRAINT [FK_Process_Schedules] FOREIGN KEY([SchIdx])
REFERENCES [dbo].[Schedules] ([SchIdx])
GO
ALTER TABLE [dbo].[Process] NOCHECK CONSTRAINT [FK_Process_Schedules]
GO
ALTER TABLE [dbo].[Process]  WITH NOCHECK ADD  CONSTRAINT [FK_Process_Settings] FOREIGN KEY([PrcFacilityID])
REFERENCES [dbo].[Settings] ([BasicCode])
GO
ALTER TABLE [dbo].[Process] NOCHECK CONSTRAINT [FK_Process_Settings]
GO
ALTER TABLE [dbo].[Schedules]  WITH NOCHECK ADD  CONSTRAINT [FK_Schedules_Settings] FOREIGN KEY([PlantCode])
REFERENCES [dbo].[Settings] ([BasicCode])
GO
ALTER TABLE [dbo].[Schedules] NOCHECK CONSTRAINT [FK_Schedules_Settings]
GO
ALTER TABLE [dbo].[Schedules]  WITH NOCHECK ADD  CONSTRAINT [FK_Schedules_Settings1] FOREIGN KEY([SchFacilityID])
REFERENCES [dbo].[Settings] ([BasicCode])
GO
ALTER TABLE [dbo].[Schedules] NOCHECK CONSTRAINT [FK_Schedules_Settings1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공정계획 순번' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schedules', @level2type=N'COLUMN',@level2name=N'SchIdx'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공장코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schedules', @level2type=N'COLUMN',@level2name=N'PlantCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공정계획일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schedules', @level2type=N'COLUMN',@level2name=N'SchDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'로드타임(초)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schedules', @level2type=N'COLUMN',@level2name=N'SchLoadTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'시작시간(계획)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schedules', @level2type=N'COLUMN',@level2name=N'SchStartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'종료시간(계획)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schedules', @level2type=N'COLUMN',@level2name=N'SchEndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'생산설비ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schedules', @level2type=N'COLUMN',@level2name=N'SchFacilityID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'몰표수량(계획)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Schedules', @level2type=N'COLUMN',@level2name=N'SchAmount'