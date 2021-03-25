# BlogWebApi
Sample Web API for blog.

Operation include:

	1) Add a new Blog
	2) Edit a new Blog
	3) Delete a new Blog
	4) List all the Blog

Authentication for valid users can only access to above API endpoints.

Database script is included in Database folder.
Database design has been included in the Database folder as a .png file.

Improvement Area:

	1) Currently adding a new blog only adds a row to a single post table. On further increasing functionality we can add/fill other tables depending upon input.
	2) Currently a valid user in blog_user table will be able to access all the above API endpoint, which can be improved (extended) that only owner cacn update or delete the blog only.

To Test:
Use Authorization Header with Value as (base64encodedstring)

	1) Vaid User - cnN1a2hpamE6ZGRzc2Zha24xMTIyMTM0NDM=
	2) Invalid User - cnN1a2hpamE6ZGRzc2Zha24=
	
