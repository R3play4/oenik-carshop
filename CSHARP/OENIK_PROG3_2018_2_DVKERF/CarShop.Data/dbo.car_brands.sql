CREATE TABLE [dbo].[car_brands] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [name]           VARCHAR (20)  NOT NULL,
    [country]        VARCHAR (20)  NOT NULL,
    [url]            VARCHAR (100) NULL,
    [founded]        DATE          NULL,
    [yearly_revenue] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

