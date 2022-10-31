# StoreAPI_.netcore
API using .net core 3 
consists of 2 main controllers -> products and categories controllers 
on Port :51005
supported end points :
-GET:api/products "Get all products"

-GET:api/products/{id} "Get product by ID"

-GET:api/products?categoryID={categoryId} "Get products for a specific Category id"

-GET: api/categories "Get all categories"

-POST: api/products "Add a new product"
    Sample data for Request Body:
    {"Name": "dress",
    "Price":450,
    "ImgURL":"",
    "CatID":"5b1c2b4d-48c7-402a-80c3-cc796ad49c6c"
    }
    
-PUT: api/products/{id} "Update existing Product by id"
    Sample data for Request Body:

    {
        "Name":"test132",
        "Price":100,
        "ImgURL":"http"
    }
PATCH: api/products/{id} "Partially update product"
          Sample data for Request Body:

      [
      {
      "op":"replace",
      "path":"/Name",
      "value":"test11"
      }
      ]


 
