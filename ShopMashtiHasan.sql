USE [ShopMashtiHasan]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvertisementInSections]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvertisementInSections](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdvertisementId] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[ResourceTitle] [nvarchar](50) NULL,
	[ResourceId] [int] NOT NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_AdvertisementInSections] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Advertisements]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisements](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Alt] [nvarchar](max) NULL,
	[Picture] [nvarchar](500) NULL,
	[Deleted] [bit] NOT NULL,
	[ExpireDate] [datetime2](7) NOT NULL,
	[link] [nvarchar](max) NULL,
 CONSTRAINT [PK_Advertisements] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[SmallDescription] [nvarchar](400) NULL,
	[ParentID] [int] NULL,
	[Lineage] [nvarchar](400) NULL,
	[ProductCount] [int] NOT NULL,
	[Depth] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryFeatures]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryFeatures](
	[CategoryFeatureID] [int] IDENTITY(1,1) NOT NULL,
	[FeatureID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_CategoryFeatures] PRIMARY KEY CLUSTERED 
(
	[CategoryFeatureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[FeatureID] [int] IDENTITY(1,1) NOT NULL,
	[FeatureName] [nvarchar](100) NULL,
	[FeatureDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED 
(
	[FeatureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeyWords]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyWords](
	[KeyWordID] [int] IDENTITY(1,1) NOT NULL,
	[KeyWordText] [nvarchar](100) NULL,
 CONSTRAINT [PK_KeyWords] PRIMARY KEY CLUSTERED 
(
	[KeyWordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [bigint] NOT NULL,
	[TotalPrice] [bigint] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[OrderDescription] [nvarchar](400) NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[RequiredDate] [datetime2](7) NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[IsFainaly] [bit] NOT NULL,
	[Mobile] [nvarchar](30) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductFeatureValues]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductFeatureValues](
	[ProductFeatureValueID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[FeatureID] [int] NOT NULL,
	[FeatureValue] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProductFeatureValues] PRIMARY KEY CLUSTERED 
(
	[ProductFeatureValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductKeyWords]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductKeyWords](
	[ProductKeyWordID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[KeywordID] [int] NOT NULL,
 CONSTRAINT [PK_ProductKeyWords] PRIMARY KEY CLUSTERED 
(
	[ProductKeyWordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[SmallDescription] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[SupplierID] [int] NOT NULL,
	[ShowInAmazingOffer] [bit] NOT NULL,
	[ShowInInstantOffer] [bit] NOT NULL,
	[ExpireDateSpecialOffer] [datetime2](7) NULL,
	[CategoryID] [int] NOT NULL,
	[Picture1] [nvarchar](max) NULL,
	[Picture2] [nvarchar](max) NULL,
	[IsNew] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelatedProducts]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelatedProducts](
	[RelatedProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[RelatedToID] [int] NOT NULL,
 CONSTRAINT [PK_RelatedProducts] PRIMARY KEY CLUSTERED 
(
	[RelatedProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sections]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EnglishName] [nvarchar](max) NULL,
	[FarsiName] [nvarchar](max) NULL,
	[ControllerName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 5/3/2023 3:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](100) NULL,
	[Address] [nvarchar](500) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Tel] [nvarchar](15) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230415110552_inital', N'5.0.15')
GO
SET IDENTITY_INSERT [dbo].[AdvertisementInSections] ON 
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (12, 15, 3, N'home', 0, 0)
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (13, 16, 2, NULL, 0, 0)
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (14, 17, 2, NULL, 0, 0)
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (15, 18, 2, NULL, 0, 0)
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (16, 19, 2, NULL, 0, 0)
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (17, 20, 6, NULL, 0, 1)
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (18, 21, 6, NULL, 0, 2)
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (19, 22, 6, NULL, 0, 3)
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (20, 23, 6, NULL, 0, 4)
GO
INSERT [dbo].[AdvertisementInSections] ([ID], [AdvertisementId], [SectionId], [ResourceTitle], [ResourceId], [Position]) VALUES (21, 24, 6, NULL, 0, 5)
GO
SET IDENTITY_INSERT [dbo].[AdvertisementInSections] OFF
GO
SET IDENTITY_INSERT [dbo].[Advertisements] ON 
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (15, NULL, N'~/AdvertisementImages/c41fed49_993c_4a2e_a623_739e66a32fe0_22f48d8e-6a8f-431c-985d-76ab0e1e59405_21_1_1.jpg', 0, CAST(N'0001-01-24T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (16, NULL, N'~/AdvertisementImages/c8d0a909_d4cc_4506_8138_b89c899a0322_banner-2.jpg', 0, CAST(N'0001-01-22T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (17, NULL, N'~/AdvertisementImages/a744e678_8555_4f68_a9f9_f59643b6d51a_banner-3.jpg', 0, CAST(N'0001-01-24T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (18, NULL, N'~/AdvertisementImages/51f94cd9_cb3d_4a59_9fe9_e1804b8bd020_banner-4.jpg', 0, CAST(N'0001-01-23T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (19, NULL, N'~/AdvertisementImages/47a1c95f_d461_47ae_beb8_1cb55e71992c_banner-1.jpg', 0, CAST(N'0001-01-28T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (20, NULL, N'~/AdvertisementImages/7fb20119_382a_4cbf_bea3_e03383fea781_8d546388-29d7-4733-871f-2d84a3012cc227_21_1_6.jpeg', 0, CAST(N'0001-01-21T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (21, NULL, N'~/AdvertisementImages/eb8e0d9a_9634_4bf6_a938_3b96bb70f535_side-banner-01.jpeg', 0, CAST(N'0001-01-21T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (22, NULL, N'~/AdvertisementImages/cab6a99b_d264_49eb_ab3f_9fb2fc46c30f_1000001442.jpg', 0, CAST(N'0001-01-30T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (23, NULL, N'~/AdvertisementImages/240f93b9_6ace_4259_8dad_dabb924162c0_1000001322.jpg', 0, CAST(N'0001-02-07T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Advertisements] ([ID], [Alt], [Picture], [Deleted], [ExpireDate], [link]) VALUES (24, NULL, N'~/AdvertisementImages/fc05adf9_210d_4ed4_8d14_6a13df556490_1000001422.jpg', 0, CAST(N'0001-02-02T00:00:00.0000000' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[Advertisements] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (2, N'Digital', N'22', NULL, N'2,', 7, 1)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (3, N'Mobile', N'scsdfcasdc', 2, N'2,3,', 4, 2)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (4, N'Samsung', N'jhjh', 3, N'2,3,4,', 3, 3)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (5, N'A Series', N'kjkj', 4, N'2,3,4,5,', 1, 4)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (6, N'S Series', N'jksssjk', 4, N'2,3,4,6,', 0, 4)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (7, N'A10', N'jjbhj', 5, N'2,3,4,5,7,', 0, 5)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (8, N'pc', N'pc', 2, N'2,8,', 0, 2)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (9, N'Labtop', N'labtop', 2, N'2,9,', 0, 2)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (16, N'سوپرمارکت', N'مارکت', NULL, N'16,', 1, 1)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (17, N'لبنیات', N'ابنیجاتن', 16, N'16,17,', 1, 2)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [SmallDescription], [ParentID], [Lineage], [ProductCount], [Depth]) VALUES (19, N'کریجات', N'سبزیجات', 17, N'16,17,19,', 0, 3)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryFeatures] ON 
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (37, 9, 2)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (38, 9, 2)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (59, 4, 2)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (60, 10, 2)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (61, 1, 2)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (62, 1, 2)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (72, 2, 4)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (84, 4, 9)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (85, 10, 9)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (86, 6, 9)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (89, 2, 9)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (90, 3, 9)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (100, 5, 17)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (101, 6, 17)
GO
INSERT [dbo].[CategoryFeatures] ([CategoryFeatureID], [FeatureID], [CategoryID]) VALUES (102, 5, 19)
GO
SET IDENTITY_INSERT [dbo].[CategoryFeatures] OFF
GO
SET IDENTITY_INSERT [dbo].[Features] ON 
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (1, N'حافظه داخلی', N'حافظه داخلی')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (2, N'شبکه های ارتباطی', N'شبکه های ارتباطی')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (3, N'رزولوشن عکس', N'رزولوشن عکس')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (4, N'تعداد سیم کارت', N'تعداد سیم کارت')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (5, N'ویژگی‌های خاص', N'ویژگی‌های خاص')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (6, N'ابعاد', N'ابعاد')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (7, N'توضیحات سیم کارت
', N'توضیحات سیم کارت
')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (8, N'ویژگی‌های خاص
', N'ویژگی‌های خاص
')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (9, N'تعداد سیم کارت
', N'تعداد سیم کارت
')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (10, N'تراشه', N'تراشه')
GO
INSERT [dbo].[Features] ([FeatureID], [FeatureName], [FeatureDescription]) VALUES (11, N'نوع پردازنده
', N'نوع پردازنده
')
GO
SET IDENTITY_INSERT [dbo].[Features] OFF
GO
SET IDENTITY_INSERT [dbo].[KeyWords] ON 
GO
INSERT [dbo].[KeyWords] ([KeyWordID], [KeyWordText]) VALUES (1, N'salam')
GO
INSERT [dbo].[KeyWords] ([KeyWordID], [KeyWordText]) VALUES (2, N'byby')
GO
SET IDENTITY_INSERT [dbo].[KeyWords] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (50, 38, 84, 3, 8500000, 25500000)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (51, 39, 71, 3, 4180000, 12540000)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (52, 39, 81, 1, 6500000, 6500000)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (53, 40, 71, 1, 4180000, 4180000)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (54, 41, 71, 2, 4180000, 8360000)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (55, 41, 81, 1, 6500000, 6500000)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (56, 42, 71, 3, 4180000, 12540000)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (57, 42, 95, 2, 9000000, 18000000)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (58, 43, 72, 2, 5380000, 10760000)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice], [TotalPrice]) VALUES (59, 43, 82, 2, 7500000, 15000000)
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderDescription], [OrderDate], [Address], [RequiredDate], [TotalAmount], [IsFainaly], [Mobile]) VALUES (38, 1, N'سبد خرید کاربر1', CAST(N'2023-04-28T16:41:26.5338227' AS DateTime2), NULL, CAST(N'2023-04-28T16:41:26.5339429' AS DateTime2), CAST(32460000.00 AS Decimal(18, 2)), 1, N'09022583797')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderDescription], [OrderDate], [Address], [RequiredDate], [TotalAmount], [IsFainaly], [Mobile]) VALUES (39, 1, N'سبد خرید کاربر1', CAST(N'2023-04-28T16:45:33.9974341' AS DateTime2), N'تهران', CAST(N'2023-04-28T16:45:33.9975277' AS DateTime2), CAST(19040000.00 AS Decimal(18, 2)), 1, N'09022583797')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderDescription], [OrderDate], [Address], [RequiredDate], [TotalAmount], [IsFainaly], [Mobile]) VALUES (40, 1, N'سبد خرید کاربر1', CAST(N'2023-04-28T16:48:19.8160582' AS DateTime2), N'تهران', CAST(N'2023-04-28T16:48:19.8161392' AS DateTime2), CAST(4180000.00 AS Decimal(18, 2)), 1, N'09022583797')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderDescription], [OrderDate], [Address], [RequiredDate], [TotalAmount], [IsFainaly], [Mobile]) VALUES (41, 1, N'سبد خرید کاربر1', CAST(N'2023-04-28T17:02:20.3630987' AS DateTime2), N'تهران-شریعتی', CAST(N'2023-04-28T17:02:20.3632300' AS DateTime2), CAST(14860000.00 AS Decimal(18, 2)), 1, N'09022583797')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderDescription], [OrderDate], [Address], [RequiredDate], [TotalAmount], [IsFainaly], [Mobile]) VALUES (42, 2, N'سبد خرید کاربر2', CAST(N'2023-04-28T17:03:35.4437503' AS DateTime2), N'مشهد', CAST(N'2023-04-28T17:03:35.4437516' AS DateTime2), CAST(30540000.00 AS Decimal(18, 2)), 1, N'123')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderDescription], [OrderDate], [Address], [RequiredDate], [TotalAmount], [IsFainaly], [Mobile]) VALUES (43, 2, N'سبد خرید کاربر2', CAST(N'2023-04-28T17:41:30.5597808' AS DateTime2), N'مشهد', CAST(N'2023-04-28T17:41:30.5598665' AS DateTime2), CAST(25760000.00 AS Decimal(18, 2)), 1, N'123')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductFeatureValues] ON 
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (9, 71, 11, N'snap dragon16')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (10, 72, 11, N'snap dragon16')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (11, 73, 11, N'snap dragon16')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (12, 74, 11, N'snap dragon16')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (13, 75, 11, N'snap dragon16')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (14, 76, 11, N'snap dragon16')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (15, 77, 11, N'snap dragon16')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (16, 78, 11, N'snap dragon16')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (17, 79, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (18, 80, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (19, 81, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (20, 82, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (21, 83, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (22, 84, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (23, 85, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (24, 86, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (25, 87, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (26, 88, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (27, 89, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (28, 90, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (29, 91, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (30, 92, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (31, 93, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (32, 94, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (33, 95, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (34, 96, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (35, 97, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (36, 98, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (37, 99, 1, N'sacad')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (97, 150, 4, N'')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (98, 150, 10, N'')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (99, 150, 6, N'')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (100, 150, 2, N'')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (101, 150, 3, N'')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (1100, 152, 5, N'gf')
GO
INSERT [dbo].[ProductFeatureValues] ([ProductFeatureValueID], [ProductID], [FeatureID], [FeatureValue]) VALUES (1101, 152, 6, N'gg')
GO
SET IDENTITY_INSERT [dbo].[ProductFeatureValues] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductKeyWords] ON 
GO
INSERT [dbo].[ProductKeyWords] ([ProductKeyWordID], [ProductID], [KeywordID]) VALUES (2, 93, 1)
GO
INSERT [dbo].[ProductKeyWords] ([ProductKeyWordID], [ProductID], [KeywordID]) VALUES (24, 84, 1)
GO
INSERT [dbo].[ProductKeyWords] ([ProductKeyWordID], [ProductID], [KeywordID]) VALUES (25, 85, 1)
GO
INSERT [dbo].[ProductKeyWords] ([ProductKeyWordID], [ProductID], [KeywordID]) VALUES (26, 85, 1)
GO
INSERT [dbo].[ProductKeyWords] ([ProductKeyWordID], [ProductID], [KeywordID]) VALUES (30, 85, 1)
GO
INSERT [dbo].[ProductKeyWords] ([ProductKeyWordID], [ProductID], [KeywordID]) VALUES (44, 99, 2)
GO
INSERT [dbo].[ProductKeyWords] ([ProductKeyWordID], [ProductID], [KeywordID]) VALUES (45, 99, 1)
GO
SET IDENTITY_INSERT [dbo].[ProductKeyWords] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (71, N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B', 4180000, N'لپ تاپ INSPIRON ', N'لپ تاپ INSPIRON ', 60, 1, 0, CAST(N'2022-12-26T09:35:00.0000000' AS DateTime2), 9, N'~/ProductImages/0e8831e1_1ad7_4b03_8bf2_ccc24e7a8b81_0e6809-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (72, N'لپ تاپ ۱۵ اینچی ایسوس مدل VivoBook Flip TP510UQ – C ', 5380000, N'لپ تاپ  ایسوس مدل', N'لپ تاپ  ایسوس مدل', 61, 1, 0, CAST(N'2022-12-26T09:36:00.0000000' AS DateTime2), 9, N'~/ProductImages/817b8f9b_6a18_4b3f_bd5c_25b94af52acb_59fc05-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (73, N'لپ تاپ ۱۴ اینچی دل مدل vostro 5471', 6580000, N'دل 5471', N'دل 5471', 59, 1, 0, CAST(N'2022-12-26T09:36:00.0000000' AS DateTime2), 9, N'~/ProductImages/866b2796_8cf2_4217_99cb_1bef09b2367a_4ff777-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (74, N'لپ تاپ ۱۵ اینچی لنوو مدل Ideapad V310 – S ', 2320000, N'لنوو مدل V310 – S  ', N'لنوو مدل V310 – S  ', 59, 1, 0, CAST(N'2022-12-26T09:36:00.0000000' AS DateTime2), 9, N'~/ProductImages/e7b95fa1_c064_4f8c_addc_865adce493d2_2d71f4-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (75, N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B ', 4180000, N'لپ تاپINSPIRON', N'لپ تاپ INSPIRON', 59, 1, 0, CAST(N'2022-12-28T09:40:00.0000000' AS DateTime2), 9, N'~/ProductImages/bcd37d0a_f534_493f_b872_71ac51e14a3d_60eb20-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (76, N'لپ تاپ ۱۵ اینچی دل مدل Latitude 5580 ', 4699000, N'لپ تاپ ۱۵ اینچی', N'لپ تاپ ۱۵ اینچی', 61, 1, 1, CAST(N'2022-12-18T09:44:00.0000000' AS DateTime2), 9, N'~/ProductImages/51e7e0b9_5e52_4a00_90a0_e3eb9f6da520_35a2b8-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (77, N'لپ تاپ ۱۵ اینچی دل مدل INSPIRON 7577 – D ', 8899000, N'۱۵ اینچی دل', N'۱۵ اینچی دل', 61, 1, 1, CAST(N'2022-12-18T09:45:00.0000000' AS DateTime2), 9, N'~/ProductImages/965e2ecb_3ff7_4d0c_8526_cafe962ec374_c8297f-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (78, N'لپ تاپ ۱۵ اینچی ایسوس مدل A540UP – F ', 2565000, N' ایسوس مدل A540UP – F ', N' ایسوس مدل A540UP – F ', 60, 0, 0, CAST(N'2022-12-19T09:46:00.0000000' AS DateTime2), 9, N'~/ProductImages/5a6404b3_f4d5_4cbc_9919_2ab0716b65d1_8eb96c-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (79, N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B', 4500000, N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B', N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B', 60, 0, 0, CAST(N'2022-12-29T10:37:00.0000000' AS DateTime2), 2, N'~/ProductImages/47a63daf_bdbe_40ef_9c5b_c4830ca393b6_47a1c95f_d461_47ae_beb8_1cb55e71992c_banner-1.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (80, N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B ', 5500000, N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B', N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B', 60, 0, 0, CAST(N'2022-12-27T10:38:00.0000000' AS DateTime2), 2, N'~/ProductImages/742312df_755c_408b_87c8_4a3be0211fb9_60eb20-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (81, N'لپ تاپ ۱۴ اینچی دل مدل vostro 5471', 6500000, N'لپ تاپ ۱۴ اینچی دل مدل vostro 5471', N'لپ تاپ ۱۴ اینچی دل مدل vostro 5471', 59, 0, 0, CAST(N'2022-12-28T10:38:00.0000000' AS DateTime2), 2, N'~/ProductImages/02213ac1_6451_4e2f_813c_bacfff150bb8_5a6404b3_f4d5_4cbc_9919_2ab0716b65d1_8eb96c-200x200.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (82, N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B', 7500000, N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B', N'لپ تاپ ۱۱٫۶ اینچی دل مدل INSPIRON 3168 -AC B', 59, 0, 0, NULL, 2, N'~/ProductImages/a833053e_0b99_4536_b27c_5108b8a100ae_4ff777-200x200.jpg', NULL, 1)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (83, N'لپ تاپ ۱۵ اینچی ایسوس مدل VivoBook Flip TP510UQ – C', 8500000, N'لپ تاپ ۱۵ اینچی ایسوس مدل VivoBook Flip TP510UQ – C', N'لپ تاپ ۱۵ اینچی ایسوس مدل VivoBook Flip TP510UQ – C', 61, 0, 0, NULL, 2, N'~/ProductImages/2ff50252_c898_4dc9_b5e3_5640503a06e7_bcd37d0a_f534_493f_b872_71ac51e14a3d_60eb20-200x200.jpg', NULL, 1)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (84, N'موبایل', 8500000, N'موبایل', N'موبایل', 59, 0, 0, CAST(N'2022-12-27T10:43:00.0000000' AS DateTime2), 3, N'~/ProductImages/8f2507cc_8ef4_43ce_a789_4166d9200448_images.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (85, N'موبایل', 8000000, N'موبایل', N'موبایل', 59, 0, 0, CAST(N'2022-12-27T10:43:00.0000000' AS DateTime2), 3, N'~/ProductImages/dac39544_92f6_4b62_8eb8_813442a10e5a_images (1).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (86, N'موبایل', 9000000, N'موبایل', N'موبایل', 61, 0, 0, CAST(N'2022-12-27T10:44:00.0000000' AS DateTime2), 3, N'~/ProductImages/b513b18a_aafa_4e42_8f48_ddd2872e8879_download (2).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (87, N'موبایل', 9000000, N'موبایل', N'موبایل', 61, 0, 0, NULL, 3, N'~/ProductImages/655cbd45_baf8_447f_b919_7d4fc4f8d897_download (1).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (88, N'موبایل', 15000000, N'موبایل', N'موبایل', 61, 0, 0, NULL, 3, N'~/ProductImages/545a42a8_a239_4b90_8c52_544062bd7691_images (3).jpg', NULL, 1)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (89, N'موبایل', 9000000, N'موبایل', N'موبایل', 60, 0, 0, NULL, 4, N'~/ProductImages/26d22b0b_cd41_499a_ab7e_10180076cf42_download (2).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (90, N'موبایل', 9000000, N'موبایل', N'موبایل', 60, 0, 0, NULL, 4, N'~/ProductImages/2c62d025_ffca_45e7_8b2a_187850efd4f2_images (1).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (91, N'موبایل', 9000000, N'موبایل', N'موبایل', 60, 0, 0, NULL, 4, N'~/ProductImages/de0e8283_2642_43e1_befd_9a4511af31ef_download (2).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (92, N'موبایل', 9000000, N'موبایل', N'موبایل', 60, 0, 0, NULL, 4, N'~/ProductImages/f51bdb25_973c_4e90_8404_85b26d42e505_download.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (93, N'موبایل', 9000000, N'موبایل', N'موبایل', 60, 0, 0, CAST(N'2022-12-17T10:46:00.0000000' AS DateTime2), 6, N'~/ProductImages/347090dc_605d_4239_ab3a_11f6c3e37535_images (3).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (94, N'موبایل', 9000000, N'موبایل', N'موبایل', 60, 0, 0, NULL, 6, N'~/ProductImages/4302d9c1_eed2_4ad1_b1d5_95ca00944402_images (1).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (95, N'موبایل', 9000000, N'موبایل', N'موبایل', 59, 0, 0, NULL, 6, N'~/ProductImages/a8321430_827a_4647_b4d3_2941736d94c4_download (3).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (96, N'موبایل', 9000000, N'موبایل', N'موبایل', 60, 0, 0, NULL, 6, N'~/ProductImages/7afb508e_defe_4918_838f_bbee12260b5f_dac39544_92f6_4b62_8eb8_813442a10e5a_images (1).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (97, N'موبایل', 9000000, N'موبایل', N'موبایل', 60, 0, 0, NULL, 5, N'~/ProductImages/82ba0674_d16b_4049_bf44_2b96bd46fddc_8f2507cc_8ef4_43ce_a789_4166d9200448_images.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (98, N'موبایل', 9000000, N'موبایل', N'موبایل', 61, 0, 0, NULL, 5, N'~/ProductImages/ba266da2_a762_47a3_8741_073e427a2ab3_26d22b0b_cd41_499a_ab7e_10180076cf42_download (2).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (99, N'موبایل', 9000000, N'موبایل', N'موبایل', 60, 0, 0, NULL, 4, N'~/ProductImages/0a0da737_40fc_4972_892f_5f5a9b9f7c85_2c62d025_ffca_45e7_8b2a_187850efd4f2_images (1).jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (150, N'ddd', 5555, N'asdsadas', N'aaa', 59, 0, 0, NULL, 9, N'~/ProductImages/c8a0c547_1692_4ad2_8481_94823aed5f4d_Onion.jpg', NULL, 0)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [UnitPrice], [SmallDescription], [Description], [SupplierID], [ShowInAmazingOffer], [ShowInInstantOffer], [ExpireDateSpecialOffer], [CategoryID], [Picture1], [Picture2], [IsNew]) VALUES (152, N'شیر', 12000, N'شیرشیر', N'شیرشیرشیر', 59, 0, 0, NULL, 17, N'~/ProductImages/4e2a8486_2e19_4937_87a7_269eec78a2e3_th.jpg', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[RelatedProducts] ON 
GO
INSERT [dbo].[RelatedProducts] ([RelatedProductID], [ProductID], [RelatedToID]) VALUES (7, 84, 83)
GO
INSERT [dbo].[RelatedProducts] ([RelatedProductID], [ProductID], [RelatedToID]) VALUES (8, 84, 74)
GO
INSERT [dbo].[RelatedProducts] ([RelatedProductID], [ProductID], [RelatedToID]) VALUES (17, 150, 71)
GO
INSERT [dbo].[RelatedProducts] ([RelatedProductID], [ProductID], [RelatedToID]) VALUES (18, 150, 73)
GO
SET IDENTITY_INSERT [dbo].[RelatedProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[Sections] ON 
GO
INSERT [dbo].[Sections] ([ID], [EnglishName], [FarsiName], [ControllerName]) VALUES (1, N'under_topbanner_homapage', N'زیر بنر بالای صفحه اصلی سایت', N'home')
GO
INSERT [dbo].[Sections] ([ID], [EnglishName], [FarsiName], [ControllerName]) VALUES (2, N'under_Special_HomPage', N'زیر شگفتانه های صفحه اصلی', N'home')
GO
INSERT [dbo].[Sections] ([ID], [EnglishName], [FarsiName], [ControllerName]) VALUES (3, N'under_categories', N'بنر زیر دسته بندهای صفحه اصلی', N'home')
GO
INSERT [dbo].[Sections] ([ID], [EnglishName], [FarsiName], [ControllerName]) VALUES (5, N'befor_lastProduct_homapage', N'بنر قبل از اخرین محصولات', N'home')
GO
INSERT [dbo].[Sections] ([ID], [EnglishName], [FarsiName], [ControllerName]) VALUES (6, N'sidebar_banners', N'بنرهای سمت راست صفحه اصلی', NULL)
GO
SET IDENTITY_INSERT [dbo].[Sections] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 
GO
INSERT [dbo].[Suppliers] ([SupplierID], [SupplierName], [Address], [Mobile], [Tel]) VALUES (59, N'Asus', N'USA', N'1234567891', N'123456789')
GO
INSERT [dbo].[Suppliers] ([SupplierID], [SupplierName], [Address], [Mobile], [Tel]) VALUES (60, N'Samsung', N'کره جنوبی', N'987654321', N'987654321')
GO
INSERT [dbo].[Suppliers] ([SupplierID], [SupplierName], [Address], [Mobile], [Tel]) VALUES (61, N'اپل', N'امریکا', N'7539518264', N'826459731')
GO
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((0)) FOR [ProductCount]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((1)) FOR [Depth]
GO
ALTER TABLE [dbo].[AdvertisementInSections]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementInSections_Advertisements_AdvertisementId] FOREIGN KEY([AdvertisementId])
REFERENCES [dbo].[Advertisements] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdvertisementInSections] CHECK CONSTRAINT [FK_AdvertisementInSections_Advertisements_AdvertisementId]
GO
ALTER TABLE [dbo].[AdvertisementInSections]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementInSections_Sections_SectionId] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdvertisementInSections] CHECK CONSTRAINT [FK_AdvertisementInSections_Sections_SectionId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_ParentID] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_ParentID]
GO
ALTER TABLE [dbo].[CategoryFeatures]  WITH CHECK ADD  CONSTRAINT [FK_CategoryFeatures_Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryFeatures] CHECK CONSTRAINT [FK_CategoryFeatures_Categories_CategoryID]
GO
ALTER TABLE [dbo].[CategoryFeatures]  WITH CHECK ADD  CONSTRAINT [FK_CategoryFeatures_Features_FeatureID] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([FeatureID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryFeatures] CHECK CONSTRAINT [FK_CategoryFeatures_Features_FeatureID]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderID]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductID]
GO
ALTER TABLE [dbo].[ProductFeatureValues]  WITH CHECK ADD  CONSTRAINT [FK_ProductFeatureValues_Features_FeatureID] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([FeatureID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductFeatureValues] CHECK CONSTRAINT [FK_ProductFeatureValues_Features_FeatureID]
GO
ALTER TABLE [dbo].[ProductFeatureValues]  WITH CHECK ADD  CONSTRAINT [FK_ProductFeatureValues_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductFeatureValues] CHECK CONSTRAINT [FK_ProductFeatureValues_Products_ProductID]
GO
ALTER TABLE [dbo].[ProductKeyWords]  WITH CHECK ADD  CONSTRAINT [FK_ProductKeyWords_KeyWords_KeywordID] FOREIGN KEY([KeywordID])
REFERENCES [dbo].[KeyWords] ([KeyWordID])
GO
ALTER TABLE [dbo].[ProductKeyWords] CHECK CONSTRAINT [FK_ProductKeyWords_KeyWords_KeywordID]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryID]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers_SupplierID] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers_SupplierID]
GO
ALTER TABLE [dbo].[RelatedProducts]  WITH CHECK ADD  CONSTRAINT [FK_RelatedProducts_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[RelatedProducts] CHECK CONSTRAINT [FK_RelatedProducts_Products]
GO
ALTER TABLE [dbo].[RelatedProducts]  WITH CHECK ADD  CONSTRAINT [FK_RelatedProducts_Products1] FOREIGN KEY([RelatedToID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[RelatedProducts] CHECK CONSTRAINT [FK_RelatedProducts_Products1]
GO
