CREATE TABLE [Issuers] (
  [Id] int,
  [FirstName] nvarchar,
  [LastName] datetime2,
  [Email] nvarchar,
  [PrhoneNumber] varchar(10),
  [Role] int,
  PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Roles] (
  [Id] int,
  [Rolename] nvarchar
)
GO

CREATE TABLE [Tickets] (
  [id] int,
  [issuerId] int,
  [description] nvarchar,
  [created_at] datetime2,
  [statusid] int,
  PRIMARY KEY ([id])
)
GO

CREATE TABLE [Comments] (
  [id] int,
  [ticketId] int,
  [comments] nvarchar,
  [created_at] datetime2,
  PRIMARY KEY ([id])
)
GO

CREATE TABLE [Tickets_status] (
  [id] int,
  [status] nvarchar,
  PRIMARY KEY ([id])
)
GO

ALTER TABLE [Issuers] ADD FOREIGN KEY ([Role]) REFERENCES [Roles] ([Id])
GO

ALTER TABLE [Tickets] ADD FOREIGN KEY ([issuerId]) REFERENCES [Issuers] ([Id])
GO

ALTER TABLE [Tickets_status] ADD FOREIGN KEY ([id]) REFERENCES [Tickets] ([statusid])
GO

ALTER TABLE [Comments] ADD FOREIGN KEY ([ticketId]) REFERENCES [Tickets] ([id])
GO
