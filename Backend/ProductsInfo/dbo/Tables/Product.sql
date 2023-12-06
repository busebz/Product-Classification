CREATE TABLE [dbo].[Product] (
    [product_id]    INT           IDENTITY (1, 1) NOT NULL,
    [progress_type] VARCHAR (255) NOT NULL,
    [type]          VARCHAR (255) NULL,
    [min_value]     INT           NULL,
    [max_value]     INT           NULL,
    [coefficient]   INT           NULL
);

