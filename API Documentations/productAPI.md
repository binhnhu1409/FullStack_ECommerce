# PRODUCTS

- [Get all products](#getAllProducts)
- [Get single product](#getSingleProduct)
- [Create new product](#createProduct)
- [Update product](#updateProduct)
- [Delete product](#deleteProduct)

<a id="getAllProducts"></a>

## Get all products​

You can access the list of all users by using the `/products` endpoint

### Request:

    [GET] .../api/v1/products

### Response:

    [
      {
       "id": ,
       "name": "string",
       "price": 687,
       "description": "description...",

       // ...
       }
    ]
