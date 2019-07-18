This REST API is Based on .Net Core 2.2 (SDK 2.2)

API consist of two Controllers, Fabrics and Inventory.

API uses Swagger for documentation.

Fabrics:
	GET:	//api/fabrics		=> Get List of Fabrics
	GET:	//api/fabrics/1		=> Get a single Fabric by ID
	POST:	//api/fabrics		=> Add New fabric
	PUT:	//api/fabrics		=> Update fabric objects
	DELETE: //api/fabrics		=> Delete fabrics
	PATCH:  //api/fabrics		=> Delta updates to fabrics objects. I am using JsonPatch library to acomplhish dynamic PATCH.

Inventory:
	GET:	//api/fabrics/lowinventory		=> Get inventory levels for reordering (Purchase)
	POST:	//api/fabrics/purchase			=> Post POs based on the inventory levels, it will update Inventory systems
	POS:	//api/fabrics/salesorder		=> post SO, any sales against inventory levels

**NOTE you can use Swagger document manager as UI for testing.