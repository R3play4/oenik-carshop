# OENIK_PROG3_2018_2_DVKERF

## University Home Assignment. 

###### How to Try
Open the SLN via Visual Studio. Set CarShop.Console as Start Up project. The Java Endpoint would only work with Glassfish or other application server. 

###### Task description: 
Create an Appliation for a Car Shop. The application have to be able to exceute basic CRUD operations.
The application have to be organized into 3 layers. View, Logic and Repository.
The Logic layer had to be unit tested.
A Java endpoint had to be written. The endpoint randomly generates prices for a any given car. 
The end point runs on GlassFish application server. 
The application is documented via doxygen. 

###### Structure:
The application is organized into 3 layers. 
1 - View Layer.
	No Gui Technology was used.
	The App displays everything on the Console Window

2 - Logic Layer
	Perdifined business logic was implemented in this layer. 
	This layer was unit tested.
	
3 - Repository Layer
	This layer is responsible for the Database connection.
	Entityframwork was used for ORM.
	
Each layer can only communicate with the layer directly below it via an Interface.
Layers can only use events to communicate with layers above them.

###### Technologies: 
MSSQL, EntityFramework, NUnit, Moq


	

	
