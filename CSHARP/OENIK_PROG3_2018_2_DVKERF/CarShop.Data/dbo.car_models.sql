CREATE TABLE [dbo].[car_models] (
    [id]               INT          IDENTITY (1, 1) NOT NULL,
    [brand_id]         INT          NOT NULL,
    [name]             VARCHAR (20) NOT NULL,
    [production_start] DATE         NULL,
    [engine_size]      INT          NULL,
    [horsepower]       INT          NULL,
    [starting_price]   INT          NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([brand_id]) REFERENCES [dbo].[car_brands] ([id])
);

