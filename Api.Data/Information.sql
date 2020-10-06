USE [KalmyDBDev]
GO

INSERT INTO [dbo].[Car]
           ([CreatedAt]
           ,[ModifiedAt]
           ,[Type]
           ,[Brand]
           ,[Model]
           ,[CreationUser]
           ,[ModificationUser])
     VALUES
           (getdate()
           ,getdate()
           ,'small'
           ,'nissan'
           ,2019
           ,-1
           ,-1)

INSERT INTO [dbo].[Car]
           ([CreatedAt]
           ,[ModifiedAt]
           ,[Type]
           ,[Brand]
           ,[Model]
           ,[CreationUser]
           ,[ModificationUser])
     VALUES
           (getdate()
           ,getdate()
           ,'small'
           ,'nissan'
           ,2020
           ,-1
           ,-1)

INSERT INTO [dbo].[Car]
           ([CreatedAt]
           ,[ModifiedAt]
           ,[Type]
           ,[Brand]
           ,[Model]
           ,[CreationUser]
           ,[ModificationUser])
     VALUES
           (getdate()
           ,getdate()
           ,'medium'
           ,'toyota'
           ,2018
           ,-1
           ,-1)

INSERT INTO [dbo].[Car]
           ([CreatedAt]
           ,[ModifiedAt]
           ,[Type]
           ,[Brand]
           ,[Model]
           ,[CreationUser]
           ,[ModificationUser])
     VALUES
           (getdate()
           ,getdate()
           ,'medium'
           ,'tesla'
           ,2020
           ,-1
           ,-1)

INSERT INTO [dbo].[Car]
           ([CreatedAt]
           ,[ModifiedAt]
           ,[Type]
           ,[Brand]
           ,[Model]
           ,[CreationUser]
           ,[ModificationUser])
     VALUES
           (getdate()
           ,getdate()
           ,'medium'
           ,'kia'
           ,2017
           ,-1
           ,-1)

INSERT INTO [dbo].[Car]
           ([CreatedAt]
           ,[ModifiedAt]
           ,[Type]
           ,[Brand]
           ,[Model]
           ,[CreationUser]
           ,[ModificationUser])
     VALUES
           (getdate()
           ,getdate()
           ,'big'
           ,'kia'
           ,2020
           ,-1
           ,-1)

INSERT INTO [dbo].[Car]
           ([CreatedAt]
           ,[ModifiedAt]
           ,[Type]
           ,[Brand]
           ,[Model]
           ,[CreationUser]
           ,[ModificationUser])
     VALUES
           (getdate()
           ,getdate()
           ,'big'
           ,'tesla'
           ,2019
           ,-1
           ,-1)


GO
