USE [Security]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/3/2023 3:28:02 PM ******/
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
/****** Object:  Table [dbo].[ProjectActions]    Script Date: 5/3/2023 3:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectActions](
	[ProjectActionID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectActionName] [nvarchar](100) NOT NULL,
	[PersianTitle] [nvarchar](200) NULL,
	[ProjectControllerID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectActions] PRIMARY KEY CLUSTERED 
(
	[ProjectActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectAreas]    Script Date: 5/3/2023 3:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAreas](
	[ProjectAreaID] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [nvarchar](100) NOT NULL,
	[PersianTitle] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProjectAreas] PRIMARY KEY CLUSTERED 
(
	[ProjectAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectControllers]    Script Date: 5/3/2023 3:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectControllers](
	[ProjectControllerID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectControllerName] [nvarchar](128) NOT NULL,
	[PersianTitle] [nvarchar](200) NULL,
	[ProjectAreaID] [int] NULL,
 CONSTRAINT [PK_ProjectControllers] PRIMARY KEY CLUSTERED 
(
	[ProjectControllerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleActions]    Script Date: 5/3/2023 3:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleActions](
	[RoleActionID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[ProjectActionID] [int] NOT NULL,
	[HasPermission] [bit] NULL,
 CONSTRAINT [PK_RoleActions] PRIMARY KEY CLUSTERED 
(
	[RoleActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/3/2023 3:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/3/2023 3:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Email] [nvarchar](200) NULL,
	[Mobile] [nvarchar](20) NULL,
	[IsEmailActivated] [bit] NOT NULL,
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](30) NULL,
	[RoleID] [int] NOT NULL,
	[Address] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230415111054_inital', N'5.0.15')
GO
SET IDENTITY_INSERT [dbo].[ProjectActions] ON 
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (7, N'Index', N'پنل اصلی ادمین', 1)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (8, N'Index', N'صفحه اصلی مدیریت کاربران', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (10, N'UserSearchBox', N'مدیریت قسمت سرچ مدیرت کاربران', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (11, N'AddNew', N'نشان دادن صفحه اضافه کردن جدید در مدیریت کابران', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (13, N'AddNew', N'اضافه کردن کاربر جدید', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (14, N'UserList', N'مدیریت قسمت لیست کاربران در مدیریت کاربران', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (15, N'Delete', N'حذف کاربر', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (16, N'Update', N'نشان دادن صفحه اپدیت کاربر', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (17, N'Update', N'اپدیت کاربر', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (18, N'ChangePassword', N'نشان دادن صفحه تغییر رمز', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (19, N'ChangePassword', N'تغییر رمز', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (20, N'Profile', N'پروفایل کاربران', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (21, N'UpdateProfile', N'اپدیت پروفایل کاربران', 25)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (22, N'Index', N'صفحه اصلی مدیری تولیدکنندگان', 24)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (23, N'SupplierSearchBox', N'مدیریت قسمت سرچ مدیریت تولیدکنندگان', 24)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (24, N'AddNew', N'نشان دادن صفحه افزودن جدید تولید کنندگان', 24)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (25, N'AddNew', N'افزودن تولید کننده', 24)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (26, N'SupplierList', N'مدیریت قسمت لیست مدیریت تولید کنندگان', 24)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (27, N'Delete', N'حدف تولید کننده', 24)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (28, N'Update', N'نشان دادن صفحه اپدیت تولید کنندگان', 24)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (29, N'Update', N'اپدیت تولیدکننده', 24)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (30, N'Index', NULL, 23)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (32, N'AddNew', NULL, 23)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (33, N'Edit', NULL, 23)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (34, N'AddEdit', NULL, 23)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (35, N'Index', N'صفحه اصلی مدیریت نقش ها', 22)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (36, N'RoleSearchBox', N'قسمت سرچ مدیریت نقش ها', 22)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (37, N'AddNew', N'نشان دادن صفحه افزودن جدید نقش', 22)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (38, N'AddNew', N'افزودن نقش جدید', 22)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (39, N'RoleList', N'مدیریت قسمت لیست مدیریت نقش ها', 22)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (40, N'Delete', N'حذف نقش', 22)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (41, N'Update', N'نشان دادن صفحه اپدیت نقش ', 22)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (42, N'Update', N'اپدیت نقش', 22)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (43, N'Index', N'صفحه اصلی دسترسی ها', 21)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (44, N'RoleActionSearchBox', N'مدیریت قسمت سرچ دسترسی ها', 21)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (45, N'AddNew', N'نشان دادن دسترسی جدید', 21)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (46, N'AddNew', N'اعطا دسترسی', 21)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (47, N'RoleActionList', N'مدیریت قسمت لیست دسترسی ها', 21)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (48, N'DropDownAdd', N'برای کنترل دراب دان قسمت اعطا دسترسی ', 21)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (49, N'Delete', N'سلب دسترسی', 21)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (50, N'Index', N'صفحه اصلی مدیریت کالاهای مشابه', 20)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (51, N'RelatedProductSearchBox', N'مدیریت قسمت سرچ کالاهای مشابه', 20)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (53, N'RelatedProductList', N'مدیریت قسمت لیست کالاهای مشابه', 20)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (54, N'AddNew', N'افزودن کالاهای مشابه', 20)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (55, N'Delete', N'حذف کالای مشابه', 20)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (56, N'GetRelated', N'برای پر کردن دراپ دان کالای مشابه', 20)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (57, N'AddRelatedToProduct', N'افزودن چندین کالای مشابه ', 20)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (58, N'Index', N'صفحه اصلی مدیریت کنترلرها', 19)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (59, N'ControllerSearchBox', N'مدیریت قسمت سرچ مدیریت کنترلرها', 19)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (60, N'ControllerList', N'مدیریت قسمت لیست مدیریت کنترلرها', 19)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (61, N'AddNew', N'نشاندادن صفحه افزودن به کنترلرها', 19)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (62, N'AddNew', N'افزودن کنترلر جدید', 19)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (63, N'Delete', N'حذف کنترلر', 19)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (64, N'Update', N'نشان دادن صفحه اپدیت کنترلر', 19)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (65, N'Update', N'اپدیت کنترلر', 19)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (66, N'Index', N'مدیرین اریا', 18)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (67, N'AreaSearchBox', N'مدیریت قسمت سرچ اریا', 18)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (68, N'AreaList', N'مدیریت قسمت لیست مدیریت اریا', 18)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (69, N'AddNew', N'نشان دادن صفحه افزودن جدید اریا', 18)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (70, N'AddNew', N'افزودن اریا جدید', 18)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (71, N'Delete', N'حذف اریا', 18)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (72, N'Update', N'نشان دادن اپدیت اریا', 18)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (73, N'Update', N'اپدیت اریا', 18)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (74, N'Index', N'صفحه اصلی مدیریت اکشن', 17)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (75, N'ActionSearchBox', N'مدیریت قسمت سرج مدیریت اکشن ها', 17)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (76, N'ActionList', N'مدیریت قسمت لیست اکشن ها', 17)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (77, N'Delete', N'حذف اکشن', 17)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (78, N'AddNew', N'نشان دادن صفحه اضافه کردن اکشن', 17)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (79, N'AddNew', N'افزودن اکشن', 17)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (80, N'Update', N'نشان دادن صفحه اپدیت اکشن', 17)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (81, N'Update', N'اپدیت اکشن', 17)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (82, N'Index', N'صفحه اصلی مدیریت محصول', 16)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (83, N'Delete', N'حذف محصول', 16)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (84, N'AddNew', N'نشان دادن صفحه افزودن محصول', 16)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (85, N'AddNew', N'افزودن محصول جدید', 16)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (86, N'Update', N'نشان دادن صفحه اپدیت محصول', 16)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (87, N'Update', N'اپدیت', 16)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (88, N'ProductSearchBox', N'مدیریت قسمت سرچ محصولات', 16)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (89, N'Index', N'مدیریت کلمه های کلیدی محصول', 15)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (90, N'ProKeySearchBox', N'مدیریت قسمت سرچ کلمه های کلیدی محصول', 15)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (91, N'ProKeyList', N'مدیریت قسمت لیست کلمه های کلیدی محصول', 15)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (92, N'AddNew', N' افزودن کلمه های کلیدی محصول', 15)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (93, N'Delete', N'حذف کلمه کلیدی محصول', 15)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (95, N'Get', N'پر کردن دراپ دان کلمه کلیدی', 15)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (96, N'AddCategoryKeyword', N'اضافه کردن چندین کلمه کلیدی به محصول', 15)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (97, N'Index', N'صفحه اصلی مدیریت مقداردهی ویزگی های محصول', 14)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (98, N'ProductFeatureSearchBox', N'قسمت سرچ ویژگی های محصول', 14)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (99, N'ProductFeatureList', N'قسمت لیست ویژگی های محصول', 14)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (100, N'AddNew', N'افزودن یک ویژگی به محصول', 14)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (101, N'Update', N'اپدیت یک ویژگی محصول', 14)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (102, N'UpdateَAllProductFeature', N'اپدیت یک جا ویژگی های تغییر یافته', 14)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (103, N'Delete', N'حذف ویژگی', 14)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (104, N'Get', N'پرکردن دراپ دان ویژگی ها', 14)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (105, N'Index', NULL, 13)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (107, N'ProductDetails', NULL, 13)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (108, N'RemoveProductFromSessionById', NULL, 13)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (109, N'Index', NULL, 12)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (110, N'OrdersDetails', NULL, 12)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (111, N'AddToBasket', NULL, 12)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (112, N'Payment', NULL, 12)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (113, N'OnlinePayment', NULL, 12)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (114, N'OrderDetailsUser', N'نشان دادن صفحه جزییات خرید', 12)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (115, N'OrdersUser', N'نشان دادن صفحه خرید ', 12)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (117, N'Index', N'صفحه اصلی مدیریت سفارسات', 11)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (118, N'OrderAdminSearchBox', N'قسمت سرچ مدیریت سفارشات', 11)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (119, N'OrderAdminList', N'قسمت لیست مدیریت سفارشات', 11)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (120, N'OrderDetailsAdmin', N'نشان دادن جزییات سفارش', 11)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (121, N'UpdateIsFainaly', N'مدیریت قسمت تحویل داده شده یا مرجوعی', 11)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (122, N'Index', N'مدیریت کلمه های کلیدی', 10)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (123, N'KeyWordSearchBox', N'مدیریت قسمت سرچ کلمات کلیدی', 10)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (124, N'AddNew', N'نشان دادن صفحه افزودن کلمات کلیدی', 10)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (125, N'AddNew', N'افزودن کلمات کلید', 10)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (126, N'KeyWordList', N'مدیریت قسمت لیست کلمات کلیدی', 10)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (127, N'Delete', N'حذف کلمات کلیدی', 10)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (128, N'Update', N'نشان دادن صفحه اپدیت کلمات کلیدی', 10)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (129, N'Update', N'اپدیت کلمات کلیدی', 10)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (130, N'Index', N'مدیریت ویزگی ها', 8)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (131, N'FeatureSearchBox', N'مدیریت قسمت سرچ مدیریت ویژگی ها', 8)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (133, N'AddNew', N'نشان دادن صفحه افزودن جدید ویژگی ها', 8)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (134, N'AddNew', N'افزودن ویژگی ها', 8)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (135, N'FeatureList', N'مدیریت قسمت لیست ویژگی ها', 8)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (136, N'Delete', N'حذف ویژگی ها', 8)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (137, N'Update', N'نشان دادن صفحه اپدیت ویژگیها', 8)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (138, N'Update', N'اپدیت ویژگی ها', 8)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (139, N'Index', N'صفحه اصلی ', 9)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (140, N'CheckRoleType', N'چک کردن اگه دسترسی دارید لینک نشان داده شود', 9)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (141, N'Privacy', NULL, 9)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (142, N'Index', N'صفحه اصلی مدیریت ویزگی های دسته بندی', 7)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (143, N'CFSearchBox', N'مدیریت قسمت سرچ ویژگی های محصول', 7)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (144, N'CFList', N'مدیریت قسمت لیست ویژگی های محصول', 7)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (145, N'AddNew', N'اضافه کردن ویژگی های محصول', 7)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (146, N'Delete', N'حذف ویژگی ها', 7)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (147, N'Get', N'پر کردن دراپ دادن ویژگی ها', 7)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (148, N'AddCategoryFeature', N'ثبت چندین ویژگی دسته بندی یکجا', 7)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (149, N'Index', N'صفحه اصلی مدیریت ذسته بندی', 2)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (150, N'List', N'قسمت لیست دسته بندی', 2)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (151, N'Add', N'نشان دادن صفحه افزودن جدید دسته بندی ', 2)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (152, N'Add', N'اضافه کردن دسته بندی جدید', 2)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (153, N'Delete', N'حذف دسته بنذی', 2)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (155, N'Edit', N'نشان دادن اپدیت دسته بندی', 2)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (156, N'Edit', N'اپدیت دسته بندی', 2)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (157, N'CategorySearchBox', N'قسمت سرچ دسته بندی', 2)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (158, N'Index', NULL, 6)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (159, N'CategoryProductList', NULL, 6)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (160, N'Index', NULL, 4)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (161, N'AddNew', NULL, 4)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (162, N'Edit', NULL, 4)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (163, N'AddEdit', NULL, 4)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (164, N'Login', N'قسمت لاگین کاربر', 3)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (165, N'SignOut', N'خروج', 3)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (166, N'Login', NULL, 3)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (167, N'Create', N'کاربر جدید سمت ویزیتور', 3)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (168, N'Create', N'افزودن کاربر جدید', 3)
GO
INSERT [dbo].[ProjectActions] ([ProjectActionID], [ProjectActionName], [PersianTitle], [ProjectControllerID]) VALUES (169, N'AccessDenied', NULL, 3)
GO
SET IDENTITY_INSERT [dbo].[ProjectActions] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectAreas] ON 
GO
INSERT [dbo].[ProjectAreas] ([ProjectAreaID], [AreaName], [PersianTitle]) VALUES (1, N'Shop', N'فقط برای null نبودن')
GO
SET IDENTITY_INSERT [dbo].[ProjectAreas] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectControllers] ON 
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (1, N'PanelAdmin', N'پنل ادمین', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (2, N'CategoryManagement', N'دسته بندی', 1)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (3, N'Account', N'مدیریت اکانت', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (4, N'AdvertisementManagement', N'مدیریت تبلیغات', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (5, N'Base', N'', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (6, N'Category', NULL, NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (7, N'CatFea', N'مدیریت ویژگی های دسته بندی', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (8, N'FeatureManagement', N'مدیریت ویژگی ها', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (9, N'Home', NULL, NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (10, N'KeyWordManagement', N'مدیریت کلمه های کلیدی', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (11, N'OrdersAdmin', N'مدیریت قسمت سفارشات ادمین', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (12, N'Orders', N'سفارشات سمت کاربر', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (13, N'Product', NULL, NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (14, N'ProductFeature', N'مدیریت ویژگی های محصول', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (15, N'ProductKeyWord', N'مدیریت کلمه های کلیدی محصول', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (16, N'productManag', N'مدیریت محصول', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (17, N'ProjectActionManagement', N'مدیریت اکشن ها', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (18, N'ProjectAreaManagement', N'مدیریت اریا', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (19, N'ProjectControllerManagement', N'مدیریت کنترلر ها', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (20, N'RelatedProduct', N'مدیریت کالاهای مشابه', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (21, N'RoleActionManagement', N'مدیریت دسترسی ها', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (22, N'RoleManagement', N'مدیریت نقشها', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (23, N'SectionManagement', NULL, NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (24, N'SupplierManagment', N'مدیریت سازنده ها', NULL)
GO
INSERT [dbo].[ProjectControllers] ([ProjectControllerID], [ProjectControllerName], [PersianTitle], [ProjectAreaID]) VALUES (25, N'UserManagement', N'مدیریت کاربران', NULL)
GO
SET IDENTITY_INSERT [dbo].[ProjectControllers] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleActions] ON 
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (6, 1, 7, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (7, 1, 82, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (8, 1, 149, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (9, 1, 150, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (10, 1, 151, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (11, 1, 152, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (13, 1, 155, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (14, 1, 156, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (15, 1, 157, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (16, 1, 153, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (17, 1, 142, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (18, 1, 143, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (19, 1, 144, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (20, 1, 145, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (21, 1, 146, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (22, 1, 147, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (23, 1, 148, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (24, 1, 130, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (25, 1, 131, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (26, 1, 133, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (27, 1, 134, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (28, 1, 135, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (29, 1, 136, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (30, 1, 137, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (31, 1, 138, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (32, 1, 122, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (33, 1, 123, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (34, 1, 124, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (35, 1, 125, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (36, 1, 126, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (37, 1, 127, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (38, 1, 128, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (39, 1, 129, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (40, 1, 117, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (41, 1, 118, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (42, 1, 119, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (43, 1, 120, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (44, 1, 121, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (46, 1, 98, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (47, 1, 99, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (48, 1, 100, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (49, 1, 101, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (51, 1, 102, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (52, 1, 103, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (53, 1, 104, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (56, 1, 99, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (64, 1, 83, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (65, 1, 84, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (66, 1, 85, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (67, 1, 86, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (68, 1, 87, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (69, 1, 88, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (70, 1, 74, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (71, 1, 75, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (72, 1, 76, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (73, 1, 77, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (74, 1, 78, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (75, 1, 79, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (77, 1, 88, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (78, 1, 80, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (79, 1, 81, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (80, 1, 66, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (81, 1, 67, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (82, 1, 68, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (83, 1, 69, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (84, 1, 70, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (85, 1, 71, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (86, 1, 72, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (87, 1, 73, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (88, 1, 58, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (89, 1, 59, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (90, 1, 60, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (91, 1, 61, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (92, 1, 62, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (93, 1, 63, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (94, 1, 64, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (95, 1, 65, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (96, 1, 50, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (97, 1, 51, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (98, 1, 53, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (99, 1, 54, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (100, 1, 55, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (101, 1, 56, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (102, 1, 57, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (103, 1, 43, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (104, 1, 44, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (105, 1, 45, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (106, 1, 46, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (107, 1, 47, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (108, 1, 48, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (109, 1, 49, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (110, 1, 35, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (111, 1, 36, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (112, 1, 37, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (113, 1, 38, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (114, 1, 39, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (115, 1, 40, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (116, 1, 41, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (117, 1, 42, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (118, 1, 22, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (119, 1, 23, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (120, 1, 24, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (121, 1, 25, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (122, 1, 26, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (123, 1, 27, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (124, 1, 28, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (125, 1, 29, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (126, 1, 8, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (127, 1, 10, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (128, 1, 11, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (129, 1, 13, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (130, 1, 14, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (131, 1, 15, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (132, 1, 16, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (133, 1, 17, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (134, 1, 18, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (135, 1, 19, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (136, 1, 20, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (137, 1, 21, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (138, 1, 97, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (139, 1, 89, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (140, 1, 90, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (141, 1, 91, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (142, 1, 92, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (143, 1, 93, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (144, 1, 95, 1)
GO
INSERT [dbo].[RoleActions] ([RoleActionID], [RoleID], [ProjectActionID], [HasPermission]) VALUES (145, 1, 96, 1)
GO
SET IDENTITY_INSERT [dbo].[RoleActions] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Customer')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [Email], [Mobile], [IsEmailActivated], [FirstName], [LastName], [RoleID], [Address]) VALUES (1, N'a', N'10000.WdO4GRxeHjrfsm3Dw7/7lw==.+E048U4PimEF+LwSouchqIOXZwLgDRKv6fd9DxUlsFI=', N'a_refua@yahoo.com', N'09022583797', 1, N'افشین', N'رفوا', 1, N'تهران-شریعتی')
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [Email], [Mobile], [IsEmailActivated], [FirstName], [LastName], [RoleID], [Address]) VALUES (2, N'b', N'10000.WdO4GRxeHjrfsm3Dw7/7lw==.+E048U4PimEF+LwSouchqIOXZwLgDRKv6fd9DxUlsFI=', N'b@b.cc', N'123', 1, N'b', N'b', 2, N'مشهد')
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [Email], [Mobile], [IsEmailActivated], [FirstName], [LastName], [RoleID], [Address]) VALUES (3, N'c', N'10000.hrDEpXlxAI97nz9iryeYkQ==.dR3yvyCnd+jBYUgd411tQIN+67ADgXpmTa1NE17Wguw=', N'morteza.shahsavari.t@gmail.com', N'09371550995', 1, N'مرتضی ', N'شهسواری', 2, N'تبریز')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[ProjectActions]  WITH CHECK ADD  CONSTRAINT [FK_ProjectActions_ProjectControllers_ProjectControllerID] FOREIGN KEY([ProjectControllerID])
REFERENCES [dbo].[ProjectControllers] ([ProjectControllerID])
GO
ALTER TABLE [dbo].[ProjectActions] CHECK CONSTRAINT [FK_ProjectActions_ProjectControllers_ProjectControllerID]
GO
ALTER TABLE [dbo].[ProjectControllers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectControllers_ProjectAreas_ProjectAreaID] FOREIGN KEY([ProjectAreaID])
REFERENCES [dbo].[ProjectAreas] ([ProjectAreaID])
GO
ALTER TABLE [dbo].[ProjectControllers] CHECK CONSTRAINT [FK_ProjectControllers_ProjectAreas_ProjectAreaID]
GO
ALTER TABLE [dbo].[RoleActions]  WITH CHECK ADD  CONSTRAINT [FK_RoleActions_ProjectActions_ProjectActionID] FOREIGN KEY([ProjectActionID])
REFERENCES [dbo].[ProjectActions] ([ProjectActionID])
GO
ALTER TABLE [dbo].[RoleActions] CHECK CONSTRAINT [FK_RoleActions_ProjectActions_ProjectActionID]
GO
ALTER TABLE [dbo].[RoleActions]  WITH CHECK ADD  CONSTRAINT [FK_RoleActions_Roles_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[RoleActions] CHECK CONSTRAINT [FK_RoleActions_Roles_RoleID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleID]
GO
