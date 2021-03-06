USE [ViaVarejo]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Amigos](
	[IdAmigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Local] [varchar](100) NOT NULL,
	[Latitude] [numeric](12, 8) NOT NULL,
	[Longitude] [numeric](12, 8) NOT NULL,
 CONSTRAINT [PK_IdAmigo] PRIMARY KEY CLUSTERED 
(
	[IdAmigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Latitude_Longitude] UNIQUE NONCLUSTERED 
(
	[Latitude] ASC,
	[Longitude] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Cache](
	[IdCache] [bigint] IDENTITY(1,1) NOT NULL,
	[IdAmigo] [int] NOT NULL,
	[IdDestino] [int] NOT NULL,
	[Distancia] [numeric](20, 8) NOT NULL,
 CONSTRAINT [PK_IdCache] PRIMARY KEY CLUSTERED 
(
	[IdCache] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_IdAmigo_IdDestino] UNIQUE NONCLUSTERED 
(
	[IdAmigo] ASC,
	[IdDestino] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Log](
	[IdCache] [bigint] NOT NULL,
	[RadianosLatitudeOrigem] [numeric](20, 8) NOT NULL,
	[RadianosLatitudeDestino] [numeric](20, 8) NOT NULL,
	[RadianosThetaLongitude] [numeric](20, 8) NOT NULL,
	[Seno] [numeric](20, 8) NOT NULL,
	[Coseno] [numeric](20, 8) NOT NULL,
	[Angulo] [numeric](20, 8) NOT NULL,
	[Milhas] [numeric](20, 8) NOT NULL,
	[Kilometros] [numeric](20, 8) NOT NULL,
 CONSTRAINT [PK_Log_IdCache] PRIMARY KEY CLUSTERED 
(
	[IdCache] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Cache]  WITH CHECK ADD  CONSTRAINT [FK_Historico_Amigos_IdAmigo] FOREIGN KEY([IdAmigo])
REFERENCES [dbo].[Amigos] ([IdAmigo])
GO

ALTER TABLE [dbo].[Cache] CHECK CONSTRAINT [FK_Historico_Amigos_IdAmigo]
GO

ALTER TABLE [dbo].[Cache]  WITH CHECK ADD  CONSTRAINT [FK_Historico_Amigos_IdDestino] FOREIGN KEY([IdDestino])
REFERENCES [dbo].[Amigos] ([IdAmigo])
GO

ALTER TABLE [dbo].[Cache] CHECK CONSTRAINT [FK_Historico_Amigos_IdDestino]
GO
]
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_Cache_IdCache] FOREIGN KEY([IdCache])
REFERENCES [dbo].[Cache] ([IdCache])
GO

ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_Cache_IdCache]
GO


SET ANSI_PADDING OFF
GO

SET IDENTITY_INSERT [dbo].[Amigos] ON
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (1, N'Marcelo', N'Nova York', CAST(40.66162840 AS Numeric(12, 8)), CAST(-74.05498200 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (2, N'Paulo', N'Montauk', CAST(41.03378650 AS Numeric(12, 8)), CAST(-72.08242110 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (3, N'Josh', N'Princeton', CAST(40.34556260 AS Numeric(12, 8)), CAST(-74.61154540 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (4, N'Audrey', N'Montreal', CAST(45.64088870 AS Numeric(12, 8)), CAST(-73.16964820 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (5, N'Jamal', N'Ottawa', CAST(45.64376910 AS Numeric(12, 8)), CAST(-75.28571800 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (6, N'Christine', N'Quebec', CAST(46.76787270 AS Numeric(12, 8)), CAST(-71.07313440 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (7, N'John', N'Toronto', CAST(43.80185750 AS Numeric(12, 8)), CAST(-79.15680050 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (8, N'Mathews', N'Greenwood', CAST(39.61753000 AS Numeric(12, 8)), CAST(-86.09537610 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (9, N'Javene', N'London', CAST(51.51479610 AS Numeric(12, 8)), CAST(-0.10525320 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (10, N'Morton', N'Kent', CAST(51.27567550 AS Numeric(12, 8)), CAST(1.10406300 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (11, N'Agatha', N'Bruxels', CAST(50.84819010 AS Numeric(12, 8)), CAST(4.36015050 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (12, N'Pierre', N'Paris', CAST(48.87774200 AS Numeric(12, 8)), CAST(2.39946190 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (13, N'Mariane', N'Cartagena', CAST(37.63543190 AS Numeric(12, 8)), CAST(-0.97890970 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (14, N'Joane', N'Gibraltar', CAST(36.14471890 AS Numeric(12, 8)), CAST(-5.34995600 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (15, N'Jacob', N'Seviglia', CAST(37.40585290 AS Numeric(12, 8)), CAST(-5.95745890 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (16, N'João', N'Porto', CAST(41.16951560 AS Numeric(12, 8)), CAST(-8.61346010 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (17, N'Mohamed', N'Oujda', CAST(34.68105660 AS Numeric(12, 8)), CAST(-1.90684130 AS Numeric(12, 8)))
INSERT [dbo].[Amigos] ([IdAmigo], [Nome], [Local], [Latitude], [Longitude]) VALUES (18, N'Cláudio', N'Guarujá', CAST(-23.99163950 AS Numeric(12, 8)), CAST(-46.26158290 AS Numeric(12, 8)))
SET IDENTITY_INSERT [dbo].[Amigos] OFF
GO
