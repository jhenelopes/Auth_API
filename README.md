🔐 Technical Challenge – Authentication Module in .NET 8
🧩 Scenario

A technology company is migrating its authentication system from Java with Spring Boot to .NET 8 and needs to build a new API in C#.
The goal is to ensure that existing users can continue to log in successfully through the new API, which should keep validating user credentials and issuing valid tokens for authentication and access to system resources.

🎯 Objective

Develop an authentication API in .NET 8 that:
Accepts username and password using the password grant type.
Queries the existing tbl_user table in a PostgreSQL database.
Verifies the password using BCrypt, as all passwords are already stored using this algorithm.
Issues two JWTs:
access_token (valid for 6 minutes).
refresh_token (valid for 1 hour).

💻 Used Dependencies


    BCrypt.Net-Next(4.0.3)
    Microsoft.AspNetCore.Authentication.JwtBearer(8.0.0)
    Microsoft.EntityFrameworCore(9.0.4)
    Npgsqp>entityFrameworkCore.PostGresSQL(9.0.4)
    Swashbuclke.AspNetCore

🧪 Postgres

    5432

✨ Swagger

Swagger was used for API documentation and testing 
