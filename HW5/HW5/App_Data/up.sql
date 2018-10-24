﻿CREATE DATABASE CampusApartments
GO 

USE [CampusApartments]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TennantRequest] (
    [RequestID]           INT          IDENTITY (1, 1) NOT NULL,
    [Created]             DATETIME     NOT NULL,
    [FirstName]           VARCHAR (50) NOT NULL,
    [LastName]            VARCHAR (50) NOT NULL,
    [PhoneNumber]         VARCHAR (50) NOT NULL,
    [ApartmentName]       VARCHAR (50) NOT NULL,
    [UnitNumber]          INT          NOT NULL,
    [Comments]            VARCHAR (50) NOT NULL,
    [IsEntrancePermitted] BIT          NOT NULL
);

INSERT INTO [dbo].[TennantRequest] ([Created], [FirstName], [LastName], [PhoneNumber], [ApartmentName], [UnitNumber], [Comments], [IsEntrancePermitted]) 
VALUES (GETDATE(), 'Joseph', 'Reese', '434-466-5050', 'Cedar Hall', 12, 'Sink leaking', 1),
(GETDATE(), 'Richard', 'Anderson', '919-707-2434', 'Spruce Hall', 7, 'Refrigerator not working', 0),
(GETDATE(), 'David', 'Freeman', '915-678-5108', 'Ackerman Hall', 19, 'Can someone feed my dog?', 1),
(GETDATE(), 'Charlotte', 'Taylor', '978-915-8791', 'Noble Hall', 2, 'Dishwasher does not empty itself', 0),
(GETDATE(), 'Karen', 'Bruce', '517-828-2407', 'Butler Hall', 17, 'Washer broken', 0)