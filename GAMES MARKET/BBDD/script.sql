USE [master]
GO
/****** Object:  Database [Games_Market]    Script Date: 25/05/2020 19:44:54 ******/
CREATE DATABASE [Games_Market]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Games_Market', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Games_Market.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Games_Market_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Games_Market_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Games_Market] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Games_Market].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Games_Market] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Games_Market] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Games_Market] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Games_Market] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Games_Market] SET ARITHABORT OFF 
GO
ALTER DATABASE [Games_Market] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Games_Market] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Games_Market] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Games_Market] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Games_Market] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Games_Market] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Games_Market] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Games_Market] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Games_Market] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Games_Market] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Games_Market] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Games_Market] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Games_Market] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Games_Market] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Games_Market] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Games_Market] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Games_Market] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Games_Market] SET RECOVERY FULL 
GO
ALTER DATABASE [Games_Market] SET  MULTI_USER 
GO
ALTER DATABASE [Games_Market] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Games_Market] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Games_Market] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Games_Market] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Games_Market] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Games_Market', N'ON'
GO
ALTER DATABASE [Games_Market] SET QUERY_STORE = OFF
GO
USE [Games_Market]
GO
/****** Object:  Table [dbo].[capturas]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[capturas](
	[id_captura] [int] IDENTITY(1,1) NOT NULL,
	[id_juego] [int] NOT NULL,
	[img_ruta] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_capturas] PRIMARY KEY CLUSTERED 
(
	[id_captura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[claves]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[claves](
	[id_clave] [int] IDENTITY(1,1) NOT NULL,
	[id_juego] [int] NOT NULL,
	[codigo] [nvarchar](max) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_claves_1] PRIMARY KEY CLUSTERED 
(
	[id_clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comentarios]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comentarios](
	[id_comentario] [int] IDENTITY(1,1) NOT NULL,
	[id_juego] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[comentario] [nvarchar](max) NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_comentarios_1] PRIMARY KEY CLUSTERED 
(
	[id_comentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[descuentos]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[descuentos](
	[id_descuento] [int] IDENTITY(1,1) NOT NULL,
	[id_juego] [int] NOT NULL,
	[descuento] [int] NOT NULL,
	[inicio] [date] NOT NULL,
	[fin] [date] NOT NULL,
	[img_ruta] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_descuentos_1] PRIMARY KEY CLUSTERED 
(
	[id_descuento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[deseados]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deseados](
	[id_deseados] [int] IDENTITY(1,1) NOT NULL,
	[id_juego] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_deseados] PRIMARY KEY CLUSTERED 
(
	[id_deseados] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[generos]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[generos](
	[id_genero] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_generos] PRIMARY KEY CLUSTERED 
(
	[id_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[generos_juegos]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[generos_juegos](
	[id_generos_juegos] [int] IDENTITY(1,1) NOT NULL,
	[id_genero] [int] NOT NULL,
	[id_juego] [int] NOT NULL,
 CONSTRAINT [PK_genero-juegos] PRIMARY KEY CLUSTERED 
(
	[id_generos_juegos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[juegos]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[juegos](
	[id_juego] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[id_plataforma] [int] NOT NULL,
	[precio] [numeric](5, 2) NOT NULL,
	[img_ruta] [nvarchar](max) NOT NULL,
	[trailer_url] [nvarchar](max) NOT NULL,
	[distribuidora] [nvarchar](max) NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[fecha_lanzamiento] [date] NOT NULL,
 CONSTRAINT [PK_juegos_1] PRIMARY KEY CLUSTERED 
(
	[id_juego] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plataformas]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plataformas](
	[id_plataforma] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[img_ruta] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_plataformas] PRIMARY KEY CLUSTERED 
(
	[id_plataforma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[apellidos] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[contrasena] [nvarchar](max) NOT NULL,
	[token] [nvarchar](max) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[valoraciones]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[valoraciones](
	[id_juego] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[valoracion] [int] NOT NULL,
 CONSTRAINT [PK_valoraciones_1] PRIMARY KEY CLUSTERED 
(
	[id_juego] ASC,
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 25/05/2020 19:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[id_clave] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[fecha_venta] [date] NOT NULL,
	[tarj] [nvarchar](max) NOT NULL,
	[tarj_mes] [nvarchar](max) NOT NULL,
	[tarj_ano] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[capturas] ON 

INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (1, 1, N'the-witcher-3-wild-hunt-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (2, 1, N'the-witcher-3-wild-hunt-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (4, 6, N'FinalFantasyVIIRemake-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (5, 6, N'FinalFantasyVIIRemake-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (6, 6, N'FinalFantasyVIIRemake-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (7, 6, N'FinalFantasyVIIRemake-captura4.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (8, 7, N'ResidentEvil3Remake-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (10, 7, N'ResidentEvil3Remake-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (11, 7, N'ResidentEvil3Remake-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (12, 3, N'Borderlands3-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (13, 3, N'Borderlands3-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (14, 3, N'Borderlands3-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (15, 8, N'Animal Crossing New Horizons-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (16, 8, N'Animal Crossing New Horizons-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (17, 8, N'Animal Crossing New Horizons-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (18, 9, N'Shadow of the tomb raider-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (19, 9, N'Shadow of the tomb raider-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (20, 9, N'Shadow of the tomb raider-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (21, 9, N'Shadow of the tomb raider-captura4.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (22, 15, N'DoomEternal-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (23, 15, N'DoomEternal-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (24, 15, N'DoomEternal-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (25, 15, N'DoomEternal-captura4.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (26, 17, N'nioh2-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (27, 17, N'nioh2-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (28, 17, N'nioh2-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (29, 17, N'nioh2-captura4.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (30, 18, N'RedDeadRedemption2-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (31, 18, N'RedDeadRedemption2-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (32, 18, N'RedDeadRedemption2-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (33, 18, N'RedDeadRedemption2-captura4.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (34, 19, N'LegendOfZeldaTheBreathWild-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (35, 19, N'LegendOfZeldaTheBreathWild-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (36, 19, N'LegendOfZeldaTheBreathWild-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (37, 19, N'LegendOfZeldaTheBreathWild-captura4.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (38, 20, N'NierAutomata-captura1.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (39, 20, N'NierAutomata-captura2.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (40, 20, N'NierAutomata-captura3.jpg')
INSERT [dbo].[capturas] ([id_captura], [id_juego], [img_ruta]) VALUES (41, 20, N'NierAutomata-captura4.jpg')
SET IDENTITY_INSERT [dbo].[capturas] OFF
SET IDENTITY_INSERT [dbo].[claves] ON 

INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (1, 6, N'B4JF8-E524R-T5443', 0)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (2, 6, N'7186R-9JTNQ-59H7A
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (3, 1, N'RP7J8-71TFS-583MI
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (4, 1, N'SL864-F56A5-384G3
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (5, 1, N'P6J76-9BB12-37DB2', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (6, 3, N'8P98I-9AM19-SNH34
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (7, 3, N'36453-3SE69-EQI33
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (8, 7, N'6DP65-52TB3-5FHB6
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (9, 9, N'44Q7F-FDCSI-6GMDM
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (10, 9, N'N67T9-3896E-NB5Q8
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (11, 15, N'S859K-BLMI8-TCNDI
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (12, 17, N'683L9-8A88F-QSPKB
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (13, 20, N'BJ28T-47278-58C33
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (14, 20, N'BNCRN-63547-QC5A9
', 1)
INSERT [dbo].[claves] ([id_clave], [id_juego], [codigo], [estado]) VALUES (15, 19, N'974TK-994J5-DHL35
', 1)
SET IDENTITY_INSERT [dbo].[claves] OFF
SET IDENTITY_INSERT [dbo].[comentarios] ON 

INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (1, 1, 4, N'¡Menuda ambientación! Me han encantado las aventuras de Gerardo el magias, te hace sentir todo un brujero y se te pasan las horas volando.', CAST(N'2020-05-13T14:22:33.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (4, 8, 6, N'¿Por qué está agotado en todos sitios? Si tampoco es tan bueno', CAST(N'2020-05-20T14:25:42.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (5, 8, 7, N'Madre mía, que juegazo. Llevo todo el confinamiento viciando.', CAST(N'2020-05-20T14:32:12.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (6, 20, 3, N'¡Qué bonito! Es un juego precioso, me quedo embobado mirando los paisajes.', CAST(N'2020-05-20T14:28:33.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (7, 15, 6, N'Sé lo compré a mi madre. Y no le gustó, mucha sangre  :(', CAST(N'2020-05-20T14:29:36.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (8, 18, 3, N'El multijugador tiene muchas posibilidades, me lo compré por eso y por la nostalgia del de PS3', CAST(N'2020-05-20T14:30:42.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (9, 6, 6, N'Está bien, pero el original está mejor, ya podrían vender el juego completo y no por partes', CAST(N'2020-05-20T14:32:20.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (10, 3, 7, N'No paran de actualizarlo y meter eventos, me tiene todo el día delante del PC y no se acaba.', CAST(N'2020-05-20T14:35:52.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (11, 1, 6, N'¿Quién lo va a comprar? Si se rumorea que lo van a regalar en la Epic.', CAST(N'2020-05-20T14:38:12.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (12, 8, 3, N'El online es una pasada.', CAST(N'2020-05-20T14:40:20.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (13, 20, 6, N'Este no es un juego que hatear, me voy a otro juego.', CAST(N'2020-05-20T14:42:08.000' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (14, 6, 4, N'Barret es brutal', CAST(N'2020-05-24T21:24:40.373' AS DateTime))
INSERT [dbo].[comentarios] ([id_comentario], [id_juego], [id_usuario], [comentario], [fecha]) VALUES (16, 17, 4, N'Lo recomiendo mucho es muy divertido!', CAST(N'2020-05-25T00:22:25.890' AS DateTime))
SET IDENTITY_INSERT [dbo].[comentarios] OFF
SET IDENTITY_INSERT [dbo].[descuentos] ON 

INSERT [dbo].[descuentos] ([id_descuento], [id_juego], [descuento], [inicio], [fin], [img_ruta]) VALUES (2, 6, 20, CAST(N'2020-05-01' AS Date), CAST(N'2020-06-30' AS Date), N'FinalFantasyVIIRemake.jpg')
INSERT [dbo].[descuentos] ([id_descuento], [id_juego], [descuento], [inicio], [fin], [img_ruta]) VALUES (3, 8, 5, CAST(N'2020-05-01' AS Date), CAST(N'2020-06-30' AS Date), N'AnimalCrossingNewHorizonsjpg.jpg')
SET IDENTITY_INSERT [dbo].[descuentos] OFF
SET IDENTITY_INSERT [dbo].[deseados] ON 

INSERT [dbo].[deseados] ([id_deseados], [id_juego], [id_usuario]) VALUES (17, 7, 4)
INSERT [dbo].[deseados] ([id_deseados], [id_juego], [id_usuario]) VALUES (20, 3, 4)
INSERT [dbo].[deseados] ([id_deseados], [id_juego], [id_usuario]) VALUES (24, 6, 4)
INSERT [dbo].[deseados] ([id_deseados], [id_juego], [id_usuario]) VALUES (26, 17, 4)
INSERT [dbo].[deseados] ([id_deseados], [id_juego], [id_usuario]) VALUES (27, 8, 4)
SET IDENTITY_INSERT [dbo].[deseados] OFF
SET IDENTITY_INSERT [dbo].[generos] ON 

INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (1, N'Acción')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (2, N'Aventura')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (3, N'Puzzles')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (4, N'RPG')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (5, N'Shooter')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (6, N'Indie')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (7, N'Aventura gráfica')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (8, N'Carreras')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (9, N'Horror')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (10, N'Survival')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (11, N'Lucha')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (12, N'Musical')
INSERT [dbo].[generos] ([id_genero], [nombre]) VALUES (13, N'Plataformas')
SET IDENTITY_INSERT [dbo].[generos] OFF
SET IDENTITY_INSERT [dbo].[generos_juegos] ON 

INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (1, 1, 9)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (2, 2, 1)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (3, 2, 8)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (4, 2, 9)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (5, 4, 6)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (6, 5, 3)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (7, 10, 9)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (10, 1, 15)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (11, 5, 15)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (12, 4, 17)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (13, 1, 17)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (14, 1, 18)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (15, 2, 18)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (16, 1, 19)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (17, 2, 19)
INSERT [dbo].[generos_juegos] ([id_generos_juegos], [id_genero], [id_juego]) VALUES (18, 4, 20)
SET IDENTITY_INSERT [dbo].[generos_juegos] OFF
SET IDENTITY_INSERT [dbo].[juegos] ON 

INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (1, N'The witcher 3: Wild hunt', 1, CAST(11.99 AS Numeric(5, 2)), N'TheWitcherWildHuntCompleteEdition.jpg', N'https://www.youtube.com/embed/XHrskkHf958', N'CD PROJEKT RED', N'Mientras la guerra se extiende por los Reinos del Norte, aceptarás el contrato de tu vida: encontrar a la niña de la profecía, un arma viviente que puede alterar el mundo tal y como lo conocemos.', CAST(N'2015-05-19' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (3, N'Borderlands 3', 5, CAST(14.99 AS Numeric(5, 2)), N'Bordelands3.jpg', N'https://www.youtube.com/embed/d9Gu1PspA3Y', N'Gearbox Software', N'¡Vuelve el padre de los shooter-looter, con una aventura llena de caos y tropecientas mil armas! Arrasa a tus enemigos y descubre mundos inéditos con uno de los cuatro nuevos buscacámaras, los cazatesoros cabronazos más duros de Borderlands, que podrás personalizar y desarrollar a través de sus distintos árboles de habilidades. Juega solo o con amigos para derribar a adversarios increíbles, hacerte con montones de botín y salvar tu hogar de la secta más cruel de la galaxia.', CAST(N'2019-09-13' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (6, N'Final Fantasy VII Remake', 6, CAST(39.95 AS Numeric(5, 2)), N'FinalFantasyVIIRemake.jpg', N'https://www.youtube.com/embed/sz9QWTcbXYE', N'Square Enix', N'El mundo está controlado por la compañía Shinra, una corporación que genera energía mako a partir de la fuerza vital del planeta. En la ciudad de Midgar, el grupo anti-Shinra Avalancha decide tomar medidas drásticas. Cloud Strife, exmiembro de la unidad de élite de Shinra conocida como Soldado, ofrece sus servicios de mercenario a Avalancha, desconocedor de las aventuras que le esperan.', CAST(N'2020-04-10' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (7, N'Resident Evil 3 Remake', 1, CAST(39.95 AS Numeric(5, 2)), N'ResidentEvil3Remake.jpg', N'https://www.youtube.com/embed/xNjGFUaorYc', N'Capcom', N'Jill Valentine es una de las pocas personas que quedan en Raccoon City que han sido testigos de las atrocidades de Umbrella. Para detenerla, Umbrella decide usar su arma secreta definitiva: ¡Nemesis! También incluye Resident Evil Resistance, un nuevo modo multijugador online 1 contra 4.', CAST(N'2020-04-03' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (8, N'Animal Crossing New Horizons', 7, CAST(41.95 AS Numeric(5, 2)), N'AnimalCrossingNewHorizonsjpg.jpg', N'https://www.youtube.com/embed/_3YNL0OWio0', N'Nintendo', N'¡Más allá del horizonte te aguarda una nueva vida la mar de relajada! Desciende del avión y pon pie en tu propia isla desierta donde harás nuevos amigos y descubrimientos, y podrás disfrutar de mil oportunidades. ¡Crea un paraíso a tu medida en Animal Crossing: New Horizons para Nintendo Switch!', CAST(N'2020-03-20' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (9, N'Shadow of the tomb raider', 1, CAST(24.99 AS Numeric(5, 2)), N'ShadowOfTheTombRaider.jpg', N'https://www.youtube.com/embed/D1kTu2hacaI', N'Square Enix', N'La arqueóloga más famosa del mundo del videojuego suma este 2018 la tercera entrega de su saga ''reboot'' iniciada en 2013 y continuada en 2015 con Rise of the Tomb Raider (trilogía de la superviviente). Responde al nombre de Shadow of the Tomb Raider y supone el punto final a la historia de origen de Lara con un juego de acción y aventuras realmente notable y una Lara Croft más al límite que nunca.', CAST(N'2018-09-12' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (15, N'DOOM Eternal', 1, CAST(29.99 AS Numeric(5, 2)), N'DoomEternal.jpg', N'https://www.youtube.com/embed/F0tekG2XP_A', N'Bethesda', N'Los ejércitos del infierno han invadido la Tierra. Ponte en la piel del Slayer en una épica campaña para un jugador y cruza dimensiones para detener la destrucción definitiva de la humanidad. No le tienen miedo a nada... salvo a ti.', CAST(N'2020-03-20' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (17, N'Nioh 2', 6, CAST(39.95 AS Numeric(5, 2)), N'Nioh2.jpg', N'https://www.youtube.com/embed/ETWtvVGFNqU', N'Team ninja', N'Domina las técnicas samuráis en este brutal RPG de acción… porque la muerte se acerca.

Viaja al Japón de 1555, un país sumido en incesantes guerras, donde los monstruos y los espíritus malignos acechan en una tierra de bella naturaleza y peligros inquietantes.

Conviértete en un mercenario que persigue a sus enemigos con los poderes sobrenaturales de los míticos yokai.

¿Serás capaz de sobrevivir al traicionero periodo Sengoku y al nuevo y terrorífico Reino Oscuro?', CAST(N'2020-03-19' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (18, N'Red Dead Redemption 2', 5, CAST(35.32 AS Numeric(5, 2)), N'RedDeadRedemption2.jpg', N'https://www.youtube.com/embed/S3JmjnY2_Ks', N'Rockstar games', N'Tras un desastroso atraco fallido en la ciudad de Blackwater, Arthur Morgan y la banda de Van der Linde se ven obligados a huir. Con agentes federales y los mejores cazarrecompensas de la nación pisándoles los talones, la banda deberá atracar, robar y luchar, para sobrevivir en su camino por el escabroso territorio del corazón de América. Mientras las divisiones internas aumentan y amenazan con separarlos a todos, Arthur deberá elegir entre sus propios ideales y la lealtad a la banda que lo vio crecer.', CAST(N'2019-11-05' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (19, N'The Legend of Zelda: Breath of the wild', 7, CAST(59.99 AS Numeric(5, 2)), N'TheLegendOfZeldaBreathOfTheWild.jpg', N'https://www.youtube.com/embed/1rPxiXXxftE', N'Nintendo', N'El videojuego más grande en la historia de Nintendo, esta es la carta de presentación de The Legend of Zelda: Breath of the Wild para Wii U y Switch, una épica aventura que lleva la acción de esta veterana franquicia a un gigantesco mundo abierto que podemos explorar con total libertad. ¡No hay límites! Link puede coger un caballo, o cualquier otra montura, y explorar la nueva Hyrule siguiendo el orden que desee el jugador, pues la historia ya no sigue un camino lineal.', CAST(N'2017-03-03' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (20, N'NieR: Automata', 6, CAST(19.99 AS Numeric(5, 2)), N'NierAutomata.jpg', N'https://www.youtube.com/embed/p68k3U8WzRU', N'Square Enix', N'En un futuro distante, los invasores de otro mundo lanzan un ataque bajo una nueva amenaza: un arma mitad organismo vivo, mitad máquina. A la vista de este suceso, los humanos son conducidos a abandonar el planeta Tierra y buscar refugio en la Luna.
Tras los acontecimientos, el Consejo de la Humanidad organiza una resistencia formada por soldados androide en un esfuerzo por recuperar su planeta natal, desplegando una nueva unidad de infanteria llamada YoRHa.
La guerra entre humanos y máquinas se recrudece, una guerra que muy pronto revelerá la ya olvidada verdad sobre este mundo...', CAST(N'2017-03-10' AS Date))
SET IDENTITY_INSERT [dbo].[juegos] OFF
SET IDENTITY_INSERT [dbo].[plataformas] ON 

INSERT [dbo].[plataformas] ([id_plataforma], [nombre], [img_ruta]) VALUES (1, N'Steam', N'LogoSteam.png')
INSERT [dbo].[plataformas] ([id_plataforma], [nombre], [img_ruta]) VALUES (5, N'EpicGames', N'LogoEpicGames.png')
INSERT [dbo].[plataformas] ([id_plataforma], [nombre], [img_ruta]) VALUES (6, N'PlayStation 4', N'LogoPS4.png')
INSERT [dbo].[plataformas] ([id_plataforma], [nombre], [img_ruta]) VALUES (7, N'Nintendo Switch', N'LogoNintendoSwitch.png')
SET IDENTITY_INSERT [dbo].[plataformas] OFF
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena], [token]) VALUES (1, N'mari', N'ya funciona', N'asd@asd.com', N'aslan', NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena], [token]) VALUES (2, N'David', N'Martín', N'dmartin@ibadia.cat', N'asd', NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena], [token]) VALUES (3, N'juan', N'juanillo', N'juan123@asd.com', N'asdasd', NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena], [token]) VALUES (4, N'David', N'Tester', N'a@a.com', N'a', NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena], [token]) VALUES (5, N'Mari', N'Zoroa', N'mzoroa@ibadia.cat', N'gamesm20', NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena], [token]) VALUES (6, N'Hater', N'23', N'hater23@hotmail.com', N'game', NULL)
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena], [token]) VALUES (7, N'Comentarista', N'PC', N'comentarista@gmail.com', N'yey', NULL)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
SET IDENTITY_INSERT [dbo].[ventas] ON 

INSERT [dbo].[ventas] ([id_venta], [id_clave], [id_usuario], [fecha_venta], [tarj], [tarj_mes], [tarj_ano]) VALUES (4, 1, 4, CAST(N'2020-05-19' AS Date), N'1234567812345678', N'12', N'12')
SET IDENTITY_INSERT [dbo].[ventas] OFF
ALTER TABLE [dbo].[capturas]  WITH CHECK ADD  CONSTRAINT [FK_capturas_capturas] FOREIGN KEY([id_juego])
REFERENCES [dbo].[juegos] ([id_juego])
GO
ALTER TABLE [dbo].[capturas] CHECK CONSTRAINT [FK_capturas_capturas]
GO
ALTER TABLE [dbo].[claves]  WITH CHECK ADD  CONSTRAINT [FK_claves_juegos] FOREIGN KEY([id_juego])
REFERENCES [dbo].[juegos] ([id_juego])
GO
ALTER TABLE [dbo].[claves] CHECK CONSTRAINT [FK_claves_juegos]
GO
ALTER TABLE [dbo].[comentarios]  WITH CHECK ADD  CONSTRAINT [FK_comentarios_juegos] FOREIGN KEY([id_juego])
REFERENCES [dbo].[juegos] ([id_juego])
GO
ALTER TABLE [dbo].[comentarios] CHECK CONSTRAINT [FK_comentarios_juegos]
GO
ALTER TABLE [dbo].[comentarios]  WITH CHECK ADD  CONSTRAINT [FK_comentarios_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[comentarios] CHECK CONSTRAINT [FK_comentarios_usuarios]
GO
ALTER TABLE [dbo].[descuentos]  WITH CHECK ADD  CONSTRAINT [FK_descuentos_juegos] FOREIGN KEY([id_juego])
REFERENCES [dbo].[juegos] ([id_juego])
GO
ALTER TABLE [dbo].[descuentos] CHECK CONSTRAINT [FK_descuentos_juegos]
GO
ALTER TABLE [dbo].[deseados]  WITH CHECK ADD  CONSTRAINT [FK_deseados_juegos] FOREIGN KEY([id_juego])
REFERENCES [dbo].[juegos] ([id_juego])
GO
ALTER TABLE [dbo].[deseados] CHECK CONSTRAINT [FK_deseados_juegos]
GO
ALTER TABLE [dbo].[deseados]  WITH CHECK ADD  CONSTRAINT [FK_deseados_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[deseados] CHECK CONSTRAINT [FK_deseados_usuarios]
GO
ALTER TABLE [dbo].[generos_juegos]  WITH CHECK ADD  CONSTRAINT [FK_genero-juegos_juegos] FOREIGN KEY([id_juego])
REFERENCES [dbo].[juegos] ([id_juego])
GO
ALTER TABLE [dbo].[generos_juegos] CHECK CONSTRAINT [FK_genero-juegos_juegos]
GO
ALTER TABLE [dbo].[generos_juegos]  WITH CHECK ADD  CONSTRAINT [FK_generos-juegos_generos] FOREIGN KEY([id_genero])
REFERENCES [dbo].[generos] ([id_genero])
GO
ALTER TABLE [dbo].[generos_juegos] CHECK CONSTRAINT [FK_generos-juegos_generos]
GO
ALTER TABLE [dbo].[juegos]  WITH CHECK ADD  CONSTRAINT [FK_juegos_plataformas] FOREIGN KEY([id_plataforma])
REFERENCES [dbo].[plataformas] ([id_plataforma])
GO
ALTER TABLE [dbo].[juegos] CHECK CONSTRAINT [FK_juegos_plataformas]
GO
ALTER TABLE [dbo].[valoraciones]  WITH CHECK ADD  CONSTRAINT [FK_valoraciones_juegos] FOREIGN KEY([id_juego])
REFERENCES [dbo].[juegos] ([id_juego])
GO
ALTER TABLE [dbo].[valoraciones] CHECK CONSTRAINT [FK_valoraciones_juegos]
GO
ALTER TABLE [dbo].[valoraciones]  WITH CHECK ADD  CONSTRAINT [FK_valoraciones_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[valoraciones] CHECK CONSTRAINT [FK_valoraciones_usuarios]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_claves_ventas] FOREIGN KEY([id_clave])
REFERENCES [dbo].[claves] ([id_clave])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_claves_ventas]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_usuarios]
GO
USE [master]
GO
ALTER DATABASE [Games_Market] SET  READ_WRITE 
GO
