

<div style:"border: 1px solid black">
  <h2>GETs</h2>

<h3><b>View all people in the database, retrieves name and id</b></h3>

<h4><b>GET endpoint:</b> /person/all</h4>

example output:
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

<h3><b>View all interests for a specific id</b></h3>

<h4><b>GET endpoint:</b> /person/{id}/interests</h4>

Output:
```
 [
	{
		"interestName": "Skiing",
		"description": "Go down a hill real fast"
	},
	{
		"interestName": "Cooking",
		"description": "Making delicious food"
	}
]
```

<h3><b>View all links for a specific id</b></h3>

<h4><b>GET endpoint:</b> /person/{id}/links</h4>

Output:
```
 [
	{
		"url": "www.freeskier.com"
	},
	{
		"url": "godare.se"
	}
]
```

<h2>POSTs</h2>

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
##### Post endpoint: /person/{id}/interest
&nbsp; Input example:
```
{
  "interestName": "Skiing",
  "interestDescription": "Go down a hill real fast"
}
```
&nbsp; **Adds a website link related to the interest, and connects the link to a person**
##### Post endpoint: /person/{id}/interest/{id}/interestlink
&nbsp; Input example:
```
{
  "url": "www.freeskier.com"
}
```
&nbsp; **Links an existing person to an existing interest**
##### Post endpoint: /person/{id}/interest/{id}/
&nbsp; No input or output:




