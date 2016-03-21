USE [Gamefication]
GO

INSERT INTO [dbo].[Ranks]
           ([title]
           ,[Images]
           ,[points]
           ,[note])
     VALUES
           ('Junior'
           ,''
           ,0
           ,'test rank')

INSERT INTO [dbo].[Levels]
           ([title]
           ,[rank]
           ,[points])
     VALUES
           ('One lvl'
           ,1
           ,0)
GO


