
# Requirements
* [Visual Studio 2017 with Update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes)
* [.NET SDK 2.0](https://www.microsoft.com/net/download/core)
* [Docker](https://docs.docker.com/docker-for-windows/install/)

# Architectural 
![Flow of Control: Customer Registration](https://raw.githubusercontent.com/ivanpaulovich/acerola/master/docs/hexagonal-arhcitecture-alistair-cockburn.gif)

Allow an application to equally be driven by users, programs, automated test or batch scripts, and to be developed and tested
in isolation from its eventual run-time devices and databases.

As events arrive from the outside world at a port, a technology-specific adapter converts it into a
usable procedure call and passes it to the application. The application is blissfully ignorant of the 
nature of the input device. When the application has something to send out, it sends it out through a port to an adapter, 
which creates the appropriate signals needed by the receiving technology (human or automated). The application has a semantically 
sound interaction with the adapters on all sides of it, without actually knowing the nature of the
things on the other side of the adapters. 
Check out [Alistair Cockburn blog post.](http://alistair.cockburn.us/Hexagonal+architecture)


## SOLID
The SOLID principles are all over the the solution. Knwoleadge of SOLID is not a prerequisite to understand and run the solution but it is highly recommended.

## Microservice
Even though the definition of microservice may be different for different professionals. We have tried to value some aspects like Continous Delivery, modelled around Business Domain and Independent Deployment.


## Mongo DB
Mongo DB is a detail. At infrastructure layer we implemented the Repository to update the Mongo database.

## .NET Core 2.0
.NET Core is a detail. Almost everything in this code base could be ported to older versions.


## Designer patterns 

 - Design Pattern Repository
 - Design Pattern Factory   

## Instructions

docker-compose build

docker-compose up 

docker ps -a


## Contracts & Book Api


# POST / RECEIVER
```javascript
{
    "TransactionAuthorize": {
        "Gateway": {
            "Billing": {
                "Address": "Av. Federativa, 230",
                "Address2": "10 Andar",
                "City": "Mogi das Cruzes",
                "Country": "BR",
                "CustomerIdentity": "1",
                "Email": "wan@email.com",
                "Name": "",
                "Phone": "1147770000",
                "PostalCode": "20031170",
                "State": "SP"
            },
            "Payment": {
                "Acquirer": "cielo",
                "Amount": "9933",
                "CardExpirationDate": "201805",
                "CardHolder": "Jose da Silva",
                "CardNumber": "5453010000066167",
                "CardSecurityCode": "123",
                "NumberOfPayments": "1"
            }
        },
        "Verification": {
            "merchantId": "0001"
        }
    }
}

```

# RESPONSE
```javascript
{
        "transactionResponse": {
            "message": "AUTHORIZED",
            "order": {
                "tid": "e2b16cc6-2d69-48e9-8182-7af8db13c9aa",
                "dateTime": "2018-02-19T21:46:40.894962+00:00",
                "totalAmount": "9933"
            }
        }
}
```
# GET /REPORT

api/report/e2b16cc6-2d69-48e9-8182-7af8db13c9aa

# RESPONSE
```javascript
{
    "transactionResponse": {
        "message": "AUTHORIZED",
        "order": {
            "tid": "e2b16cc6-2d69-48e9-8182-7af8db13c9aa",
            "dateTime": "2018-02-19T21:46:40.894Z",
            "totalAmount": "9933"
        }
    }
}

```

