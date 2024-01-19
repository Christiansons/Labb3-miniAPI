### **Gets**
&nbsp; **View all information about a person based on ID**
##### Get endpoint: /person/1
&nbsp; Output:
```
{
  "id": 1,
  "name": "Alex",
  "phoneNr": 739309362,
  "interests": [
    {
      "name": "Skiing",
      "description": "Go down a hill real fast"
    }
  ],
  "interestLinks": [
    {
      "url": "www.freeskier.com"
    }
  ]
}
```
&nbsp; **View all people in the database, retrieves name and id**
##### Get endpoint: /person/all
&nbsp; Output:
```
 {
   "id": 1,
   "name": "Alex"
 },
 {
   "id": 2,
   "name": "norton"
 }
```
### **Posts**
&nbsp; **Creates a new person to the database**
##### Post endpoint: /person
&nbsp; Input example:
```
{
  "name": "Alex",
  "phoneNr": "070120120"
}
```
&nbsp; **Adds a new interest to an existing person**
##### Post endpoint: /person/1/interest
&nbsp; Input example:
```
{
  "interestName": "Skiing",
  "interestDescription": "Go down a hill real fast"
}
```
&nbsp; **Adds a website link related to the interest**
##### Post endpoint: /person/1/interest/1/interestlink
&nbsp; Input example:
```
{
  "url": "www.freeskier.com"
}
```
&nbsp; **Links an existing person to an existing interest**
##### Post endpoint: /person/2/interest/1/
&nbsp; No input or output:




