SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[blog_user] (
	id [uniqueidentifier] not null,
	firstName nvarchar(50) not null,
	middleName nvarchar(50) null default null,
	lastName nvarchar(50) null default null,
	userName nvarchar(50) unique not null,
	mobileNumber nvarchar(20) null default null,
	emailId nvarchar(50) null default null,
	passwordHash nvarchar(100) not null,
	registeredAt datetime not null,
	lastLogin datetime null default null,
	profileSummary ntext null default null,
	CONSTRAINT PK_user_id PRIMARY KEY CLUSTERED 
	( 
		id asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[post] (
	id uniqueidentifier not null,
	authorId uniqueidentifier not null,
	parentId uniqueidentifier null default null,
	title nvarchar(150) not null,
	metaTitle nvarchar(150) null default null,
	slug nvarchar(150) not null,
	isPublished bit not null default 0,
	createdAt datetime not null,
	updatedAt datetime not null,
	publishedAt datetime null default null,
	content ntext null default null,
	CONSTRAINT PK_post_id PRIMARY KEY CLUSTERED 
	( 
		id asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
	CONSTRAINT FK_post_authorid_user_id FOREIGN KEY (authorId) 
	REFERENCES [dbo].[blog_user] (id)
	ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
GO

CREATE TABLE [dbo].[category] (
	id uniqueidentifier not null,
	categoryTitle nvarchar(150) not null,
	metaTitle nvarchar(150) null default null,
	slug nvarchar(150) not null,
	isPublished bit not null default 0,
	createdAt datetime not null,
	updatedAt datetime not null,
	publishedAt datetime null default null,
	content ntext null default null,
	CONSTRAINT PK_category_id PRIMARY KEY CLUSTERED 
	( 
		id asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[tags] (
	id uniqueidentifier not null,
	tagTitle nvarchar(150) not null,
	metaTitle nvarchar(150) null default null,
	slug nvarchar(150) not null,
	isPublished bit not null default 0,
	createdAt datetime not null,
	updatedAt datetime not null,
	publishedAt datetime null default null,
	CONSTRAINT PK_tag_id PRIMARY KEY CLUSTERED 
	( 
		id asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[comment] (
	id uniqueidentifier not null,
	postId uniqueidentifier not null,
	parentId uniqueidentifier null default null,
	title nvarchar(150) not null,
	isPublished bit not null default 0,
	createdAt datetime not null,
	updatedAt datetime not null,
	content ntext null default null,
	CONSTRAINT PK_comment_id PRIMARY KEY CLUSTERED 
	( 
		id asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
	CONSTRAINT FK_comment_postid_post_id FOREIGN KEY (postId) 
	REFERENCES [dbo].[post] (id)
	ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
GO

CREATE TABLE [dbo].[post_category] (
	id uniqueidentifier not null,
	postId uniqueidentifier not null,
	categoryId uniqueidentifier not null,
	createdAt datetime not null,
	updatedAt datetime not null,
	CONSTRAINT PK_postcategory_id PRIMARY KEY CLUSTERED 
	( 
		id asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
	CONSTRAINT FK_postcategory_id_post_id FOREIGN KEY (postId) 
	REFERENCES [dbo].[post] (id)
	ON DELETE NO ACTION
    ON UPDATE NO ACTION,

	CONSTRAINT FK_postcategory_id_category_id FOREIGN KEY (categoryId) 
	REFERENCES [dbo].[category] (id)
	ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
GO

CREATE TABLE [dbo].[post_tag] (
	id uniqueidentifier not null,
	postId uniqueidentifier not null,
	tagId uniqueidentifier not null,
	createdAt datetime not null,
	updatedAt datetime not null,
	CONSTRAINT PK_posttag_id PRIMARY KEY CLUSTERED 
	( 
		id asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
	CONSTRAINT FK_posttag_id_post_id FOREIGN KEY (postId) 
	REFERENCES [dbo].[post] (id)
	ON DELETE NO ACTION
    ON UPDATE NO ACTION,

	CONSTRAINT FK_posttag_id_tag_id FOREIGN KEY (tagId) 
	REFERENCES [dbo].[tags] (id)
	ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
GO

INSERT INTO blog_user (id, firstName, middleName, lastName, userName, mobileNumber, emailId, passwordHash, registeredAt, lastLogin, profileSummary)
VALUES 
(
	newid(), 'Rohit', null, 'Sukhija', 'rsukhija', '9877699543', 'rohit.sukhija@gmail.com', 'ddssfakn112213443', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Good Profile' 
)


INSERT INTO post(id, authorId, parentId, title, metaTitle, slug, isPublished, createdAt, updatedAt, publishedAt, content)
VALUES 
(
	newid(), 'A30CCEE7-C3FB-4314-831F-05663582CB73', null, 'My First Blog Post', '-By RohitS', 'my_first_blog_post', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Content to look for!!'
)
INSERT INTO post(id, authorId, parentId, title, metaTitle, slug, isPublished, createdAt, updatedAt, publishedAt, content)
VALUES 
(
	newid(), 'A30CCEE7-C3FB-4314-831F-05663582CB73', null, 'This is my Blog', '-By Raj', 'another_blog_post', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Great Content!!'
)

