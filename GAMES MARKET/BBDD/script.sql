USE [master]
GO
/****** Object:  Database [Games_Market]    Script Date: 08/05/2020 19:28:43 ******/
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
/****** Object:  Table [dbo].[capturas]    Script Date: 08/05/2020 19:28:43 ******/
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
/****** Object:  Table [dbo].[claves]    Script Date: 08/05/2020 19:28:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[claves](
	[id_clave] [int] NOT NULL,
	[id_juego] [int] NOT NULL,
	[codigo] [nvarchar](max) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_claves_1] PRIMARY KEY CLUSTERED 
(
	[id_clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comentarios]    Script Date: 08/05/2020 19:28:43 ******/
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
/****** Object:  Table [dbo].[descuentos]    Script Date: 08/05/2020 19:28:43 ******/
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
/****** Object:  Table [dbo].[deseados]    Script Date: 08/05/2020 19:28:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deseados](
	[id_juego] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_deseados] PRIMARY KEY CLUSTERED 
(
	[id_juego] ASC,
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[generos]    Script Date: 08/05/2020 19:28:43 ******/
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
/****** Object:  Table [dbo].[generos-juegos]    Script Date: 08/05/2020 19:28:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[generos-juegos](
	[id_genero] [int] NOT NULL,
	[id_juego] [int] NOT NULL,
 CONSTRAINT [PK_genero-juegos] PRIMARY KEY CLUSTERED 
(
	[id_genero] ASC,
	[id_juego] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[juegos]    Script Date: 08/05/2020 19:28:43 ******/
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
/****** Object:  Table [dbo].[plataformas]    Script Date: 08/05/2020 19:28:43 ******/
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
/****** Object:  Table [dbo].[usuarios]    Script Date: 08/05/2020 19:28:43 ******/
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
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[valoraciones]    Script Date: 08/05/2020 19:28:43 ******/
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
/****** Object:  Table [dbo].[ventas]    Script Date: 08/05/2020 19:28:43 ******/
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
	[cod_seg] [nvarchar](max) NOT NULL,
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
SET IDENTITY_INSERT [dbo].[capturas] OFF
SET IDENTITY_INSERT [dbo].[descuentos] ON 

INSERT [dbo].[descuentos] ([id_descuento], [id_juego], [descuento], [inicio], [fin], [img_ruta]) VALUES (2, 6, 20, CAST(N'2020-05-01' AS Date), CAST(N'2020-06-30' AS Date), N'FinalFantasyVIIRemake.jpg')
INSERT [dbo].[descuentos] ([id_descuento], [id_juego], [descuento], [inicio], [fin], [img_ruta]) VALUES (3, 8, 5, CAST(N'2020-05-01' AS Date), CAST(N'2020-06-30' AS Date), N'AnimalCrossingNewHorizonsjpg.jpg')
SET IDENTITY_INSERT [dbo].[descuentos] OFF
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
INSERT [dbo].[generos-juegos] ([id_genero], [id_juego]) VALUES (1, 9)
INSERT [dbo].[generos-juegos] ([id_genero], [id_juego]) VALUES (2, 1)
INSERT [dbo].[generos-juegos] ([id_genero], [id_juego]) VALUES (2, 8)
INSERT [dbo].[generos-juegos] ([id_genero], [id_juego]) VALUES (2, 9)
INSERT [dbo].[generos-juegos] ([id_genero], [id_juego]) VALUES (4, 6)
INSERT [dbo].[generos-juegos] ([id_genero], [id_juego]) VALUES (5, 3)
INSERT [dbo].[generos-juegos] ([id_genero], [id_juego]) VALUES (10, 9)
SET IDENTITY_INSERT [dbo].[juegos] ON 

INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (1, N'The witcher 3: Wild hunt', 1, CAST(11.99 AS Numeric(5, 2)), N'TheWitcherWildHuntCompleteEdition.jpg', N'https://www.youtube.com/embed/XHrskkHf958', N'CD PROJEKT RED', N'Mientras la guerra se extiende por los Reinos del Norte, aceptarás el contrato de tu vida: encontrar a la niña de la profecía, un arma viviente que puede alterar el mundo tal y como lo conocemos.', CAST(N'2015-05-19' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (3, N'Bordelands 3', 5, CAST(14.99 AS Numeric(5, 2)), N'Bordelands3.jpg', N'https://www.youtube.com/embed/d9Gu1PspA3Y', N'Gearbox Software', N'¡Vuelve el padre de los shooter-looter, con una aventura llena de caos y tropecientas mil armas! Arrasa a tus enemigos y descubre mundos inéditos con uno de los cuatro nuevos buscacámaras, los cazatesoros cabronazos más duros de Borderlands, que podrás personalizar y desarrollar a través de sus distintos árboles de habilidades. Juega solo o con amigos para derribar a adversarios increíbles, hacerte con montones de botín y salvar tu hogar de la secta más cruel de la galaxia.', CAST(N'2019-09-13' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (6, N'Final Fantasy VII Remake', 6, CAST(39.95 AS Numeric(5, 2)), N'FinalFantasyVIIRemake.jpg', N'https://www.youtube.com/embed/sz9QWTcbXYE', N'Square Enix', N'El mundo está controlado por la compañía Shinra, una corporación que genera energía mako a partir de la fuerza vital del planeta. En la ciudad de Midgar, el grupo anti-Shinra Avalancha decide tomar medidas drásticas. Cloud Strife, exmiembro de la unidad de élite de Shinra conocida como Soldado, ofrece sus servicios de mercenario a Avalancha, desconocedor de las aventuras que le esperan.', CAST(N'2020-04-10' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (7, N'Resident Evil 3 Remake', 1, CAST(39.95 AS Numeric(5, 2)), N'ResidentEvil3Remake.jpg', N'https://www.youtube.com/embed/xNjGFUaorYc', N'Capcom', N'Jill Valentine es una de las pocas personas que quedan en Raccoon City que han sido testigos de las atrocidades de Umbrella. Para detenerla, Umbrella decide usar su arma secreta definitiva: ¡Nemesis! También incluye Resident Evil Resistance, un nuevo modo multijugador online 1 contra 4.', CAST(N'2020-04-03' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (8, N'Animal Crossing New Horizons', 7, CAST(41.95 AS Numeric(5, 2)), N'AnimalCrossingNewHorizonsjpg.jpg', N'https://www.youtube.com/embed/_3YNL0OWio0', N'Nintendo', N'¡Más allá del horizonte te aguarda una nueva vida la mar de relajada! Desciende del avión y pon pie en tu propia isla desierta donde harás nuevos amigos y descubrimientos, y podrás disfrutar de mil oportunidades. ¡Crea un paraíso a tu medida en Animal Crossing: New Horizons para Nintendo Switch!', CAST(N'2020-03-20' AS Date))
INSERT [dbo].[juegos] ([id_juego], [nombre], [id_plataforma], [precio], [img_ruta], [trailer_url], [distribuidora], [descripcion], [fecha_lanzamiento]) VALUES (9, N'Shadow of the tomb raider', 1, CAST(25.99 AS Numeric(5, 2)), N'ShadowOfTheTombRaider.jpg', N'https://www.youtube.com/embed/D1kTu2hacaI', N'Square Enix', N'La arqueóloga más famosa del mundo del videojuego suma este 2018 la tercera entrega de su saga ''reboot'' iniciada en 2013 y continuada en 2015 con Rise of the Tomb Raider (trilogía de la superviviente). Responde al nombre de Shadow of the Tomb Raider y supone el punto final a la historia de origen de Lara con un juego de acción y aventuras realmente notable y una Lara Croft más al límite que nunca.', CAST(N'2018-09-12' AS Date))
SET IDENTITY_INSERT [dbo].[juegos] OFF
SET IDENTITY_INSERT [dbo].[plataformas] ON 

INSERT [dbo].[plataformas] ([id_plataforma], [nombre], [img_ruta]) VALUES (1, N'Steam', N'LogoSteam.png')
INSERT [dbo].[plataformas] ([id_plataforma], [nombre], [img_ruta]) VALUES (5, N'EpicGames', N'LogoEpicGames.png')
INSERT [dbo].[plataformas] ([id_plataforma], [nombre], [img_ruta]) VALUES (6, N'PlayStation 4', N'LogoPS4.png')
INSERT [dbo].[plataformas] ([id_plataforma], [nombre], [img_ruta]) VALUES (7, N'Nintendo Switch', N'LogoNintendoSwitch.png')
SET IDENTITY_INSERT [dbo].[plataformas] OFF
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena]) VALUES (1, N'mari', N'ya funciona', N'asd@asd.com', N'aslan')
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena]) VALUES (2, N'david', N'asdasd', N'david@hotmail.com', N'david')
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena]) VALUES (3, N'juan', N'juanillo', N'juan123@asd.com', N'asdasd')
INSERT [dbo].[usuarios] ([id_usuario], [nombre], [apellidos], [email], [contrasena]) VALUES (4, N'David', N'Tester', N'a@a.com', N'a')
SET IDENTITY_INSERT [dbo].[usuarios] OFF
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
ALTER TABLE [dbo].[generos-juegos]  WITH CHECK ADD  CONSTRAINT [FK_genero-juegos_juegos] FOREIGN KEY([id_juego])
REFERENCES [dbo].[juegos] ([id_juego])
GO
ALTER TABLE [dbo].[generos-juegos] CHECK CONSTRAINT [FK_genero-juegos_juegos]
GO
ALTER TABLE [dbo].[generos-juegos]  WITH CHECK ADD  CONSTRAINT [FK_generos-juegos_generos] FOREIGN KEY([id_genero])
REFERENCES [dbo].[generos] ([id_genero])
GO
ALTER TABLE [dbo].[generos-juegos] CHECK CONSTRAINT [FK_generos-juegos_generos]
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
