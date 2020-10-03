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
           ,null)


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
           ,'nissan'
           ,2020
           ,-1
           ,null)

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
           ,2018
           ,-1
           ,null)

GO



--● Type: {small, medium, big} Define como la proporción o el tamaño, y solo tiene esos tres
--posibles valores.
--● Brand: string. Ejemplo: Honda, Toyota
--● Model: string. Año del auto: 2020, etc
