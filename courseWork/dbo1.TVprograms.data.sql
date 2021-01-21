SET IDENTITY_INSERT [dbo].[TVprograms] ON
INSERT INTO [dbo].[TVprograms] ([Id], [Канал], [День], [Время], [Жанр], [Название], [Ограничение]) VALUES (1, N'Первый', N'Четверг', N'5:00', N'Досуг', N'Телеканал "Доброе утро"', N'6+')
INSERT INTO [dbo].[TVprograms] ([Id], [Канал], [День], [Время], [Жанр], [Название], [Ограничение]) VALUES (2, N'Первый', N'Четверг', N'9:00', N'Инфо', N'Новости', N'12+')
INSERT INTO [dbo].[TVprograms] ([Id], [Канал], [День], [Время], [Жанр], [Название], [Ограничение]) VALUES (640, N'2x2', N'Среда', N'03:55', N'Досуг', N'2X2 Music', N'16+')
INSERT INTO [dbo].[TVprograms] ([Id], [Канал], [День], [Время], [Жанр], [Название], [Ограничение]) VALUES (641, N'2x2', N'Среда', N'04:50', N'Мультфильм', N'Гиперактивный вандализм. 3-я серия', N'18+')
SET IDENTITY_INSERT [dbo].[TVprograms] OFF