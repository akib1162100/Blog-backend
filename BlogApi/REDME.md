# Blogger Backend API

[TOC]

## Content Negotiation

Support `JSON` and `XML` serialization and deserialization.





## DTO Models

### Blog DTO

This model is used to transfer a `Post` object from client to server and validate the object on required criteria.

* **Id** : int
* **Title** : string
* **Body** : string
* **PublishedDate** : Date-Time





## Response Status

| Status Code               | Reason                                                       |
| ------------------------- | ------------------------------------------------------------ |
| 200 OK                    | Successful `GET` ,`PUT`, `DELETE` request                    |
| 201 Created               | Success `POST` request                                       |
| 400 Bad Request           | Validation requirements or formation error                   |
| 404 Not Found             | If requested result not found by the system                  |
| 405 Method Not Allowed    | If requested method doesn't support by the endpoint          |
| 406 Not Acceptable        | If requested form (`Content-Type` and `Accept`) doesn't support by the system. See **Content Negotiation** |
| 500 Internal Server Error | Whenever server is failed to execute or finish a task.       |







## Endpoints

### Blog Posts



#### `POST` `/api/blog`

This endpoint is for create a new blog post.  Request body or data support `JSON` and `XML` formation defined in `Content-Type` header. For invalid body (syntax and format) server will return `400 Bad Request` with error message. Otherwise `201 Created` response will be served in required format.



**Body**

* Title : String  | *max length=200*
* Body : String |  *allowed empty string*
* PublishedDate: DateTime |  *format: 2020 02-27T07:15:27.395Z*



**Note**

*`PostDto` object has `Id` parameter which will be generated automatically by the system when requested to create new a post. If client side sent `Id` this will be ignored by the system*



**Request Format**

* JSON Request

```JSON
{
  "title": "string",
  "body": "string",
  "publishedDate": "2020-02-26T11:27:37.982Z"
}
```

* XML Request

```xml
<?xml version="1.0" encoding="UTF-8"?>
<BlogDTO>
	<Title>string</Title>
	<Body>string</Body>
	<PublishedDate>2020-02-26T11:28:37.660Z</PublishedDate>
</BlogDTO>
```



**Response Format**

* JSON Response

```JSON
{
    "id": 11,
    "title": "string",
    "body": "string",
    "publishedDate": "2020-02-27T00:00:00"
}
```

* XML Response

```XML
<BlogDTO xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Id>10</Id>
    <Title>string</Title>
    <Body>string</Body>
    <PublishedDate>2020-02-26T11:28:37.66Z</PublishedDate>
</BlogDTO>
```





#### `GET` `/api/blog`

This endpoint is for get all available posts in database. If no post available in database then an empty array will return otherwise an array with available items. 



**Response**

* XML Response

```xml
<ArrayOfBlogDTO xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <BlogDTO>
        <Id>1</Id>
        <Title>yes</Title>
        <Body>My sad story</Body>
        <PublishedDate>2020-02-27T00:00:00</PublishedDate>
    </BlogDTO>
    <BlogDTO>
        <Id>2</Id>
        <Title>no</Title>
        <Body>My sad story</Body>
        <PublishedDate>2020-02-27T00:00:00</PublishedDate>
    </BlogDTO>
    <BlogDTO>
        <Id>3</Id>
        <Title>no</Title>
        <Body>My sad story?</Body>
        <PublishedDate>2020-02-27T00:00:00</PublishedDate>
    </BlogDTO>

    <BlogDTO>
        <Id>11</Id>
        <Title>string</Title>
        <Body>string</Body>
        <PublishedDate>2020-02-27T00:00:00</PublishedDate>
    </BlogDTO>
</ArrayOfBlogDTO>
```
* JSON Response

```json
[
    {
        "id": 1,
        "title": "yes",
        "body": "My sad story",
        "publishedDate": "2020-02-27T00:00:00"
    },
    {
        "id": 2,
        "title": "no",
        "body": "My sad story",
        "publishedDate": "2020-02-27T00:00:00"
    },
    {
        "id": 3,
        "title": "no",
        "body": "My sad story?",
        "publishedDate": "2020-02-27T00:00:00"
    },
    {
        "id": 4,
        "title": "no",
        "body": "My sad story? really dont know! ",
        "publishedDate": "2020-02-27T00:00:00"
    },
    {
        "id": 11,
        "title": "string",
        "body": "string",
        "publishedDate": "2020-02-27T00:00:00"
    }
]
```





#### `PUT` `/api/blog`

To update an existing post.



**Required Body**

* Id :int 
* Title : String  | *max length=200*
* Body : String |  *allowed empty string*
* PublishedDate: DateTime |  *format: 2020 02-27T07:15:27.395Z*



**Request**

* JSON

```json
{
	"id":7,
	"title":"no 6",
	"body":"",
	"publishedDate":"2020-02-27"
}
```

* XML

```xml
<?xml version="1.0" encoding="UTF-8"?>
<BlogDTO>
    <Id>11</Id>
	<Title>string</Title>
	<Body>string</Body>
	<PublishedDate>2020-02-26T11:28:37.660Z</PublishedDate>
</BlogDTO>
```



**Response**

* Has no Body 




#### `GET` `/api/blog/{id}`

To fetch a particular post object. This endpoint take an `Id` as parameter and return the associated `Post` object.



**Required Parameter**

* Id : int

**Response**

* JSON Response

```json
{
    "id": 7,
    "title": "no 33",
    "body": "",
    "publishedDate": "2020-02-27T00:00:00"
}
```

* XML Response

```xml
<BlogDTO xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Id>7</Id>
    <Title>no 33</Title>
    <Body />
    <PublishedDate>2020-02-27T00:00:00</PublishedDate>
</BlogDTO>
```





#### `DELETE` `/api/blog/{id}`

To delete a particular post object. This endpoint take an `Id` as parameter and return the associated `Post` object after deletion.



**Required Parameter**

* Id : int



**Response**

* No Response Body
