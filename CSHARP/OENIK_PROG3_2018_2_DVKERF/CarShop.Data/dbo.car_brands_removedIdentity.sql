CREATE TABLE [dbo].[car_brands] (
    [id]             INT NOT NULL,
    [name]           VARCHAR (20)  NULL,
    [country]        VARCHAR (20)  NULL,
    [url]            VARCHAR (100) NULL,
    [founded]        DATE          NULL,
    [yearly_revenue] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

