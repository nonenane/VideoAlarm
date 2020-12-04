CREATE TABLE [CheckVideoReg].[s_VideoReg](
	[id]			int				IDENTITY(1,1) NOT NULL,
	[RegName]		varchar(max)	not null,
	[RegIP]			varchar(max)	not null,
	[Place]			varchar(max)	not null,
	[PathLog]		varchar(max)	not null,
	[Comment]		varchar(max)	null,
	[isActive]		bit				not null	default 1,
	[id_Editor]		int				null,
	[DateEdit]		datetime		null,
 CONSTRAINT [PK_s_VideoReg] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [CheckVideoReg].[s_VideoReg] ADD CONSTRAINT FK_s_VideoReg_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO


CREATE TABLE [CheckVideoReg].[s_Responsible](
	[id]			int				IDENTITY(1,1) NOT NULL,
	[id_kadr]		int				not null,
	[isActive]		bit				not null	default 1,
	[id_Editor]		int				null,
	[DateEdit]		datetime		null,
 CONSTRAINT [PK_s_Responsible] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [CheckVideoReg].[s_Responsible] ADD CONSTRAINT FK_s_Responsible_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [CheckVideoReg].[s_Responsible] ADD CONSTRAINT FK_s_Responsible_id_id_kadr FOREIGN KEY (id_kadr)  REFERENCES [dbo].s_kadr (id)
GO


CREATE TABLE [CheckVideoReg].[s_Camera_vs_Channel](
	[id]			int				IDENTITY(1,1) NOT NULL,
	[CamIP]			varchar(max)	not null,			
	[CamName] 		varchar(max)	not null,
	[RegChannel]	varchar(max)	not null,
	[id_VideoReg]	int				not null,
	[PathScan]		varchar(max)	not null,
	[Scan]			varbinary(max)	null,
	[Comment]		varchar(max)	null,
	[isActive]		bit				not null	default 1,
	[id_Editor]		int				null,
	[DateEdit]		datetime		null,
 CONSTRAINT [PK_s_Camera_vs_Channel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [CheckVideoReg].[s_Camera_vs_Channel] ADD CONSTRAINT FK_s_Camera_vs_Channel_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [CheckVideoReg].[s_Camera_vs_Channel] ADD CONSTRAINT FK_s_Camera_vs_Channel_id_VideoReg FOREIGN KEY (id_VideoReg)  REFERENCES [CheckVideoReg].[s_VideoReg] (id)
GO


CREATE TABLE [CheckVideoReg].[j_AlarmVideoReg](
	[id]					int				IDENTITY(1,1) NOT NULL,	
	[id_VideoReg]			int				not null,
	[id_Camera_vs_Channel]	int				not null,
	[TypeEvent]				varchar(max)	not null,
	[id_Responsible]		varchar(max)	not null,
	[DateStartAlarm]		datetime		not null,
	[DateEndAlarm]			datetime		null,
	[DateCreate]			datetime		not null,
	[Comment]				varchar(max)	null,	
 CONSTRAINT [PK_j_AlarmVideoReg] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [CheckVideoReg].[j_AlarmVideoReg] ADD CONSTRAINT FK_j_AlarmVideoReg_id_Camera_vs_Channel FOREIGN KEY (id_Camera_vs_Channel)  REFERENCES [CheckVideoReg].[s_Camera_vs_Channel] (id)
GO

ALTER TABLE [CheckVideoReg].[j_AlarmVideoReg] ADD CONSTRAINT FK_j_AlarmVideoReg_id_VideoReg FOREIGN KEY (id_VideoReg)  REFERENCES [CheckVideoReg].[s_VideoReg] (id)
GO


CREATE TABLE [CheckVideoReg].[j_tAlarmVideoReg](
	[id]					int				IDENTITY(1,1) NOT NULL,	
	[id_VideoReg]			int				not null,
	[DateCreate]			datetime		not null,
	[NameFile]				varchar(max)	not null,
	[id_Responsible]		varchar(max)	not null,
	[Delta]					int				not null,
	[isNoAlarm]				bit				not null default 1,
	[TypeEvent]				varchar(max)	not null,
	[Comment]				varchar(max)	null,	
 CONSTRAINT [PK_j_tAlarmVideoReg] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [CheckVideoReg].[j_tAlarmVideoReg] ADD CONSTRAINT FK_j_tAlarmVideoReg_id_VideoReg FOREIGN KEY (id_VideoReg)  REFERENCES [CheckVideoReg].[s_VideoReg] (id)
GO



CREATE TABLE [CheckVideoReg].[s_Schedule](
	[id]			int				IDENTITY(1,1) NOT NULL,	
	[TimeRun]		time			not null,
	[isOn]			bit				not null default 0,
	[id_Editor]		int				null,
	[DateEdit]		datetime		null,
 CONSTRAINT [PK_s_Schedule] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [CheckVideoReg].[s_Schedule] ADD CONSTRAINT FK_s_Schedule_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO
